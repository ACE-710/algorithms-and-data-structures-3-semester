using System;

namespace SAOD1
{
    public class MList<T> where T : IComparable
    {
        private int _size = 0;
        private Node<T> _head;

        public void Add(T value)
        {
            if (_size == 0)
            {
                _head = new Node<T>(value);
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
            var n = _head;
            var pos = 0;
            if (_head.Value.CompareTo(elem) == 0)
            {
                _head = n.Next;
                return;
            }

            for (; n != null; n = n.Next, pos++)
            {
                if (n.Value.CompareTo(elem) != 0) continue;
                _size--;
//                if (pos == _size - 1)
//                {
//                    // Заменить n на n.next и вынести head из тела цикла
//                    return;
//                }

                n = n.Next;
                break;
            }
        }

        public void RemoveByPos(int position)
        {
            var n = _head;
            var pos = 0;
            for (; n?.Next != null || pos != position; n = n.Next, pos++)
            {
                if (pos != position) continue;
                if (n != null) n.Next = n?.Next?.Next;
                _size--;
                break;
            }

            if (n?.Next == null) return;
            n.Next = n.Next.Next;
            _size--;
        }

        public void Clear()
        {
            _head = null;
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

    internal class Node<T> where T : IComparable
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