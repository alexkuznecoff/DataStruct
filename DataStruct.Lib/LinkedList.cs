using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DataStruct.Lib
{
    public class LinkedList
    {
        public int Count { get; set; }
        public Node First { get; set; }
        public Node Last { get; set; }

        public void Add(object data)
        {
            Node node = new Node(data);
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

        public void AddFirst(object data)
        {
            Node node = new Node(data);

            if (First == null)
            {
                First = node;
                Last = node;
            }
            node.Next = First;
            First = node;
            Count++;
        }

        public void Insert(Node node, object data)
        {
            var currentNode = First;

            do
            {
                if (currentNode == node
                    && data is Node newNode)
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
            Node current = First;
            Count = 0;
            do
            {
                if (current.Next != null)
                {
                    Node tempCurrent = current.Next;
                    current.Data = null;
                    current = tempCurrent;

                }

            }
            while (current != null);
            First = null;
            Last = null;

        }

        public bool Contains(object data)
        {
            Node current = First;

            while (current != null)
            {
                if (current.Data == data)
                    return true;

                current = current.Next;
            }
            return false;
        }

        public object[] ToArray()
        {
            object[] array = new object[Count];
            Node current = First;
            int index = 0;

            while (current != null)
            {
                array[index] = current.Data;
                index++;
                current = current.Next;
            }

            return array;
        }

        public bool Remove(object data)
        {
            Node current = First;
            Node previous = null;

            while (current != null)
            {
                if (current.Data == data)
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
            Node newFirst = tmp;
            First = newFirst;
        }

    }

    public class Node
    {
        public Node Next { get; set; }
        public object Data { get; set; }

        public Node(object data)
        {
            Data = data;
        }
    }
}
