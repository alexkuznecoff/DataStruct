using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DataStruct.Lib
{
    class Queue
    {
        private LinkedList _linkedList = new LinkedList();

        public Node First  { get; set; }

        public Node Last { get; set; }

        public int Count { get => _linkedList.Count; }
        
        /// <summary>
        /// Put / Add
        /// </summary>
        public void Enqueue(object data)
        {
            _linkedList.Add(data);
        }

        /// <summary>
        /// To take / Remove
        /// </summary>
        public object Dequeue()
        {
            object result = _linkedList.Last.Data;
            _linkedList.RemoveFirst();
            return result;
        }

        public void Clear() => _linkedList.Clear();

        public bool Contains(object data) => _linkedList.Contains(data);

        public object Peek() => _linkedList.Last.Data;

        public object[] ToArray() => _linkedList.ToArray();
     
    }

    
}
