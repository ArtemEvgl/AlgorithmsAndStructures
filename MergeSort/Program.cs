using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MergeSort
{
    class Program
    {
        
        private static void MergeSort(int[] items)
        {
            if(items.Length <= 1)
            {
                return;
            }

            int leftSize = items.Length / 2;
            int rightSize = items.Length - leftSize;

            int[] left = new int[leftSize];
            int[] right = new int[rightSize];

            Array.Copy(items, 0, left, 0, leftSize);
            Array.Copy(items, leftSize, right, 0, rightSize);

            MergeSort(left);
            MergeSort(right);

            Merge(items, left, right);
        }

        private static void Merge(int[] items, int[] left, int[] right)
        {
            int leftIndex = 0, rightIndex = 0, targetIndex = 0, remaining = left.Length + right.Length;
            while (remaining > 0)
            {
                if (rightIndex >= right.Length)
                {
                    items[targetIndex] = left[leftIndex++];
                } else if(leftIndex >= left.Length)
                {
                    items[targetIndex] = right[rightIndex++];
                } else if(left[leftIndex] > right[rightIndex])
                {
                    items[targetIndex] = right[rightIndex++];
                } else
                {
                    items[targetIndex] = left[leftIndex++];
                }
                remaining--;
                targetIndex++;
            }
        }
        static void Main(string[] args)
        {
            int[] array = { 3, 8, 2, 1, 5, 4, 6, 7 };

            // Сортировка массива

            MergeSort(array);

            for (int i = 0; i < array.Length; i++)
            {
                Console.WriteLine(array[i]);
            }
            Console.ReadLine();
        }
    }
}
