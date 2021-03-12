using System;

namespace URI
{
    public class MergeSort 
    {
        static int count;
        public static Tuple<int[], int> MergeSortAlgorithm(int[] a)
        {
            if (a.Length <= 1) return Tuple.Create(a, count);

            int mid = a.Length / 2;

            var vetor1 = MergeSortAlgorithm(SubArray(a, 0, mid-1));
            var vetor2 = MergeSortAlgorithm(SubArray(a, mid, a.Length - 1));

            return Tuple.Create(Intercala(vetor1.Item1, vetor2.Item1), count);
        }
    
        private static int[] SubArray(int[] data, int inicio, int fim)
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

        private static int[] Intercala(int[] vs2, int[] vs3)
        {
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

        //private static int[] IntercalaEx03(int[] vs2, int[] vs3)
        //{
        //    int i = 0;
        //    int j = 0;
        //    int k = 0;
        //    int[] aux = new int[vs2.Length + vs3.Length];

        //    while (i < vs2.Length && j < vs3.Length)
        //    {
        //        if (i < j && vs2[i] > vs3[j])
        //            count++;

        //        if (vs2[i] < vs3[j])
        //        {
        //            aux[k++] = vs2[i++];
        //        }
        //        else
        //        {
        //            aux[k++] = vs3[j++];
        //        }
        //    }

        //    if (i == vs2.Length && vs2.Length > 0) i--;
        //    if (j == vs3.Length && vs3.Length > 0) j--;

        //    //remaining
        //    while (i < vs2.Length)
        //    {
        //        if (i < j && vs2[i] > vs3[j])
        //            count++;
                
        //        aux[k++] = vs2[i++];
        //    }

        //    if (i == vs2.Length - 1 && vs2.Length > 0) i++;
        //    if (j == vs3.Length -1 && vs3.Length > 0) j++;

        //    while (j < vs3.Length)
        //    {
        //        if (i < j && vs2[i] > vs3[j])
        //            count++;

        //        aux[k++] = vs3[j++];
        //    }

        //    return aux;

        //}

    }
}