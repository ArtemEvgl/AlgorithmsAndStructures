using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace InsertionSort
{
    class Program
    {
        
        private static void InsertionSort(int[] array)
        {
            int sortedRangeEndIndex = 1;
            while (sortedRangeEndIndex < array.Length)
            {
                if (array[sortedRangeEndIndex-1] > array[sortedRangeEndIndex])
                {
                    int inserIndexAt = FindSmallestIndex(array, sortedRangeEndIndex);
                    InsertItem(array, inserIndexAt, sortedRangeEndIndex);
                }
                sortedRangeEndIndex++;
            }
        }

        private static void InsertItem(int[] array, int inserIndexAt, int insertIndexFrom)
        {
            int temp = array[inserIndexAt];
            array[inserIndexAt] = array[insertIndexFrom];

            for (int current = insertIndexFrom; current > inserIndexAt; current--)
            {
                array[current] = array[current - 1];
            }
            array[inserIndexAt + 1] = temp;
        }

        private static int FindSmallestIndex(int[] array, int sortedRangeEndIndex)
        {
            for (int i = 0; i < sortedRangeEndIndex; i++)
            {
                if (array[i] > array[sortedRangeEndIndex])
                    return i;
            }
            throw new InvalidOperationException("Индекс не найден");
        }

        static void Main(string[] args)
        {
            int[] array = { 3, 7, 4, 4, 6, 5, 8 };

            InsertionSort(array);

            for (int i = 0; i < array.Length; i++)
            {
                Console.WriteLine(array[i]);
            }
            Console.ReadLine();
        }
    }
}
