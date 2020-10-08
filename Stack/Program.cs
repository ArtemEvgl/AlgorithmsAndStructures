using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Stack
{
    class Program
    {
        static void Main(string[] args)
        {
            Stack<int> stack= new Stack<int>();
            stack.Push(1);
            stack.Push(12);
            stack.Push(110);

            Console.WriteLine(stack.Pop());
            Console.WriteLine(stack.Peek());
            Console.WriteLine(stack.Peek());
            Console.ReadKey();
        }
    }
}
