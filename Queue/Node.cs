using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Queue
{
    class Node<T>
    {
        public Node(T data, int priority)
        {
            Data = data;
            Priority = priority;
        }

        public int Priority { get; internal set; }
        public Node<T> Next { get; internal set; }
        public Node<T> Previous { get; internal set; }
        public T Data { get; internal set; }
    }
}
