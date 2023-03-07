using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Faith.Console6.IListTest
{
    public class SeqList<T> : IListFaith<T>
    {
        private T[] data;
        private int count;
        public T this[int index] => throw new NotImplementedException();

        public void Add(T item)
        {
            throw new NotImplementedException();
        }

        public void Clear()
        {
            throw new NotImplementedException();
        }

        public T GetElem(int i)
        {
            throw new NotImplementedException();
        }

        public int GetLenght()
        {
            throw new NotImplementedException();
        }

        public void Insert(T item, int i)
        {
            throw new NotImplementedException();
        }

        public bool isEmpty()
        {
            throw new NotImplementedException();
        }

        public int local(T value)
        {
            throw new NotImplementedException();
        }

        public T Remove(int i)
        {
            throw new NotImplementedException();
        }
    }
}
