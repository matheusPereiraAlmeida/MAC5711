using System;
using System.Collections.Generic;
using System.Text;

namespace URI
{
    /*Implementação do LCS
     Definição: Dado 2 vetores X[1..n] e Y[1..m], queremos encontrar a Z, que é subsequência comum máxima(LCS - longest common subsequence) de X,Y
     */
    public class ProgramacaoDinamica3
    {
        //public static int[,] C = new int[10, 20];

        public static int ImplementacaoRecursiva(char[] X, int i, char[] Y, int j, int[,] C)
        {
            if (i == 0 || j == 0) return 0;
            if (X[i] == Y[j])
            {
                C[i, j] = ImplementacaoRecursiva(X, i - 1, Y, j - 1, C) + 1;
            }
            else
            {
                var q1 = ImplementacaoRecursiva(X, i - 1, Y, j, C);
                var q2 = ImplementacaoRecursiva(X, i, Y, j - 1, C);

                if (q1 >= q2)
                    C[i, j] = q1;
                else
                    C[i, j] = q2;
            }

            return C[i, j];
        }
        public static Tuple<int[,], int[,]> ImplementacaoDinamica(int[] X, int m, int[] Y, int n, int[,] C, int[,] B)
        {
            for (int i = 1; i < m; i++)
            {
                for (int j = 1; j < n; j++)
                {
                    if (X[i] == Y[j])
                    {
                        C[i, j] = C[i - 1, j - 1] + 1;
                        B[i, j] = -2;//seta para cima-esquerda 
                    }
                    else if (C[i - 1, j] >= C[i, j - 1])
                    {
                        C[i, j] = C[i - 1, j];
                        B[i, j] = -1;//seta para cima
                    }
                    else
                    {
                        C[i, j] = C[i, j - 1];
                        B[i, j] = 1;//seta para lado esquerdo
                    }
                }
            }

            return new Tuple<int[,], int[,]>(C, B);
        }
        public static void print_lcs(char[] X, int i, char[] Y, int j, int[,] B)
        {
            if (i == 0 || j == 0) return;

            if (B[i, j] == -2)  //seta para cima-esquerda 
            {
                print_lcs(X, i - 1, Y, j - 1, B);
                Console.WriteLine(X[i]);
            }
            else if (B[i, j] == -1) //seta para cima
            {
                print_lcs(X, i - 1, Y, j, B);
            }
            else//seta para lado esquerdo
            {
                print_lcs(X, i, Y, j-1, B);
            }
        }
        public static void print_lcs_no_tableB(int[] X, int i, int[] Y, int j, int[,] C)
        {
            if (i == 0 || j == 0) return;

            if (X[i] == Y[j])  //seta para cima-esquerda 
            {
                print_lcs_no_tableB(X, i - 1, Y, j - 1, C);
                Console.WriteLine(X[i]);
            }
            else if (C[i - 1, j] >= C[i, j - 1]) //seta para cima
            {
                print_lcs_no_tableB(X, i - 1, Y, j, C);
            }
            else//seta para lado esquerdo
            {
                print_lcs_no_tableB(X, i, Y, j - 1, C);
            }
        }
    
        public static void print_lcs_mono(int[] X, int i, int[] Y, int j, int[,] C)
        {
            var s = new int[3];
            var n = 0;
            while(i>=0 && j >= 0)
            {
                if(X[i] == Y[j])
                {
                    s[n] = X[i];
                    i--;
                    j--;
                    n++;
                }
                else if (C[i - 1, j] >= C[i, j - 1]) //seta para cima
                {
                    i--;
                }
                else//seta para lado esquerdo
                {
                    j--;
                }
            }
        }
    }
}
