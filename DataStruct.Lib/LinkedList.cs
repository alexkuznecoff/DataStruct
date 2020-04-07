using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DataStruct.Lib
{
    public class LinkedList<T> : ICollectionsDataStruct<T>, IEnumerable<T>
    {
        public int Count { get; set; }
        public Node<T> First { get; set; }
        public Node<T> Last { get; set; }

        public void Add(T data)
        {
            Node<T> node = new Node<T>(data);
            if (First == null)
            {
                First = node;
                Last = node;
            }
            else
            {
                Last.Next = node;
                Last = node;
            }
            Count++;
        }

        public void AddFirst(T data)
        {
            Node<T> node = new Node<T>(data);

            if (First == null)
            {
                First = node;
                Last = node;
            }
            node.Next = First;
            First = node;
            Count++;
        }

        public void Insert(Node<T> node, T data)
        {
            var currentNode = First;

            do
            {
                if (currentNode == node
                    && data is Node<T> newNode)
                {
                    newNode.Next = currentNode.Next;
                    currentNode.Next = newNode.Next;
                    Count++;
                    break;
                }
                currentNode = currentNode.Next;

            } while (currentNode != null);
        }

        public void Clear()
        {
            Node<T> current = First;
            Count = 0;
            do
            {
                if (current.Next != null)
                {
                    Node<T> tempCurrent = current.Next;
                    current.Next = null;
                    current = tempCurrent;

                }

            }
            while (current != null);
            First = null;
            Last = null;

        }

        public bool Contains(T data)
        {
            Node<T> current = First;

            while (current != null)
            {
                if (current.Data.Equals(data))
                    return true;

                current = current.Next;
            }
            return false;
        }

        public T[] ToArray()
        {
            T[] array = new T[Count];
            Node<T> current = First;
            int index = 0;

            while (current != null)
            {
                array[index] = current.Data;
                index++;
                current = current.Next;
            }

            return array;
        }

        public bool Remove(T data)
        {
            Node<T> current = First;
            Node<T> previous = null;

            while (current != null)
            {
                if (current.Data.Equals(data))
                {
                    if (previous != null)
                    {
                        previous.Next = current.Next;

                        if (current.Next == null)
                            Last = previous;
                    }
                    else
                    {
                        First = First.Next;

                        if (First == null)
                            Last = null;
                    }
                    Count--;
                    return true;
                }
                previous = current;
                current = current.Next;
            }
            return false;
        }

        public void RemoveFirst()
        {
            var tmp = First.Next;
            First = null;
            Node<T> newFirst = tmp;
            First = newFirst;
        }

        public IEnumerator<T> GetEnumerator()
        {
            for (Node<T> current = First; current != null; current = current.Next)
            {
                yield return current.Data;
            }
        }

        IEnumerator IEnumerable.GetEnumerator()
        {
            return GetEnumerator();
        }

        void ICollectionsDataStruct<T>.Remove(T item)
        {
            throw new NotImplementedException();
        }
    }

    public class Node<T>
    {
        public Node<T> Next { get; set; }
        public T Data { get; set; }

        public Node(T data)
        {
            Data = data;
        }
    }
}
