using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SelectionSort
{
    class Program
    {
        private static void Swap(int[] array, int left, int right)
        {
            int temp = array[left];
            array[left] = array[right];
            array[right] = temp;
        }

        private static void SelectionSort(int[] items)
        {
            int sortedRangeEnd = 0;
            while (sortedRangeEnd < items.Length)
            {
                int nextIndex = FindNextSmallestIndex(items, sortedRangeEnd);
                Swap(items, sortedRangeEnd, nextIndex);
                sortedRangeEnd++;
            }
        }

        private static int FindNextSmallestIndex(int[] items, int sortedRangeEnd)
        {
            int currentSmallest = items[sortedRangeEnd];
            int currentSmallestIndex = sortedRangeEnd;

            for (int i = currentSmallestIndex + 1; i < items.Length; i++)
            {
                if (items[i] < currentSmallest)
                {
                    currentSmallest = items[i];
                    currentSmallestIndex = i;
                }
            }
            return currentSmallestIndex;
        }

        static void Main(string[] args)
        {
            int[] array = { 3, 7, 4, 4, 6, 5, 8 };

            SelectionSort(array);

            for (int i = 0; i < array.Length; i++)
            {
                Console.WriteLine(array[i]);
            }
            Console.ReadKey();
        }
    }
}
