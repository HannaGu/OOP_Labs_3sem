using System;
using System.Collections.Generic;
using System.Text;
using System.IO;

namespace Lab_08
{
    public class CollectionType<T>: ICollectionType<T>
    {
        List<T> Collect;
        int count = 1;
        public CollectionType()
        {
            Collect = new List<T>();
            count++;
        }

        public void Add(T arg)
        {
            if (Collect.Count > 3) throw new NewExceptions("Коллекция переполнена", "Overflow Exception");
            else { Collect.Add(arg); }
        }
        public void Delete(T arg)
        {
            bool v = Collect.Remove(arg);
            if (!v) throw new NewExceptions("Элемент не найден", "Delete Exception");
        }
        public void Show()
        {
            foreach (T el in Collect)
            {
                Console.Write(el.ToString() + "\n");
            }
        }

        public void WriteToFile(int index)          //запись в файл
        {
            string writePath = @"D:\СЕМ 3\ООТП\Lab_08\text.txt";
            using (StreamWriter sw = new StreamWriter(writePath, true, System.Text.Encoding.Default))
            {
                sw.WriteLine(this.Collect[index]);
            }
        }
        public void ReadFromFile()
        {
            string path = @"D:\СЕМ 3\ООТП\Lab_08\text.txt";
            using (StreamReader sr = new StreamReader(path))
            {
                Console.WriteLine(sr.ReadToEnd());
            }
        }
        public static CollectionType<T> operator +(CollectionType<T> CT1, CollectionType<T> CT2)
        {
                foreach(T el in CT2.Collect)
                {
                    CT1.Collect.Add(el);
                }
            return CT1;
        }
        public static bool operator <=(CollectionType<T> CT1, CollectionType<T> CT2)
        {
          if (CT1.Collect.Count <= CT2.Collect.Count) { return true; }
          else { return false; }
        }
        public static bool operator >=(CollectionType<T> CT1, CollectionType<T> CT2)
        {
            if (CT1.Collect.Count >= CT2.Collect.Count) { return true; }
            else { return false; }
        }

        public static T operator %(CollectionType<T> CT, int i)
        {
           return CT.Collect[i];
        }

        public static implicit operator int(CollectionType<T> CT) //неявное преобразование CT к int
        {
           return CT.Collect.Count;
        }
        public class Owner
        {
          string name;
          string organization;
          int id;
            public Owner()
            {
              this.name = "Anna";
              this.organization = "BSTU";
              this.id = 7;
            }
            public void ShowInfo()
            {
             Console.WriteLine($"\nИнформация о владельце: \nИмя: {this.name}\nОрганизация: {this.organization}\nID: {this.id}\n");
            }
        }
        public class Date
         {
           int day = 15;
           int month = 10;
           int year = 2019;
             public Date(int day, int month, int year)
             {
               this.day = day;
               this.month = month;
               this.year = year;
             }
             public void ShowDate()
             {
              Console.WriteLine($"Дата создания: {day}:{month}:{year}");
             }
        }
    }
    class CTInherit<T> where T : CollectionType<T>, new()
    {
        public CTInherit() : base() { }
    }
}
