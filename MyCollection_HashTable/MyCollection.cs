using System;
using System.Collections;
using System.Collections.Generic;
using ClassLibrary1;
using Laba12_2;

namespace MyCollection_HashTable
{
    public class MyCollection<T> : MyHashTable<T>, IEnumerable<T> where T : IInit, ICloneable, IComparable, new()
    {
        internal Point<T>? beg;

        public int Count { get; private set; }

        public MyCollection() : base()
        {
            Count = 0;
        }

        public MyCollection(int length) : base(length)
        {
            Count = 0;
            for (int i = 0; i < length; i++)
            {
                T item = new T();
                item.IRandomInit();
                AddPoint(item);
            }
        }

        public MyCollection(MyCollection<T> c) : base()
        {
            if (c == null)
                throw new ArgumentNullException(nameof(c));

            foreach (var item in c)
            {
                AddPoint((T)item.Clone());
            }
        }

        public IEnumerator<T> GetEnumerator()
        {
            Point<T>? current = beg;
            while (current != null)
            {
                yield return current.Data;
                current = current.Next;
            }
        }

        IEnumerator IEnumerable.GetEnumerator()
        {
            return GetEnumerator();
        }

        public new void AddPoint(T item)
        {
            base.AddPoint(item);
            Count++;
        }

        public new void PrintTable()
        {
            base.PrintTable();
        }

        public new bool RemoveData(T data)
        {
            bool result = base.RemoveData(data);
            if (result) Count--;
            return result;
        }

        public new bool Contains(T data)
        {
            return base.Contains(data);
        }

        public void CopyTo(T[] array, int arrayIndex)
        {
            if (array == null)
            {
                throw new ArgumentNullException(nameof(array));
            }
            if (arrayIndex < 0 || arrayIndex > array.Length)
            {
                throw new ArgumentOutOfRangeException(nameof(arrayIndex));
            }
            if (array.Length - arrayIndex < Count)
            {
                throw new ArgumentException("Недостаточно места в массиве.");
            }

            Point<T>? current = beg;
            while (current != null)
            {
                array[arrayIndex++] = current.Data;
                current = current.Next;
            }
        }
    }
}
