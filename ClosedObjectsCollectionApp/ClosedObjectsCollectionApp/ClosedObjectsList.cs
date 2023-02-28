﻿using System.Collections;
using ClosedObjectsCollectionApp.Interfaces;

namespace ClosedObjectsCollectionApp
{
    public class ClosedObjectsList<T> : IClosedList<T>
    {
        public IEnumerator<T> GetEnumerator()
        {
            throw new NotImplementedException();
        }

        IEnumerator IEnumerable.GetEnumerator()
        {
            return GetEnumerator();
        }

        public void Add(T item)
        {
            throw new NotImplementedException();
        }

        public void Clear()
        {
            throw new NotImplementedException();
        }

        public bool Contains(T item)
        {
            throw new NotImplementedException();
        }

        public void CopyTo(T[] array, int arrayIndex)
        {
            throw new NotImplementedException();
        }

        public bool Remove(T item)
        {
            throw new NotImplementedException();
        }

        public int Count { get; }
        public bool IsReadOnly { get; }
        public int IndexOf(T item)
        {
            throw new NotImplementedException();
        }

        public void Insert(int index, T item)
        {
            throw new NotImplementedException();
        }

        public void RemoveAt(int index)
        {
            throw new NotImplementedException();
        }

        public T this[int index]
        {
            get => throw new NotImplementedException();
            set => throw new NotImplementedException();
        }

        public void MoveNext(int step = 1)
        {
            throw new NotImplementedException();
        }

        public void MoveBack(int step = 1)
        {
            throw new NotImplementedException();
        }

        public T Head { get; }
        public T Current { get; }
        public T Previous { get; }
        public T Next { get; }
        public event EventHandler<T>? HeadReached;
    }
}
