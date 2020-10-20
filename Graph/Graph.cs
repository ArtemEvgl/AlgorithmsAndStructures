using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Graph
{
    class Graph
    {
        private double[,] list;
        private int n;

        public Graph(int n)
        {
            list = new double[n, n];
            this.n = n;
        }

        public Graph(double[,] list)
        {
            this.list = list;
            this.n = list.GetLength(0);
        }

        public void Add (int from, int to, double cost)
        {
            list[from, to] = cost;
        }

        public void BFS (int from)
        {
            bool[] visited = new bool[n];
            Queue<int> turn = new Queue<int>();
            turn.Enqueue(from);
            visited[from] = true;
            while (turn.Count > 0)
            {
                
                int index = turn.Dequeue();
                Console.WriteLine(index);
                for (int i = 0; i < n; i++)
                {
                    if (list[index, i] != 0 && !visited[i])
                    {
                        visited[i] = true;
                        turn.Enqueue(i);
                    }
                }
            }
        }

        public void DFS(int from)
        {
            DFS(from, new bool[n]);
        }

        private void DFS(int from, bool[] visited)
        {
            visited[from] = true;
            Console.WriteLine(from);    
            for (int i = 0; i < n; i++)
            {
                if (list[from, i] != 0 && !visited[i])
                {
                    DFS(i, visited);
                }
            }
        }

        public void DFSNoRecursive(int from)
        {
            bool[] visited = new bool[n];
            Stack<int> stack = new Stack<int>();
            stack.Push(from);
            visited[from] = true;
            while (stack.Count > 0)
            {
                int index = stack.Pop();
                Console.WriteLine(index);
                for (int i = 0; i < n; i++)
                {
                    if (list[index, i] != 0 && !visited[i])
                    {
                        visited[i] = true;
                        stack.Push(i);
                    }
                }
            }
        }

        public double GetQuantityEdge()
        {
            return Math.Max(CalculateDownTriangle(), CalculateUpTriangle());
        }
        private double CalculateUpTriangle()
        {
            double result = 0;
            for (int i = 0; i < n; i++)
            {
                for (int j = i; j < n; j++)
                {
                    result += list[i, j];
                }
            }
            return result;
        }

        private double CalculateDownTriangle()
        {
            double result = 0;
            for (int i = 0; i < n; i++)
            {
                for (int j = 0; j <= i; j++)
                {
                    result += list[i, j];
                }
            }
            return result;
        }
    }
}
