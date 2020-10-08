using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Queue
{
    class Node<T>
    {
        public Node(T data, Node<T> next)
        {
            Data = data;
            Next = next;
        }

        public Node<T> Next { get; internal set; }
        public T Data { get; internal set; }
    }
}
