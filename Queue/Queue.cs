using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Queue
{
    class Queue<T> : IEnumerable<T>
    {
        Node<T> head;
        Node<T> tail;
        int count;

        public Queue()
        {
            head = tail = null;
            count = 0;
        }

        public void Enqueue(T item, int priority)
        {
            count++;
            Node<T> newItem = new Node<T>(item, priority);
            if (head == null)
            {
                tail = head = newItem;
            } else
            {
                Node<T> current = head;                
                while (current != null)
                {
                    if (current.Priority < newItem.Priority)
                    {
                        if(current == head)
                        {
                            head.Previous = newItem;
                            newItem.Next = head;
                            head = newItem;
                            return;
                        }
                        current.Previous.Next = newItem;
                        newItem.Next = current;
                        newItem.Previous = current.Previous;
                        current.Previous = newItem;
                        return;
                    }
                    current = current.Next;
                }
                tail.Next = newItem;
                tail.Next.Previous = tail;
                tail = tail.Next;
            }
            
        }

        public T DequeueFist()
        {
            if(head==null)
            {
                throw new InvalidOperationException("Queue is empty");
            }
            T result = head.Data;
            head = head.Next;
            count--;
            return result;
        }

        public T DequeueLast()
        {
            if(head == null)
            {
                throw new InvalidOperationException("Queue is empty");
            }
            T result = tail.Data;
            tail = tail.Previous;
            tail.Next = null;
            count--;
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

        public IEnumerator<T> GetEnumerator()
        {
            Node<T> node = head;
            while (node!=null)
            {
                yield return node.Data;
                node = node.Next;
            }
        }

        IEnumerator IEnumerable.GetEnumerator()
        {
            return this.GetEnumerator();
        }
    }
}
