using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DataStruct.Lib
{
    public class List<T> : ICollectionsDataStruct<T>,IEnumerable<T>
    {

        private int _index;
        private int _capasity = 4;
        private T[] _array;

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
            _array = new T[_capasity];
        }

        /// <summary>
        /// clone and resize to array
        /// </summary>
        private void ReSize()
        {
            T[] tempArr = _array;
            _array = new T[_capasity];

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
        public void Add(T item)
        {
            if (_index == _capasity)
            {
                _capasity *= 2;
                ReSize();
            }

            _array[_index] = item;
            _index++;
        }

        public T this[int index]
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

        public void Insert(int index, T item)
        {
            T[] tempArray = new T[_array.Length + 1];

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

        public int IndexOf(T item)
        {
            for (int i = 0; i < _array.Length; i++)
            {
                if (_array[i].Equals(item))
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
        public void Remove(T item)
        {
            int index = IndexOf(item);

            if (index >= 0)
                RemoveAt(index);
        }

        public void Clear()
        {
            InitArray();
        }

        public bool Contains(T item)
        {
            for (int i = 0; i < _array.Length; i++)
            {
                if (_array[i].Equals(item))
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
                T temp = _array[i];
                _array[i] = _array[end - i];
                _array[end - i] = temp;
            }
        }

        public T[] ToArray()
        {
            T[] result = new T[Count];

            for (int i = 0; i < Count; i++)
            {
                result[i] = _array[i];
            }
            return result;
        }

        public void Reset() => _index = -1;

        public IEnumerator<T> GetEnumerator()
        {
            for (int i = 0; i < Count; i++)
            {
                yield return _array[i];
            }
        }

        IEnumerator IEnumerable.GetEnumerator()
        {
            return GetEnumerator();
        }
    }
}
