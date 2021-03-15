using System;
using System.Collections.Generic;
using System.Text;

namespace Lab_08
{
    interface ICollectionType<T>
    {
        public void Add(T arg);
        public void Delete(T arg);
        public void Show();
    }
    interface ITrial
    {
        bool IsPassed();
        int RaiseMark();
    }
}
