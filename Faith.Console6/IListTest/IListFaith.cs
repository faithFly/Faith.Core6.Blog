using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Faith.Console6.IListTest
{
    public interface IListFaith<T>
    {
        int GetLenght();
        void Clear();
        bool isEmpty();
        void Add(T item);
        void Insert(T item, int i);
        T Remove(int i);
        T GetElem(int i);
        int local(T value);
        T this[int index] { get; }
    }
}
