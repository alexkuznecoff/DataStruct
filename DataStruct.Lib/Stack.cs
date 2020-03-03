using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DataStruct.Lib
{
    class Stack<T>
    {
        private LinkedList<T> _linkedList;

        public int Count { get => _linkedList.Count; }

        public Stack()
        {
            _linkedList = new LinkedList<T>();
        }

        public void Push(T data) => _linkedList.AddFirst(data);

        public object Pull()
        {
            object result = _linkedList.First.Data;
            _linkedList.RemoveFirst();
            return result;
        }

        public void Clear() => _linkedList.Clear();

        public object Peek() => _linkedList.First.Data;

        public bool Contains(T data) => _linkedList.Contains(data);

        public T[] ToArray() => _linkedList.ToArray();

    }
}
