using System;
using System.Collections.Generic;
using System.Linq;
using System.Security.Cryptography.X509Certificates;
using System.Security.Principal;
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

        public List<int> DFSNoRecursive(int from)
        {
            List<int> result = new List<int>();
            bool[] visited = new bool[n];
            Stack<int> stack = new Stack<int>();
            stack.Push(from);
            visited[from] = true;
            while (stack.Count > 0)
            {
                int index = stack.Pop();
                result.Add(index);
                for (int i = 0; i < n; i++)
                {
                    if (list[index, i] != 0 && !visited[i])
                    {
                        visited[i] = true;
                        stack.Push(i);
                    }
                }
            }
            return result;
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

        /// <summary>
        /// Алгоритм Уолшера
        /// </summary>
        /// <returns>Возвращает все кратчайшие пути</returns>
        public double[,] GetAllShortestPath()
        {
            double[,] distances = new double[n, n];
            for (int i = 0; i < n; i++)
            {
                for (int j = 0; j < n; j++)
                {
                    distances[i, j] = list[i, j];
                }
            }
            for (int k = 0; k < n; k++)
            {
                for (int i = 0; i < n; i++)
                {
                    for (int j = 0; j < n; j++)
                    {
                        if (distances[i,k] != 0 && distances[k,j] != 0 && i != j)
                        {
                            if (distances[i, k] + distances[k, j] < distances[i, j] || distances[i, j] == 0)
                            {
                                distances[i, j] = distances[i, k] + distances[k, j];
                            }
                        }
                    }
                }
            }
            return distances;
        }

        public IDictionary<int, IList<int>> GetComponents()
        {
            int color = 1;
            Dictionary<int, IList<int>> table = new Dictionary<int, IList<int>>();

            int count = n;
            bool[] visited = new bool[n];
            int[] colors = new int[n];

            while (count > 0)
            {
                int vertex = 0;
                while (visited[vertex]) vertex++;

                var vertices = DFSNoRecursive(vertex);
                foreach (var item in vertices)
                {
                    visited[item] = true;
                    colors[item] = 1;
                }
                count -= vertices.Count;

                table.Add(color, vertices);
                color++;
            }
            return table;
        }

        enum Colors
        {
            WHITE, BLACK, GREY
        };

        public IList<int> TopologicSort()
        {
            Stack<int> result = new Stack<int>();
            Colors[] colors = new Colors[n];
            Stack<int> path = new Stack<int>();

            for (int i = 0; i < n; i++)
            {
                int vertex = i;
                int saved = i;
                if (path.Count > 0)
                {
                    i--;
                    vertex = path.Pop();
                    saved = vertex;
                }

                if (colors[vertex] == Colors.BLACK)
                {
                    continue;
                }

                colors[vertex] = Colors.GREY;
                path.Push(vertex);
                for (int j = 0; j < n; j++)
                {
                    if (list[vertex,j] != 0 && colors[j] != Colors.BLACK)
                    {
                        if (colors[j] == Colors.GREY)
                        {
                            return null;
                        }

                        vertex = j;
                        path.Push(vertex);
                        break;
                    }
                }
                if (vertex == saved)
                {
                    colors[vertex] = Colors.BLACK;
                    result.Push(vertex);
                    path.Pop();
                }
            }
            return result.ToList();
        }

        public static double[,] GetMatrix(int tasks, int connections, double[] numbers)
        {
            double[,] result = new double[tasks, tasks];
            for (int i = 2; i <= numbers.Length; i+=2)
            {
                result[(int)numbers[i - 2] - 1, (int)numbers[i - 1] - 1] = 1;
            }
            return result;
        }
    }
}
