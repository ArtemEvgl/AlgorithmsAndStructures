using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ShellSort
{
    class Program
    {
        static void Swap(ref int e1, ref int e2)
        {
            var temp = e1;
            e1 = e2;
            e2 = temp;
        }

        static void ShellSort(int[] array)
        {
            int d = array.Length / 2;
            while (d >= 1)
            {
                for (int i = d; i < array.Length; i++)
                {
                    int j = i;
                    while (j > d && array[j - d] > array[j])
                    {
                        Swap(ref array[j - d], ref array[j]);
                        j = j - d;
                    }
                }
                d = d / 2;
            }
            
        }

        static void Main(string[] args)
        {
            int[] array = { -2, -3, -1, 0, 12, 22, 103, 7, 4, 2, 6, 5, 8 };

            ShellSort(array);

            for (int i = 0; i < array.Length; i++)
            {
                Console.WriteLine(array[i]);
            }
            Console.ReadKey();
        }
    }
}
