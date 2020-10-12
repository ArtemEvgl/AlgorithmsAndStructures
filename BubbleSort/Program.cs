using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BubbleSort
{
    class Program
    {
        private static void Swap(int[] array, int left, int right)
        {
            int temp = array[left];
            array[left] = array[right];
            array[right] = temp;
        }
        
        private static void BubbleSort(int[] array)
        {
            bool swapped;
            int j = 0;
            do
            {
                swapped = false;
                for (int i = 1; i < array.Length - j; i++)
                {
                    if (array[i - 1] > array[i])
                    {
                        Swap(array, i - 1, i);
                        swapped = true;
                    }
                }
                j++;
            } while (swapped != false);
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

            BubbleSort(array);

            for (int i = 0; i < array.Length; i++)
            {
                Console.Write(array[i]);
            }

            Console.WriteLine();
            Console.ReadLine();
        }
    }
}
