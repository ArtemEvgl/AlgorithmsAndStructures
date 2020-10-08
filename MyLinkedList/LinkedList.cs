using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MyLinkedList
{
    class LinkedList<T> : IEnumerable<T>
    {
        LinkedListNode<T> head;
        LinkedListNode<T> tail;

        public int Count { get; private set; }

        public void Add(T item)
        {
            LinkedListNode<T> node = new LinkedListNode<T>(item);
            if(head == null)
            {
                head = node;
                tail = node;
            }else
            {
                tail.Next = node;
                tail = node;
            }
            Count++;
        }

        public bool Remove(T item)
        {
            LinkedListNode<T> current = head;
            LinkedListNode<T> previous = null;

            while (current != null)
            {
                if(current.Value.Equals(item))
                {
                    if(previous == null)
                    {
                        head = head.Next;
                        if(head == null)
                        {
                            tail = null;
                        }
                    }else
                    {
                        previous.Next = current.Next;
                        if(current.Next == null)
                        {
                            tail = previous;
                        }
                    }
                    Count--;
                    return true;

                } else
                {
                    previous = current;
                    current = current.Next;
                }
                
            }
            return false;
        }

        public bool Contains(T item)
        {
            LinkedListNode<T> node = head;
            while (node != null)
            {
                if(node.Value.Equals(node))
                {
                    return true;
                }
                node = node.Next;
            }
            return false;
        }

        public IEnumerator<T> GetEnumerator()
        {
            LinkedListNode<T> node = head;
            while(node != null)
            {
                yield return node.Value;
                node = node.Next;
            }
        }

        IEnumerator IEnumerable.GetEnumerator()
        {
            return this.GetEnumerator();
        }
        public void Clear()
        {
            head = null;
            tail = null;
            Count = 0;
        }

        public void CopyTo(T[] array, int arrayIndex)
        {
            LinkedListNode<T> node = head;
            while (node != null)
            {
                array[arrayIndex++] = node.Value;
                node = node.Next;
            }

        } 
    }

    class Program
    {
        
        public static void Display(LinkedList<int> numbers, string text)
        {
            Console.WriteLine(text);
            foreach (var number in numbers)
            {
                Console.WriteLine(number);
            }
            Console.WriteLine(new string('=', 20));

        }

        static void Main(string[] args)
        {
            LinkedList<int> instance = new LinkedList<int> { };
            instance.Add(12);
            instance.Add(15);
            instance.Add(20);
            instance.Add(25);
            Display(instance, "List");

            instance.Remove(20);
            Display(instance, "20 was removed");

            Console.WriteLine("Копирование списка в массив");
            int[] arr = new int[5];
            instance.CopyTo(arr, 2);
            for (int i = 0; i < arr.Length; i++)
            {
                Console.WriteLine(arr[i]);
            }

            instance.Clear();
            Display(instance, "List is clear");
            
            Console.ReadKey();


        }
    }
}
