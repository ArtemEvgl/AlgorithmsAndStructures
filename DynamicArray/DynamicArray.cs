using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DynamicArray
{
    class DynamicArray<T> : IEnumerable<T>
    {
        T[] array;

        public int Count { get; private set; }

        public DynamicArray() : this(4)
        {

        }
        public DynamicArray(int size)
        {
            array = new T[size];
            Count = 0;
        }

        private void Resize()
        {
            int capacity = array.Length == 0 ? 4 : array.Length * 2;
            T[] newArray = new T[capacity];

            array.CopyTo(newArray, 0);
            array = newArray;
        }

        public bool isFull()
        {
            return Count == array.Length;
        }

        public void Add(T item)
        {
            if (this.isFull())
                this.Resize();
            array[Count++] = item;
        }

        public void Insert(T item, int index)
        {
            if (this.isFull())
                this.Resize();

            Array.Copy(array, index, array, index + 1, array.Length - Count);
            array[index] = item;
            Count++;
        }

        public void RemoveAt(int index)
        {
            int shiftStart = index + 1;
            if(index < Count)
            {
                Array.Copy(array, shiftStart, array, index, Count - shiftStart);
            }
            Count--;
            array[Count] = default(T); 
        }

        public bool Remove(T item)
        {
            for (int i = 0; i < array.Length; i++)
            {
                if (array[i].Equals(item))
                {
                    RemoveAt(i);
                    return true;
                }
            }
            return false;
        }

        public IEnumerator<T> GetEnumerator()
        {
            for (int i = 0; i < array.Length; i++)
            {
                yield return array[i];
            }
        }

        IEnumerator IEnumerable.GetEnumerator()
        {
            return this.GetEnumerator();
        }

        public int IndexOf(T item)
        {
            for (int i = 0; i < array.Length; i++)
            {
                if(array[i].Equals(item))
                {
                    return i;
                }
            }
            return -1;
        }

        public bool Contains(T item)
        {
            return IndexOf(item) != -1;
        }
    }
}
