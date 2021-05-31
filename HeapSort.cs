using System;
using DevExpress.Xpo;

namespace URI
{

    public class HeapSort
    {
        private static int elements;

        public static int[] Heapsort(int[] a)
        {
            ConstroiHeap(a);
            for(var i = a.Length - 1; i>1; i--) //percorre último nó até raiz
            {
                var aux = a[0];
                a[0] = a[i];
                a[i] = aux;
                DesceHeap(a, 0);
            }
            return a;
        }

        public static int[] ConstroiHeap(int[] a)
        {
            var b = (int)Math.Floor((decimal)((a.Length - 1) / 2)); //último nó com filho

            for (var i = b; i > 1; i--)//percorre último nó com filho até raiz 
                DesceHeap(a, i);

            return a;
        }

        public static int[] DesceHeap(int[] a, int index)
        {
            int l = 2 * index;
            int r = (2 * index) + 1;
            int largest;

            if(l < a.Length && a[l] > a[index])
                largest = l;
            else
                largest = index;

            if(r<a.Length && a[r]> a[largest])
                largest = r;

            if(largest != index)
            {
                var aux = a[index];
                a[index] = a[largest];
                a[largest] = aux;

                DesceHeap(a, largest);
            }
            return a;
        }
    }
}