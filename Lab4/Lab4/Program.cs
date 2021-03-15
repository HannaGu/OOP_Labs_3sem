using System;
using System.Diagnostics.Tracing;
using System.Runtime.CompilerServices;
using System.Runtime.InteropServices;
using System.Windows.Markup;

namespace Lab4
{
    class Set
    {
        int[] setArr;
        int count = 1;

        public Set()
        {
            setArr = new int[10];
        }

        public Set(int size)
        {
            setArr = new int[size];
        }
        public static int[] GetArr(Set set) { return set.setArr; }
        public static int GetCount(Set set) { return set.count; }


        public Set Add( int a) 
        { 
            this.setArr[count++] = a;
            return this;
        }
        public void Print(int num)
        {
            Console.WriteLine("set1: \n");
            for(int i=0;i<num;i++)
            {
                Console.WriteLine($"[{i}] {this.setArr[i]}\n");
            }
        }


        public static Set operator ++(Set set)
        {
            int num = (set.count + 89) % 15;
            if (set.count == set.setArr.Length)
                Console.WriteLine("Невозможно добавить новый элемент.");

            set.setArr[set.count++] = num;
            return set;
        }

        public static Set operator +(Set set1, Set set2)
        {
            Set temp = new Set(set1.setArr.Length+ set2.setArr.Length);
            set1.setArr.CopyTo(temp.setArr, 0);
            set2.setArr.CopyTo(temp.setArr, set1.setArr.Length);
            return temp;
        }

        public static bool operator <=(Set set1, Set set2)
        {
            if (set1.count <= set2.count) { return true; }
            else { return false; }
        }

        public static bool operator >=(Set set1, Set set2)
        {
            if (set1.count >= set2.count) { return true; }
            else { return false; }
        }

        public static int operator %(Set set, int i)
        {
            return set.setArr[i];
        }

        public static implicit operator int(Set set) //неявное преобразование set к int
        {
            return set.count;
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

    static class StatisticOperation
    {
        static int counter=1;

        public static int Sum(Set set)
        {
            int sum = 0;
            int[] arr = Set.GetArr(set);
            int count = Set.GetCount(set);
            for (int i = 0; i < count; i++) sum += arr[i];
            return sum;
        }

        public static int Delta(Set set)
        {
            int[] arr = Set.GetArr(set);
            int count = Set.GetCount(set);
            int max, min;
            max = min = arr[0];

            for (int i = 0; i < count; i++)
            {
                if (arr[i] > max) max = arr[i];
            }
            for (int i = 0; i < count; i++)
            {
                if (arr[i] < min) min = arr[i];
            }
            return max - min;
        }

        public static int StrHash(this string str)
        {
            counter++;
            int hash = 0;
            int seed = 262;
            for (int i = 0; i < str.Length; i++)
            {
                hash = ((hash * seed) + str[i])/counter;
            }
            return hash ;
        }

        public static bool IsSorted(this Set set)
        {
            int[] arr = Set.GetArr(set);
            int len = Set.GetCount(set);
            bool b = false;
            for (int i = 0; i < len- 1; i++)
            {
                if (arr[i] > arr[i + 1]) return b=false; 
            }
            return b = true;
        }
    }

    class Program
    {
        static void Main(string[] args)
        {
            Set set1 = new Set();
            Set set2 = new Set();
            Set set3 = new Set(20);
            set1.Add(12);
            set1.Add(8);
            set1.Add(-963);
            set1++;
            set1.Print(4);

            set2.Add(-37540);
            set2.Add(3);
            set2.Add(6);
            set3 = set1 + set2;
            set3.Print(20);

            bool b1 = set1 <= set2;
            bool b2 = set1 >= set2;
            Console.WriteLine($"b1={b1}     b2={b2}");
            Console.Write(set1 % 2 +"\n");
            int i = set1;
            Console.Write(i+"\n");

            Set.Owner owner = new Set.Owner();
            Console.WriteLine(owner);
            Set.Date date = new Set.Date(17, 10, 2020);
            date.ShowDate();
            Console.WriteLine("Sum: " + StatisticOperation.Sum(set2));
            Console.WriteLine("Delta: " + StatisticOperation.Delta(set1));
            string str = "Hello World";
            Console.WriteLine("StrHash: " + str.StrHash());
            Console.WriteLine("IsSorted: " + set2.IsSorted());
        
        }
    }
}
