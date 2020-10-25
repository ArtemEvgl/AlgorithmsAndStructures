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
            double[] numbers = {1,2,2,3,1,3,1,5};
            
            Graph graph = new Graph(Graph.GetMatrix(5, 4, numbers));
            IList<int> results = graph.TopologicSort(); 
        }
    }
}
