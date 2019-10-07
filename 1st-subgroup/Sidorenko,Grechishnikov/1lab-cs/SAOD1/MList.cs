using System;

namespace SAOD1
{
    public class MList<T> where T : IComparable
    {
        private int _size;
        private Node<T> _head;
        private Iterator<T> _iterator;

        public Iterator<T> GetIterator()
        {
            return _iterator;
        }
        
        public void Add(T value)
        {
            if (_size == 0)
            {
                _head = new Node<T>(value);
                _iterator = new Iterator<T>(_head);
            }
            else
            {
                var n = _head;
                for (; n.Next != null; n = n.Next) ;

                n.Next = new Node<T>(value);
                //n = n.next;
            }

            _size++;
        }

        public void Add(T value, int pos)
        {
            if (pos > _size) throw new SystemException("OutOfBounds");
            if (pos == _size)
            {
                Add(value);
                return;
            }
            else if (pos == 0)
            {
                var newNode = new Node<T>(value) {Next = _head};
                _head = newNode;
            }
            else if (pos == 1)
            {
                var n = _head.Next;
                _head.Next = new Node<T>(value) {Next = n};
            }
            else
            {
                var n = _head;
                for (var i = 0; i < pos - 1; i++) n = n.Next;
                var newNode = new Node<T>(value) {Next = n.Next};
                n.Next = newNode;
            }

            _size++;
        }

        public T Get(int pos)
        {
            if (pos >= _size) throw new SystemException("OutOfBounds");

            var n = _head;
            for (var i = 0; i != pos; i++) n = n.Next;
            return n.Value;
        }

        public void Change(int pos, T value)
        {
            if (pos >= _size) throw new SystemException("OutOfBounds");

            var n = _head;
            for (var i = 0; i != pos; i++) n = n.Next;
            n.Value = value;
        }

        public bool Contains(T elem)
        {
            var n = _head;
            for (; n != null; n = n.Next)
            {
                if (n.Value.CompareTo(elem) == 0) return true;
            }

            return false;
        }

        public int IndexOf(T elem)
        {
            var n = _head;
            var pos = 0;
            for (; n != null; n = n.Next, pos++)
            {
                if (n.Value.CompareTo(elem) == 0) return pos;
            }

            return -1;
        }

        public void Remove(T elem)
        {
            var cur = _head;
            Node<T> prev = null;

            var pos = 0;
            if (_head.Value.CompareTo(elem) == 0)
            {
                _head = cur.Next;
                _iterator.SetHead(_head);
                _size--;
                return;
            }

            for (; cur != null; cur = cur.Next, pos++)
            {
                if (cur.Value.CompareTo(elem) != 0)
                {
                    prev = cur;
                    continue;
                }

                if (pos == _size - 1)
                {
                    prev.Next = null;
                    _size--;
                    return;
                }

                prev.Next = cur.Next;
                _size--;
                break;
            }
        }

        public void RemoveAt(int position)
        {
            var n = _head;
            var pos = 0;
            if (position == 0)
            {
                _head = _head.Next;
                _iterator.SetHead(_head);
                --_size;
                return;
            }

            for (; n?.Next != null || pos != position - 1; n = n.Next, pos++)
            {
                if (pos != position - 1) continue;
                if (n != null) n.Next = n.Next?.Next;
                _size--;
                return;
            }

            if (n?.Next == null) return;
            n.Next = n.Next.Next;
            _size--;
        }

        public void Clear()
        {
            _head = null;
            _iterator = null;
            _size = 0;
        }

        public bool IsEmpty()
        {
            return _size == 0;
        }

        public int GetSize()
        {
            return _size;
        }
    }

    public class Iterator<T> where T : IComparable
    {
        private Node<T> _curItem;
        private Node<T> _head;

        public Iterator(Node<T> value)
        {
            _head = value;
            _curItem = _head;
        }

        public void SetHead(Node<T> value)
        {
            if (_curItem == _head)
            {
                _head = value;
                _curItem = _head;
            }
            else
            {
                _head = value;
            }
        }
        
        public void Next()
        {
            if (_curItem.Next != null) _curItem = _curItem.Next;
        }

        public void ToStart()
        {
            _curItem = _head;
        }

        public T Get()
        {
            return _curItem.Value;
        }

        public void Set(T value)
        {
            _curItem.Value = value;
        }
    }

    public class Node<T> where T : IComparable
    {
        public T Value;
        public Node<T> Next;

        public Node(T value)
        {
            Value = value;
            Next = null;
        }
    }
}