﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Dynamic
{
    static class LCS
    {
        /// <summary>
        /// Поиск совпадающих последовательностей
        /// </summary>
        /// <returns></returns>
        public static string GetLcs(string s1, string s2)
        {
            int n = s1.Length;
            int m = s2.Length;

            int[,] lcs = new int[n + 1, m + 1];

            for (int i = 1; i <= n; i++)
            {
                for (int j = 1; j <= n; j++)
                {
                    if (s1[i - 1].Equals(s2[j - 1]))
                    {
                        lcs[i, j] = lcs[i - 1, j - 1] + 1;
                        break;
                    } else
                    {
                        lcs[i, j] = Math.Max(lcs[i - 1, j], lcs[i, j - 1]);
                    }
                }
            }

            int index = lcs[n, m];
            char[] result = new char[index + 1];

            int k = n;
            int l = m;

            while (k > 0 && l > 0)
            {
                if (s1[k - 1].Equals(s2[l - 1]))
                {
                    result[index - 1] = s1[k - 1];
                    k--;
                    l--;
                    index--;
                }
                else if (lcs[k - 1, l].CompareTo(lcs[k, l - 1]) == 1)
                    k--;
                else
                    l--;
            }
            return new string(result);
        }
    }
}
