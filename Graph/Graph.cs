using System;
using System.Collections.Generic;
using System.Linq;
using System.Security.Cryptography.X509Certificates;
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
        

        public static Wave MyWave(int[,] arr, int start, int finish)
        {
            Wave wave = new Wave(start, int.MaxValue, 0);
            Wave min = new Wave(start, 0, int.MaxValue);
            Queue<Wave> queue = new Queue<Wave>();
            queue.Enqueue(wave);
            while (queue.Count > 0)
            {
                int count = queue.Count;
                while (count > 0)
                {
                    Wave inputWave = queue.Dequeue();
                    DoWave(arr, inputWave, finish, ref min, queue);
                    count--;
                }
            }
            return min;
            
        }

        public static void DoWave(int[,] arr, Wave wave, int finish, ref Wave min, Queue<Wave> queue)
        {
            for (int i = 0; i < arr.GetLength(0); i++)
            {
                if (arr[wave.Position, i] > 0 && i == finish && wave.Cost + arr[wave.Position, i] < min.Cost)
                {
                    wave.AddPoint(finish);
                    wave.Cost += arr[wave.Position, i];
                    min = wave;
                }
                else if (arr[wave.Position, i] > 0 && wave.Cost + arr[wave.Position, i] < min.Cost && i != wave.Previous)
                {
                    List<int> points = new List<int>(wave.Points);
                    points.Add(i);
                    Wave newWave = new Wave(i, wave.Position, wave.Cost + arr[wave.Position, i], points);
                    queue.Enqueue(newWave);
                }
            }
        }
        /// <summary>
        /// Волновой алгоритм
        /// </summary>
        public static void Wave(int[,] arr, int x, int y, int m, int n)
        {
            if (arr[x,y] == 0)
            {
                return;
            }
            int k = 2;
            arr[x, y] = k;
            Queue<KeyValuePair<int, int>> queue = new Queue<KeyValuePair<int, int>>();
            KeyValuePair<int, int> start = new KeyValuePair<int, int>(x,y);
            queue.Enqueue(start);
            while (queue.Count > 0)
            {
                int count = queue.Count;
                k++;
                while(count > 0)
                {
                    KeyValuePair<int, int> point = queue.Dequeue();
                    int i = point.Key;
                    int j = point.Value;
                    DoWave(arr, i, j, k, m, n, queue);
                    count--;
                }
            }
        }

        
        private static bool IsValid(int j, int i, int m, int n)
        {
            return j >= 0 && j < m && i >= 0 && i < n;
        }
        private static void DoWave(int[,] arr, int i, int j, int k, int m, int n, Queue<KeyValuePair<int, int>> queue)
        {
            if (IsValid(i + 1, j, m, n) && arr[i + 1, j] == 1)
            {
                arr[i + 1, j] = k;
                queue.Enqueue(new KeyValuePair<int, int>(i + 1, j));
            }
            if (IsValid(i + 1, j + 1, m, n) && arr[i + 1, j + 1] == 1)
            {
                arr[i + 1, j + 1] = k;
                queue.Enqueue(new KeyValuePair<int, int>(i + 1, j + 1));
            }
            if (IsValid(i + 1, j - 1, m, n) && arr[i + 1, j - 1] == 1)
            {
                arr[i + 1, j - 1] = k;
                queue.Enqueue(new KeyValuePair<int, int>(i + 1, j - 1));
            }
            if (IsValid(i, j + 1, m, n) && arr[i, j + 1] == 1)
            {
                arr[i, j + 1] = k;
                queue.Enqueue(new KeyValuePair<int, int>(i, j + 1));
            }
            if (IsValid(i, j - 1, m, n) && arr[i, j - 1] == 1)
            {
                arr[i, j - 1] = k;
                queue.Enqueue(new KeyValuePair<int, int>(i, j - 1));
            }
            if (IsValid(i - 1, j, m, n) && arr[i - 1, j] == 1)
            {
                arr[i - 1, j] = k;
                queue.Enqueue(new KeyValuePair<int, int>(i - 1, j));
            }
            if (IsValid(i - 1, j - 1, m, n) && arr[i - 1, j - 1] == 1)
            {
                arr[i - 1, j - 1] = k;
                queue.Enqueue(new KeyValuePair<int, int>(i - 1, j - 1));
            }
            if (IsValid(i - 1, j + 1, m, n) && arr[i - 1, j + 1] == 1)
            {
                arr[i - 1, j + 1] = k;
                queue.Enqueue(new KeyValuePair<int, int>(i - 1, j + 1));
            }
        }

        /// <summary>
        /// Алгоритм Дейкстры
        /// </summary>
        /// <param name="start"></param>
        /// <returns></returns>
        public IList<double> GetShortestPath(int start)
        {
            List<double> distance = new List<double>();
            bool[] visited = new bool[n];
            for (int i = 0; i < n; i++)
            {
                distance.Add(double.MaxValue);
                visited[i] = false;
            }

            distance[start] = 0;
            int index = -1;
            for (int i = 0; i < n; i++)
            {
                double min = double.MaxValue;
                for (int j = 0; j < n; j++)
                {
                    if (!visited[j] && distance[j] <= min)
                    {
                        min = distance[j];
                        index = j;
                    }
                }

                visited[index] = true;
                for (int j = 0; j < n; j++)
                {
                    if (!visited[n] && list[index,j] > -1
                        && distance[index] != double.MaxValue
                        && distance[index] + list[index,j] < distance[j])
                    {
                        distance[j] = distance[index] + list[index, j];
                    }
                }
            }
            return distance;
        }
    }
}
