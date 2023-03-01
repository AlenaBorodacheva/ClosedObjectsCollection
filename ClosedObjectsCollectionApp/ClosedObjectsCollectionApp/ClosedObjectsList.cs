using System.Collections;
using ClosedObjectsCollectionApp.Interfaces;

namespace ClosedObjectsCollectionApp
{
    public class ClosedObjectsList<T> : IClosedList<T>
    {
        public T Head => _headNode.Data;
        public T Current => GetNodeByIndex(_currentIndex).Data;
        public T Previous => GetNodeByIndex(_currentIndex).Previous.Data;
        public T Next => GetNodeByIndex(_currentIndex).Next.Data;
        public event EventHandler<T>? HeadReached;
        public int Count { get; private set; }
        public bool IsReadOnly { get; }
        
        public T this[int index]
        {
            get => GetNodeByIndex(index).Data;
            set => GetNodeByIndex(index).Data = value;
        }
        
        private Node<T>? _headNode;
        private int _currentIndex;

        public IEnumerator<T> GetEnumerator()
        {
            if (_headNode == null)
                throw new ArgumentNullException();
            Node<T> current = _headNode;
            do
            {
                if (current != null)
                {
                    yield return current.Data;
                    current = current.Next;
                }
            }
            while (current != _headNode);
        }

        IEnumerator IEnumerable.GetEnumerator()
        {
            return GetEnumerator();
        }

        public void Add(T item)
        {
            if(item == null)
                throw new ArgumentNullException();
            var node = new Node<T>(item);
            if (_headNode == null)
            {
                _headNode = node;
                _headNode.Next = node;
                _headNode.Previous = node;
            }
            else
            {
                node.Previous = _headNode.Previous;
                node.Next = _headNode;
                _headNode.Previous.Next = node;
                _headNode.Previous = node;
            }
            Count++;
        }

        public bool Remove(T item)
        {
            if (item == null)
                throw new ArgumentNullException();
            if (_headNode == null)
                return false;
            Node<T> removedItem = null;
            int index = 0;
            var current = _headNode;
            do
            {
                if (current.Data.Equals(item))
                {
                    removedItem = current;
                    break;
                }
                current = current.Next;
                index++;
            }
            while (current != _headNode);
            
            if (removedItem == null) return false;
            
            if (Count == 1)
                _headNode = null;
            else
            {
                if (removedItem == _headNode)
                {
                    _headNode = _headNode.Next;
                }
                removedItem.Previous.Next = removedItem.Next;
                removedItem.Next.Previous = removedItem.Previous;
            }
            Count--;
            if (index <= _currentIndex)
                _currentIndex--;
            return true;
        }

        public void RemoveAt(int index)
        {
            if (index >= Count) throw new ArgumentOutOfRangeException();
            var current = _headNode;
            var currentNode = GetNodeByIndex(_currentIndex);
            for (int i = 0; i < index; i++)
                current = _headNode.Next;

            if (index == 0)
            {
                if (currentNode == _headNode)
                    currentNode = _headNode.Next;
                _headNode = _headNode.Next;
            }
            if (current == currentNode)
                current = current.Next;
            current.Next.Previous = current.Previous;
            current.Previous.Next = current.Next;
            Count--;
            if(index <= _currentIndex)
                _currentIndex--;
        }

        public void Clear()
        {
            _headNode = null;
            Count = 0;
            _currentIndex = 0;
        }

        public bool Contains(T item)
        {
            if (item == null)
                throw new ArgumentNullException();
            if (_headNode == null) return false;
            Node<T> current = _headNode;
            do
            {
                if (current.Data.Equals(item))
                    return true;
                current = current.Next;
            }
            while (current != _headNode);
            return false;
        }

        public void CopyTo(T[] array, int arrayIndex)
        {
            for (int i = 0; i < Count; i++)
            {
                array.SetValue(this[i], arrayIndex++);
            }
        }

        public int IndexOf(T item)
        {
            if (item == null)
                throw new ArgumentNullException();
            if (_headNode == null) return -1;
            var current = _headNode;
            int count = 0;
            do
            {
                if (item.Equals(current.Data))
                    return count;
                current = current.Next;
                count++;
            }
            while (current != _headNode);

            return -1;
        }

        public void Insert(int index, T item)
        {
            if (index >= Count) throw new ArgumentOutOfRangeException();
            var node = new Node<T>(item);
            var current = _headNode;
            for (int i = 0; i < index; i++)
                current = current.Next;
            node.Next = current;
            node.Previous = current.Previous;
            current.Previous.Next = node;
            current.Previous = node;
            if (index == 0) _headNode = current;
            Count++;
            if (index <= _currentIndex)
                _currentIndex--;
        }

        public void MoveNext(int step = 1)
        {
            if (Count == 0 || step == 0) return;

            if (step < 0)
            {
                MoveBack(-step);
                return;
            }
            var current = GetNodeByIndex(_currentIndex);
            for (int i = 0; i < step; i++)
            {
                current = current.Next;
                _currentIndex++;
                if (current.Equals(_headNode))
                    HeadReached?.Invoke(this, Head);
            }
        }

        public void MoveBack(int step = 1)
        {
            if (Count == 0 || step == 0) return;

            if (step < 0)
            {
                MoveNext(-step);
                return;
            }
            var current = GetNodeByIndex(_currentIndex);
            for (int i = 0; i < step; i++)
            {
                current = current.Previous;
                _currentIndex--;
                if (current.Equals(_headNode))
                    HeadReached?.Invoke(this, Head);
            }
        }

        private Node<T> GetNodeByIndex(int index)
        {
            var current = _headNode;
            if(index > 0)
                for (int i = 0; i < index; i++)
                    current = current.Next;
            else if(index < 0)
                for (int i = 0; i < -index; i++)
                    current = current.Previous;
            return current;
        }
    }
}
