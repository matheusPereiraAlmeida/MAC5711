using System;

namespace URI
{
    public class ThreeWaySort 
    {
        public static int[] ThreeWayMergeSort(int[] a)
        {
            if (a.Length <= 1) return a;

            int mid1 = a.Length / 3;
            int mid2 = (2 * a.Length) / 3;

            var vetor1 = ThreeWayMergeSort(SubArray(a, 0, mid1 - 1));
            var vetor2 = ThreeWayMergeSort(SubArray(a, mid1, mid2 - 1));
            var vetor3 = ThreeWayMergeSort(SubArray(a, mid2, a.Length - 1));

            return Merge(vetor1, vetor2, vetor3);
        }
        public static int[] SubArray(int[] data, int inicio, int fim)
        {
            if (fim < inicio) return new int[0];

            int[] result = new int[fim - inicio + 1];
            int i = 0;

            while (inicio <= fim)
            {
                result[i] = data[inicio];
                inicio++;
                i++;
            }
            return result;

        }
        private static int[] Merge(int[] vs1, int[] vs2, int[] vs3)
        {
            return IntercalaElmeentos(vs1, IntercalaElmeentos(vs2, vs3));
        }
        private static int[] IntercalaElmeentos(int[] vs2, int[] vs3)
        {
            int count = 0;
            int i = 0;
            int j = 0;
            int k = 0;
            int[] aux = new int[vs2.Length + vs3.Length];

            while (i < vs2.Length && j < vs3.Length)
            {
                if (vs2[i] < vs3[j])
                {
                    aux[k++] = vs2[i++];
                }
                else
                {
                    aux[k++] = vs3[j++];
                }
            }

            //remaining
            while (i < vs2.Length)
            {
                aux[k++] = vs2[i++];
            }
            while (j < vs3.Length)
            {
                aux[k++] = vs3[j++];
            }

            return aux;

        }
    }
}