using System;
using System.Collections.Generic;
using System.Text;

namespace URI
{
    public class CountingSort
    {
        public static int[] CountingSortImplementation(int[] array, int max)
        {
            int[] count = new int[max + 1];

            for (int i = 0; i < array.Length; i++)
            {
                int value = array[i];
                count[value]++;
            }

            for (int i = 1; i < count.Length; i++)
            {
                count[i] = count[i] + count[i - 1];
            }

            int[] sorted = new int[array.Length];

            for (int i = array.Length - 1; i >= 0; i--)
            {
                int value = array[i];
                int position = count[value] - 1;
                sorted[position] = value;

                count[value]--;
            }

            return sorted;
        }

        public static char[] CountingSortForString(char[] array, int elements)
        {
            int[] count = new int[elements];

            for (int i = 0; i < array.Length; i++)
            {
                int value = array[i];
                if (value == 65) //A
                {
                    count[0]++;
                }
                else { count[1]++; }
            }

            for (int i = 1; i < count.Length; i++)
            {
                count[i] = count[i] + count[i - 1];
            }

            char[] sorted = new char[array.Length];

            for (int i = array.Length - 1; i >= 0; i--)
            {
                if (array[i] == 65) //A
                {
                    int position = count[0] - 1;
                    sorted[position] = array[i];
                    count[0]--;
                }
                else {
                    int position = count[1] - 1;
                    sorted[position] = array[i];
                    count[1]--;
                }
            }

            return sorted;
        }

        public static int ex37(int[] array, int max, int inicio, int fim)
        {
            int[] count = new int[max + 1];

            for (int i = 0; i < array.Length; i++)
            {
                int value = array[i];
                count[value]++;
            }

            for (int i = 1; i < count.Length; i++)
            {
                count[i] = count[i] + count[i - 1];
            }

            var resultado = count[fim] - count[inicio-1];
            return resultado;

        }
    }
}
