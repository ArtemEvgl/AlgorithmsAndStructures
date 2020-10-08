using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DynamicArray
{
    class Program
    {
        static void Main(string[] args)
        {
            DynamicArray<int> arr = new DynamicArray<int>();
            for (int i = 0; i < 10; i++) arr.Add(i);
            Print(arr);
            arr.RemoveAt(8);
            arr.Remove(2);
            Print(arr);
            Console.Read();
        }

        public static void Print(DynamicArray<int> array)
        {
            foreach (var item in array)
            {
                Console.WriteLine(item);
            }
            Console.WriteLine(new string('-', 20));
        }
    }
}
