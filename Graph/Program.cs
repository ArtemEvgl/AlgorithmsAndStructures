using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Graph
{
    class Program
    {
        static void Main(string[] args)
        {
            int[,] arr = new int[,]
            {
                {0, 1, 0, 1},
                {1, 0, 1, 0},
                {0, 1, 0, 0},
                {1, 0, 0, 0}
            };
            Graph.Wave(arr, 0, 1, 4, 4);
            for (int i = 0; i < 4; i++)
            {
                for (int j = 0; j < 4; j++)
                {
                    Console.Write(arr[i, j]);
                }
                Console.WriteLine();
            }
            Console.ReadKey();
        }
    }
}
