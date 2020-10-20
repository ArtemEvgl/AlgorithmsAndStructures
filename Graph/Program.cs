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
            double[,] arr = new double[,]
            {
                {0, 1, 0, 0, 1},
                {1, 0, 1, 1, 0},
                {0, 1, 0, 0, 1},
                {0, 1, 0, 0, 1},
                {1, 0, 1, 1, 0}
            };

            Graph g = new Graph(arr);
            g.GetQuantityEdge();

            g.DFSNoRecursive(0);

            Console.ReadKey();
        }
    }
}
