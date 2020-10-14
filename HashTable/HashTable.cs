using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace HashTable
{
    class HashTable<TKey, TValue>
    {
        private LinkedList<HashTableItem<TKey, TValue>>[] array;
        private int size;
        private int capacity;
        private const double LOAD_FACTOR = 0.75;

        public HashTable(int capacity)
        {
            this.capacity = capacity;
            array = new LinkedList<HashTableItem<TKey, TValue>>[capacity];
        }

        private int Hash(TKey key)
        {
            return Math.Abs(key.GetHashCode()) % capacity;
        }
        private double GetLoadFactory()
        {
            return size / capacity;
        }

        private void Resize()
        {
            this.capacity = this.capacity * 2;
            var oldArr = array;
            size = 0;
            array = new LinkedList<HashTableItem<TKey, TValue>>[capacity];

            foreach (var list in oldArr)
            {
                if (list != null)
                {
                    foreach (var item in list)
                    {
                        if(item != null)
                            this.Add(item.Key, item.Value);
                    }
                }
                
            }
        }
        
        public void Add(TKey key, TValue value)
        {
            if(GetLoadFactory() > LOAD_FACTOR)
            {
                this.Resize();
            }
            int index = Hash(key);
            if (array[index] == null)
                array[index] = new LinkedList<HashTableItem<TKey, TValue>>();

            var hashTableItem = new HashTableItem<TKey, TValue>(key, value);
            var node = new LinkedListNode<HashTableItem<TKey, TValue>>(hashTableItem);
            foreach (var item in array[index])
            {
                if(item.Key.Equals(key))
                {
                    throw new InvalidOperationException("Значение с заданным ключем уже существует");
                }
            }
            array[index].AddFirst(node);
            size++;

        }

        public bool Remove(TKey key)
        {
            int index = Hash(key);
            if(array[index] == null)
            {
                return false;
            }
            var list = array[index];
            foreach (var item in list)
            {
                if(item.Key.Equals(key))
                {
                    list.Remove(item);
                }
            }
            size--;
            return true;
        }

        public TValue GetValue(TKey key)
        {
            int index = Hash(key);
            if(array[index] == null)
            {
                throw new InvalidOperationException("Ключ не найден");
            }
            var list = array[index];
            foreach (var item in list)
            {
                if (item.Key.Equals(key))
                {
                    return item.Value;
                }
            }
            throw new InvalidOperationException("Ключ не найден");
        }

        public void Clear()
        {
            size = 0;
            array = new LinkedList<HashTableItem<TKey, TValue>>[capacity];
        }


    }
}
