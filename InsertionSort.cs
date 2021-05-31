using System;
using System.Collections.Generic;
using System.Text;

namespace URI
{
    public class InsertionSort
    {
        public static int[] InsertionSortalgorithm(int[] a)
        {
            for(int j = 2; j<a.Length; j++)
            {
                int key = a[j];
                int i = j - 1;

                while(i>=0 && a[i] > key)
                {
                    a[i + 1] = a[i];
                    i = i - 1;
                }
                a[i + 1] = key;
            }

            return a;
        }
    }
}
