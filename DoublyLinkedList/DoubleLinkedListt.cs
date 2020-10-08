using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DoublyLinkedList
{
    class DoubleLinkedListt<T> : IEnumerable<T>
    {
        LinkedListNode<T> head;
        LinkedListNode<T> tail;

        public int Count { get; private set; }

        public bool Contains(T item)
        {
            LinkedListNode<T> node = head;
            while (node != null)
            {
                if(node.Value.Equals(item))
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
            while (node!=null)
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

        public void AddFirst(T item)
        {
            LinkedListNode<T> node = new LinkedListNode<T>(item);
            LinkedListNode<T> temp = head;

            head = node;
            head.Next = temp;
            if(Count == 0)
            {
                tail = head;
            } else
            {
                temp.Previous = head;
            }
            Count++;

        }
        public void AddLast(T item)
        {
            LinkedListNode<T> node = new LinkedListNode<T>(item);
            if(Count == 0)
            {
                head = node;
            } else
            {
                tail.Next = node;
                node.Previous = tail;
            }
            tail = node;
        }

        public bool Remove(T item)
        {
            LinkedListNode<T> current = head;
            LinkedListNode<T> previous = null;

            while(current != null)
            {
                if(current.Value.Equals(item))
                {
                    if(previous != null)
                    {
                        
                        previous.Next = current.Next;
                        
                        if(current.Next == null)
                        {
                            tail = previous;
                        } else
                        {
                            current.Next.Previous = previous;
                        }
                        Count--;
                    } else
                    {
                        RemoveFirst();
                    }
                    return true;
                } 
                
                previous = current;
                current = current.Next;
                
            }
            return false;
        }

        public void RemoveFirst()
        {
            if(Count != 0)
            {
                head = head.Next;
                Count--;
                if(Count == 0)
                {
                    tail = null;                   
                } else
                {
                    head.Previous = null;
                }
                
            }
        }

        public void RemoveLast()
        {
            if (Count != 0)
            {
                tail = tail.Previous;
                Count--;
                if(Count == 0)
                {
                    head = null;
                } else
                {
                    tail.Next = null;
                }
            }
        }

    }

    class Program
    {
        public static void Display(LinkedList<int> words, string test)
        {
            Console.WriteLine();
            Console.WriteLine(test);
            foreach (int word in words)
            {
                Console.Write(word + " ");
            }
            Console.WriteLine();
            Console.WriteLine();
        }
        static void Main(string[] args)
        {
            
            LinkedList<int> instance = new LinkedList<int> { };

            instance.AddFirst(5);
            instance.AddFirst(3);
            instance.AddLast(7);

            Display(instance, "Doubly linked list");

            #region Удаление элемента из списка

            instance.Remove(5);

            Display(instance, "Doubly linked list");

            #endregion

            #region Определение пренадлежит ли элемент списку

            Console.WriteLine(instance.Contains(3));

            #endregion

            #region Копирование списка в массив

            Console.WriteLine("Копирование списка в массив");

            int[] arr = new int[5];

            instance.CopyTo(arr, 1);

            for (int i = 0; i < arr.Length; i++)
            {
                Console.WriteLine(arr[i]);
            }
            #endregion

            #region Удаление последнего элемента из списка

            instance.RemoveLast();

            Display(instance, "Remove Last Element");

            #endregion

            #region Удаление списка

            instance.Clear();

            Display(instance, "List is clear");

            #endregion
            Console.ReadKey();
        }
    }
}
