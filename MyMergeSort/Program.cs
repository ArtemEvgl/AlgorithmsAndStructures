using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MyMergeSort
{
    class Program
    {
        
        public static int[] MergeSort(int[] items)
        {
            return MergeSort(items, 0, items.Length - 1);
        }

        private static int[] MergeSort(int[] items, int lowIndex, int hightIndex)
        {
            if(lowIndex < hightIndex)
            {
                var midleIndex = (lowIndex + hightIndex) / 2;
                MergeSort(items, lowIndex, midleIndex);
                MergeSort(items, midleIndex + 1, hightIndex);
                Merge(items, lowIndex, midleIndex, hightIndex);

            }
            return items;
        }

        private static void Merge(int[] items, int lowIndex, int midleIndex, int hightIndex)
        {
            var left = lowIndex;
            var right = midleIndex + 1;
            var tempArray = new int[hightIndex - lowIndex + 1];
            var index = 0;

            while ((left <= midleIndex) && (right <= hightIndex))
            {
                if(items[left] < items[right])
                {
                    tempArray[index] = items[left];
                    left++;
                } else
                {
                    tempArray[index] = items[right];
                    right++;
                }
                index++; 
            }

            for (int i = left; i <= midleIndex; i++)
            {
                tempArray[index] = items[i];
                index++;
            }

            for (int i = right; i <= hightIndex; i++)
            {
                tempArray[index] = items[i];
                index++;
            }

            for (int i = 0; i < tempArray.Length; i++)
            {
                items[lowIndex + i] = tempArray[i];
            }
        }

        static void Main(string[] args)
        {
            Console.WriteLine("Сортировка слиянием");
            Console.Write("Введите элементы массива: ");
            var s = Console.ReadLine().Split(new[] { " ", ",", ";" }, StringSplitOptions.RemoveEmptyEntries);
            var array = new int[s.Length];
            for (int i = 0; i < s.Length; i++)
            {
                array[i] = Convert.ToInt32(s[i]);
            }
            
            Console.WriteLine("Упорядоченный массив: {0}", string.Join(", ", MergeSort(array)));

            Console.ReadLine();
        }
    }
}
