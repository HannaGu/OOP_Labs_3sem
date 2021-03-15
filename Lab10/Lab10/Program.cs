using System;
using System.Collections;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Collections.Specialized;
namespace Lab10
{
    class Program
    {
        static void Main(string[] args)
        {
            OwnCollection oc = new OwnCollection(3);
            oc.Add("key1", "value1");
            oc.Add("key2", "value2");
            oc.Add("key3", "value3");

            Console.Write(oc.GetByIndex(2));
            oc.Show();
            oc.RemoveAt(2);
            oc.Show();

            PO<int> po = new PO<int>();
            po.Add(125);
            po.Add(1);
            po.Add(-987);
            po.Add(37);

            for(int i=2; i<3;i++)
            {
                po.RemoveAt(i);
            }

            Dictionary<object,object> list = new Dictionary<object,object>(4);
            list.Add(oc.Collect.GetKey(0), oc.Collect.GetByIndex(0));
            list.Add(oc.Collect.GetKey(1), oc.Collect.GetByIndex(1));

            Console.Write(list.ToString());
            Console.Write("\n"+ list.ContainsValue("value1"));

            ObservableCollection<string> Col = new ObservableCollection<string>();
            Col.CollectionChanged += Changing;
            Col.Add("item1");
            Col.Add("item2");
            Col.Remove("item1");
            foreach (string item in Col)
            {
                Console.WriteLine(item.Length);
            }
        }
        private static void Changing(object sender, NotifyCollectionChangedEventArgs e)
        {
            if (e.Action == NotifyCollectionChangedAction.Add)
            {
                Console.WriteLine("Элемент добавлен ");
            }
            else if (e.Action == NotifyCollectionChangedAction.Remove)
            {
                Console.WriteLine("Элемент удален ");
            }
            else
            {
                Console.WriteLine("Нет добавленных/удаленных элементов");
            }
        }
    }
    
}
