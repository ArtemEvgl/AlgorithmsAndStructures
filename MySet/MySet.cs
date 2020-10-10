using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MySet
{
    class MySet<T> : IEnumerable<T> where T : IComparable<T>
    {

        private readonly List<T> list = new List<T>();

        public MySet()
        {

        }

        public MySet(IEnumerable<T> items)
        {
            AddRange(items);
        }
        public int Count { get { return list.Count; } }

        public void Add(T item)
        {
            if(!list.Contains(item))
            {
                list.Add(item);
            } else
            {
                throw new InvalidOperationException("Такое значение уже существует");
            }
        }

        public void AddRange(IEnumerable<T> items)
        {
            foreach (T item in items)
            {
                Add(item);
            }
        }

        public bool Contains(T item)
        {
            return list.Contains(item);
        }

        public MySet<T> Union (MySet<T> otherSet)
        {
            MySet<T> result = new MySet<T>(list);
            foreach (var item in otherSet)
            {
                if (!result.Contains(item))
                {
                    result.Add(item);
                }
            }            
            return result;
        }

        public bool Remove(T item)
        {
            return list.Remove(item);
        }

        public MySet<T> Intersection(MySet<T> otherSet)
        {
            MySet<T> result = new MySet<T>();
            foreach (var item in list)
            {
                if(otherSet.Contains(item))
                {
                    result.Add(item);
                }
            }
            return result;
        }

        public MySet<T> Difference(MySet<T> otherSet)
        {
            MySet<T> result = new MySet<T>(list);
            foreach (var item in otherSet)
            {
                if (result.Contains(item))
                {
                    result.Remove(item);
                }
            }
            return result;
        }

        public MySet<T> SymDifference(MySet<T> otherSet)
        {
            MySet<T> thisSet = new MySet<T>(list);
            var union = thisSet.Union(otherSet);
            var intersection = thisSet.Intersection(otherSet);
            return union.Difference(intersection);
        }

        public bool IsSubset(MySet<T> otherSet)
        {
            bool result = true;
            foreach (var item in list)
            {
                if (!otherSet.Contains(item))
                {
                    result = false;
                    break;
                }
            }
            return result;
        }

        public IEnumerator<T> GetEnumerator()
        {
            return list.GetEnumerator();
        }

        IEnumerator IEnumerable.GetEnumerator()
        {
            return this.GetEnumerator();
        }
    }
}
