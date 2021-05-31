using System;
using System.Collections.Generic;
using System.Text;

namespace URI
{
    public class ProgramacaoDinamica1
    {
        //O(2^n) e Ω(3/2^n)
        public static int FibonacciVersaoRecursiva1(int n)
        {
            if (n <= 1)
            {
                return n;
            }
            else
            {
                int a = FibonacciVersaoRecursiva1(n - 1);
                int b = FibonacciVersaoRecursiva1(n - 2);
                return a + b;
            }
        }
        //consome Θ(n)
        public static int FibonacciVersaoIterativa1(int n)
        {
            int[] fib = new int[n];
            fib[0] = 0;
            fib[1] = 1;

            for (int i = 2; i <= n; i++)
                fib[i] = fib[i - 1] + fib[i - 2];

            return fib[n];
        }

        public static int FibonacciVersaoIterativa2(int n)
        {
            if (n == 0) return 0;
            int f_ant = 0;
            int f_atual = 1;
            int f_prox = 0;

            for (int i = 2; i <= n; i++)
            {
                f_prox = f_ant + f_prox;
                f_ant = f_atual;
                f_atual = f_prox;
            }

            return f_atual;
        }
    }
}
