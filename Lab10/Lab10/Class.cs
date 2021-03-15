using System;
using System.Collections;
using System.Collections.Generic;
using System.Text;

namespace Lab10
{
    public class PO<T> : IList<T>
    {
        List<T> po;
        public PO()
        {
            po = new List<T>();
        }
        public int Count { get; }
        public bool IsReadOnly { get; }
        public T this[int index] { get { return this[index]; } set{ this[index] = value; } }

        public void Add(T item)
        {
            po.Add(item);
        }
        public void Clear()
        {
            po.Clear();
        }
        public bool Contains(T item)
        {
           return po.Contains(item);
        }
        public void CopyTo(T[] array, int arrayIndex)
        {
            po.CopyTo(array, arrayIndex);
        }
        public IEnumerator<T> GetEnumerator()
        {
            return po.GetEnumerator();
        }
        IEnumerator IEnumerable.GetEnumerator()
        {
            return GetEnumerator();
        }
        public int IndexOf(T item)
        {
            return po.IndexOf(item);
        }
        public void Insert(int index, T item)
        {
            po.Insert(index, item);
        }
        public bool Remove(T item)
        {
            return po.Remove(item);
        }
        public void RemoveAt(int index)
        {
            po.RemoveAt(index);
        }
        public void Show()
        {
            int i = 0;
            foreach (object el in this.po)
            {
                Console.WriteLine($"[{i}] {this.po} ");
                i++;
            }
        }
    }
    public class OwnCollection
    {
        public SortedList Collect;

        public OwnCollection()
        {
            Collect = new SortedList();
        }
        public OwnCollection(int arg)
        {
            Collect = new SortedList(arg);
        }
        
        public void Add(string arg1, string arg2)
        {
            Collect.Add(arg1, arg2);
        }
        public void RemoveAt(int arg1)
        {
            Collect.RemoveAt(arg1);
        }
        public object GetByIndex(int arg)
        {
            return Collect.GetByIndex(arg);
        }
        public object GetKey(int arg)
        {
            return Collect.GetKey(arg);
        }
        public void Show()
        {int i= 0;
            foreach (object el in this.Collect)
            {
                Console.WriteLine($"[{i}][{this.Collect.GetKey(i)}]{this.Collect.GetByIndex(i)} ");
                    i++; 
            }
        }
    }

}
