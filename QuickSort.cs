using System;
using System.Collections.Generic;
using System.Text;

namespace URI
{
    public class QuickSort
    {
        public static void QuickSortAlgorith(int[] a, int inicio, int fim)
        {
            if (inicio < fim)
            {
                int q = Partition(a, inicio, fim);
                QuickSortAlgorith(a, inicio, q - 1);
                QuickSortAlgorith(a, q + 1, fim);
            }
        }
        public static int Partition(int[] a, int inicio, int fim)
        {
            int pivo = a[fim];
            int i = inicio - 1;
            for (var j = inicio; j < fim; j++)
            {
                if (a[j] >= pivo)
                {
                    i++;
                    Exchange(a, i, j);
                }
            }
            Exchange(a, i + 1, fim);
            return i + 1;

        }

        private static void Exchange(int[] a, int r, int i)
        {
            int aux = a[i];
            a[i] = a[r];
            a[r] = aux;
        }
    }
}
