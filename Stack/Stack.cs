using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Stack
{
    class Stack<T>
    {
        Node<T> top;

        public int Count { get; private set; }

        public Stack()
        {
            top = null;
            Count = 0;
        }

        public void Push(T item)
        {
            top = new Node<T>(item, top);
            Count++;
        }

        public T Pop()
        {
            T result = top.Data;
            top = top.Next;
            Count--;
            return result;
        }

        public T Peek()
        {
            return top.Data;
        }
    }
}
