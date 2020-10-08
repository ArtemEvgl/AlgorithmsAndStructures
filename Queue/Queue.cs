using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Queue
{
    class Queue<T>
    {
        Node<T> head;
        Node<T> tail;
        int count;

        public Queue()
        {
            head = tail = null;
            count = 0;
        }

        public void Enqueue(T item)
        {
            if(head == null)
            {
                tail = head = new Node<T>(item, null);
            } else
            {
                tail.Next = new Node<T>(item, null);
                tail = tail.Next;
            }
        }

        public T Dequeue()
        {
            if(head==null)
            {
                return default(T);
            }
            T result = head.Data;
            head = head.Next;
            return result;
        }

        public T Peek()
        {
            if (head == null)
            {
                return default(T);
            }
            return head.Data;
        }

    }
}
