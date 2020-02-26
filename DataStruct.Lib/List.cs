using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DataStruct.Lib
{
    public class List
    {

        private int _index;
        private int _capasity = 4;
        private object[] _array;

        public int Count
        {
            get
            {
                return _index;
            }
        }

        public List(int capasity)
        {
            _capasity = capasity;
            InitArray();
        }

        public List()
        {
            InitArray();
        }

        private void InitArray()
        {
            _array = new object[_capasity];
        }

        /// <summary>
        /// clone and resize to array
        /// </summary>
        private void ReSize()
        {
            object[] tempArr = _array;
            _array = new object[_capasity];

            if (tempArr != null)
            {
                for (int i = 0; i < tempArr.Length; i++)
                {
                    _array[i] = tempArr[i];
                }
            }
        }

        public object First()
        {
            return _array[0];
        }

        public object Last()
        {
            return _array[Count - 1];
        }

        /// <summary>
        /// add new obj to array
        /// </summary>
        /// <param name="item">new obj to array</param>
        public void Add(object item)
        {
            if (_index == _capasity)
            {
                _capasity *= 2;
                ReSize();
            }

            _array[_index] = item;
            _index++;
        }

        public object this[int index]
        {
            get
            {
                return _array[index];

            }
            set
            {
                _array[index] = value;
            }
        }

        public void Insert(int index, object item)
        {
            object[] tempArray = new object[_array.Length + 1];

            for (int i = 0; i < index; i++)
            {
                tempArray[i] = _array[i];
            }

            for (int i = index; i < _array.Length; i++)
            {
                tempArray[i + 1] = _array[i];
            }
            tempArray[index] = item;

            if (_array.Length < tempArray.Length)
            {
                _capasity *= 2;
                ReSize();
            }
            _array = tempArray;
            index++;
        }

        public int IndexOf(object item)
        {
            for (int i = 0; i < _array.Length; i++)
            {
                if (item == _array[i])
                    return i;
            }

            return -1;
        }

        /// <summary>
        /// Index removal
        /// </summary>
        /// <param name="index">Index removal</param>
        public void RemoveAt(int index)
        {
            if (index < 0)
                return;

            for (int i = index; i < _array.Length; i++)
            {
                _array[i] = _array[i + 1];
            }
            _index--;
        }

        /// <summary>
        /// Removal by elyment
        /// </summary>
        /// <param name="item">Removal by elyment</param>
        public void Remove(object item)
        {
            int index = IndexOf(item);

            if (index >= 0)
                RemoveAt(index);
        }

        public void Clear()
        {
            InitArray();
        }

        public bool Contains(object item)
        {
            for (int i = 0; i < _array.Length; i++)
            {
                if (item == _array[i])
                {
                    return true;
                }
            }
            return false;
        }

        public void Reverse()
        {

            var end = Count - 1;

            for (int i = 0; i < Count / 2; i++)
            {
                object temp = _array[i];
                _array[i] = _array[end - i];
                _array[end - i] = temp;
            }
        }

        public object[] ToArray()
        {
            object[] result = new object[Count];

            for (int i = 0; i < Count; i++)
            {
                result[i] = _array[i];
            }
            return result;
        }

    }
}
