using System;
using System.Collections.Generic;
using System.Text;

namespace URI
{
    public class MinHeap
    {
        public static int[] ConstroiMinHeap(int[] a)
        {
            var b = (int)Math.Floor((decimal)((a.Length - 1) / 2)); //último nó com filho

            for (var i = b; i >= 0; i--)//percorre último nó com filho até raiz 
                SobeHeap(a, i);

            return a;
        }

        private static int[] SobeHeap(int[] a, int index)
        {
            int l = (2 * index) + 1;
            int r = (2 * index) + 2;
            int menor;

            if (l < a.Length && a[l] < a[index])
                menor = l;
            else
                menor = index;

            if (r < a.Length && a[r] < a[menor])
                menor = r;

            if (menor != index)
            {
                var aux = a[index];
                a[index] = a[menor];
                a[menor] = aux;

                SobeHeap(a, menor);
            }
            return a;
        }

        public static int HeapMin(int[] a)
        {
            return a[0];
        }

        public static Tuple<int[], int> ExtraiMin(int[] a)
        {
            int root = a[0];
            a[0] = a[a.Length];
            //coloca o ultimo elemento na raiz
            //chama o metódo q ordena isso tudo
            return new Tuple<int[], int>(a ,root);
        }

        public static int[] HeapInsere(int[] a, int valor)
        {
            int[] novoVetor = new int[a.Length + 1];
            a.CopyTo(novoVetor, 0);

            novoVetor[a.Length] = valor;

            var heap = ConstroiMinHeap(novoVetor);

            return heap;
        }
    }
}
