using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DataStruct.Lib
{
    public interface ICollectionsDataStruct<T>
    {
        void Add(T item);
        void Remove(T item);
        void Clear();
        bool Contains(T item);
        T[] ToArray();
    }
}
