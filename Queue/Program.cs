using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Queue
{
    class Program
    {
        static void Main(string[] args)
        {
            Queue<String> queue = new Queue<string>();

            queue.Enqueue("top", 3);
            queue.Enqueue("mid", 2);
            queue.Enqueue("low", 1);
            queue.Enqueue("mid2", 2);
            queue.Enqueue("top2", 3);
            queue.Enqueue("low2", 1);

            queue.DequeueFist();
            queue.DequeueFist();

            queue.Enqueue("top3", 3);
            foreach (var item in queue)
            {
                Console.WriteLine(item);
            }

            Console.ReadLine();
        }
    }
}
