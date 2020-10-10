using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MySet
{
    class Program
    {
        static void Main(string[] args)
        {
            int[] array = { 3, 4, 5, 6 };

            var set1 = new MySet<int>();
            var set2 = new MySet<int>(array);
            var set3 = new MySet<int>();

            set1.Add(1);
            set1.Add(2);
            set1.Add(3);
            set1.Add(4);

            set3 = set1.Difference(set2);

            foreach (var item in set3)
            {
                Console.WriteLine(item);
            }

            Console.WriteLine();
            Console.ReadKey();

            set1 = new MySet<int>();
            set2 = new MySet<int>(array);
            set3 = new MySet<int>();

            set1.Add(1);
            set1.Add(2);
            set1.Add(3);
            set1.Add(4);

            set3 = set1.SymDifference(set2);

            foreach (var item in set3)
            {
                Console.WriteLine(item);
            }

            Console.ReadKey();
        }
    }
}
