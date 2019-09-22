using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SAOD1
{
    public class List<T> where T : IComparable
    {
        private int _size = 0;
        private Node<T> _head;

        public void Add(T value)
        {
            if (_size == 0)
            {
                _head = new Node<T>(value);
            } else if (_size == 1) {
                _head.next = new Node<T>(value);
            }
            else
            {
                Node<T> n = _head;
                for (; n.next != null; n = n.next);
                
                n.next = new Node<T>(value);
                //n = n.next;
            }
            _size++;
        }

        public void Add(T value, int pos)
        {
            if (pos > _size) throw new SystemException("OutOfBounds");
            if (pos == _size) Add(value);
            else if (pos == 0)
            {
                Node<T> newNode = new Node<T>(value);
                newNode.next = _head;
                _head = newNode;
                _size++;
            }
            else
            {
                Node<T> n = _head;
                for (int i = 0; i < pos; i++) n = n.next;
                Node<T> newNode = new Node<T>(value);
                newNode.next = n.next;
                n.next = newNode;
                _size++;
            }
        }

        public T Get (int pos)
        {
            if (pos >= _size) throw new SystemException("OutOfBounds");

            Node<T> n = _head;
            for (int i = 0; i != pos; i++) n = n.next;
            return n.value;
        }

        public int GetSize()
        {
            return _size;
        }
    }

    class Node <T> where T : IComparable
    {
        public T value;
        public Node<T> next = null;

        public Node(T value)
        {
            this.value = value;
            this.next = null;
        }
    }
}
