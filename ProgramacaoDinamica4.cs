using System;
using System.Collections.Generic;
using System.Text;

namespace URI
{
    /*Implementação do problema da mochila (Knapsack Problem)
     Definição: O objetivo é que se preencha a mochila com o maior valor possível, não ultrapassando o peso máximo*/

    public class ProgramacaoDinamica4
    {
        /*devolve o valor de uma mochila ótima
        w[1..n] = vetor de pesos
        v[1..n] = vetor de valores
        n = quantidade total de itens pedidos
        W = peso total da mochila
         */
        public static int Recursivo_mochila(int[] w, int[] v, int n, int W)
        {
            if (n == 0 || W == 0) return 0;
            if (w[n] > W) return Recursivo_mochila(w, v, n - 1, W); // não cabe na mochila

            var a = Recursivo_mochila(w, v, n - 1, W);
            var b = Recursivo_mochila(w, v, n, W - w[n]) + v[n]; //coloca na mochila

            return Math.Max(a, b);
        }

        public static Tuple<int, int[]> Pd_mochila(int[] w, int[] v, int n, int W)
        {
            int[,] T = new int[n + 1, W + 1];

            for (int Y = 0; Y <= W; Y++)
            {
                T[0, Y] = 0;
                for (int i = 1; i <= n; i++)
                {
                    var a = T[i - 1, Y];
                    int b;
                    if (w[i - 1] > Y)
                        b = 0;
                    else
                        b = T[i - 1, Y - w[i - 1]] + v[i - 1];

                    T[i, Y] = Math.Max(a, b);
                }
            }

            var x = Obter_mochila(w, n, W, T);

            return new Tuple<int, int[]>(T[n - 1, W - 1], x);
        }

        public static int Pd_mochila_versao_copias(int[] w, int[] v, int n, int W)
        {
            int[,] T = new int[n + 1, W + 1];

            for (int Y = 0; Y <= W; Y++)
            {
                T[0, Y] = 0;
                for (int i = 1; i <= n; i++)
                {
                    var a = T[i - 1, Y];
                    int b;
                    if (w[i - 1] > Y)
                        b = 0;
                    else
                        b = T[i, Y - w[i - 1]] + v[i - 1];

                    T[i, Y] = Math.Max(a, b);
                }
            }
            return T[n, W];
        }

        public static int[] Obter_mochila(int[] w, int n, int W, int[,] T)
        {
            var Y = W;
            var x = new int[n];
            n--;

            for (int i = n; i >= 1; i--)
            {
                if (T[i, Y] == T[i - 1, Y])
                    x[i] = 0;
                else
                {
                    x[i] = 1;
                    Y = Y - w[i];
                }

            }

            return x;
        }
    }
}
