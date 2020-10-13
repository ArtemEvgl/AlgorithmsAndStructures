using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace QuickSort
{
    class Program
    {
        
        
        public static void QuickSort(int[] items)
        {
            QuickSort(items, 0, items.Length - 1);
        }

        private static void QuickSort(int[] items, int left, int right)
        {
            int i = left, j = right;
            int pivot = items[(left + right) / 2];
            while (i<=j)
            {
                while (pivot > items[i])
                {
                    i++;
                }
                while (pivot < items[j])
                {
                    j--;
                }
                if (i<=j)
                {
                    int temp = items[i];
                    items[i] = items[j];
                    items[j] = temp;

                    i++;
                    j--;
                }
            }
            if (j > left)
            {
                QuickSort(items, left, j);
            }
            if (i < right)
            {
                QuickSort(items, i, right);
            }
        }

        static void Main(string[] args)
        {
            int[] array = { 3, 7, 4, 4, 6, 5, 8 };

            Console.Write("Массив до сортировки: ");

            for (int i = 0; i < array.Length; i++)
            {
                Console.Write(array[i]);
            }

            Console.Write(" \nОтсортированный массив: ");

            QuickSort(array);

            for (int i = 0; i < array.Length; i++)
            {
                Console.Write(array[i]);
            }

            Console.WriteLine();
            Console.ReadLine();
        }
    }
}
