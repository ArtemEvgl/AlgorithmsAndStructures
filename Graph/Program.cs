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
            int[,] g = new int[,]{
                {0, 5, -1, 6, -1, 50},
                {5, 0, 7, -1, -1, -1},
                {-1, 7, 0, 4, -1, 10},
                {6, -1, 4, 0, 10, -1},
                {-1, -1, -1, 10, 0, 8},
                {50, -1, 10, -1, 8, 0}
            };
            Wave wave = Graph.MyWave(g, 0, 5);
            
            Console.ReadKey();
        }
    }
}
