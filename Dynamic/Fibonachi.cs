using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Dynamic
{
    static class Fibonachi
    {
        public static int StraightMethod(int n)
        {
            int[] fibo = new int[n];
            fibo[0] = 1;
            fibo[1] = 2;
            for (int i = 2; i < n; i++)
            {
                fibo[i] = fibo[i - 2] + fibo[i - 1];
            }
            return fibo[n - 1];
        }

        public static int ReverseMethod(int n)
        {
            int[] fibo = new int[n];
            fibo[0] = 1;
            for (int i = 0; i < n - 2; i++)
            {
                fibo[i + 1] += fibo[i];
                fibo[i + 2] += fibo[i];
            }
            return fibo[n - 1] + fibo[n - 2];
        }

        public static int GetFibo(int n)
        {
            if (n < 3)
            {
                return 1;
            }
            return GetFibo(n - 1) + GetFibo(n - 2);
        }


    }
}
