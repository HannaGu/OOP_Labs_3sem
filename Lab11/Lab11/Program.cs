using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Security.Authentication;

namespace Lab11
{
    class Program
    {
        static void Main(string[] args)
        {
            string[] month = { "January", "February", "March", "April", "May", "June", "July", "August", "September", "October", "November", "December" };

            var selectedMonthN = from m in month
                                 where m.Length ==5
                                 select m;
            Console.WriteLine("Месяцы длинной 4:");
            foreach (string str in selectedMonthN)
                Console.Write(str + ",  ");

            var seasonMonth = from m in month
                                      where Array.IndexOf(month, m) < 2 ||
                                      Array.IndexOf(month, m) > 4 && Array.IndexOf(month, m) < 8 ||
                                      Array.IndexOf(month, m) == 11
                                      select m;
            Console.WriteLine("\n\nЗимние и летние месяцы:");
            foreach (string str in seasonMonth)
                Console.Write(str + ",  ");


            var byAlphabeth = from m in month
                                    orderby m
                                    select m;
            Console.WriteLine("\n\nМесяцы по алфавиту:");
            foreach (string str in byAlphabeth)
                Console.Write(str + ",  ");


            var selectedMonthU4 = from m in month
                                  where m.Contains('u') && m.Length > 3
                                  select m;
            Console.WriteLine("\n\nМесяцы с буквой 'u', длина >= 4:");
            foreach (string str in selectedMonthU4)
                Console.Write(str + ",  ");

            List<House> houses = new List<House>();
            houses.Add(new House(1, 1, 30, 4, 1, "Кибернетиков", "пятиэтажное"));
            houses.Add(new House(52, 47, 90, 2, 3, "Воскобойникова", "трехэтажное"));
            houses.Add(new House(52, 43, 84, 3, 4, "Воскобойникова", "трехэтажное"));
            houses.Add(new House(52, 44, 40, 4, 2, "Воскобойникова", "трехэтажное"));
            houses.Add(new House(52, 48, 30, 1, 1, "Воскобойникова", "трехэтажное"));
            houses.Add(new House(52, 46, 75, 3, 3, "Воскобойникова", "трехэтажное"));
            houses.Add(new House(3, 50, 30, 1, 1, "Державина", "четырехэтажное"));
            houses.Add(new House(3, 50, 30, 1, 1, "Державина", "четырехэтажное"));
            houses.Add(new House(14, 52, 30, 3, 2, "Энгельса", "двухэтажное"));            

              var selectedHouses = from h in houses
                                   where h.rooms==3
                                   select h;
            Console.WriteLine("\n Список квартир, имеющих 3 комнаты.");
            foreach (House h in selectedHouses)
                Console.Write( h.street + "  " + h.flatNum+","+" ");

            var selectedFlats = (from h in houses
                                 where h.street =="Воскобойникова"&&h.id==52
                                 select h).Take(5);
            Console.WriteLine("\n Список пяти первых квартир на заданной улице заданного дома.");
            foreach (House h in selectedFlats)
                Console.Write(h.street + "  "+h.id+" " + h.flatNum +","+ " ");

            var flatsOnStreet = from h in houses
                                where h.street == "Воскобойникова"
                                select h;
            Console.Write($"\n Количество квартир на заданной улице: {flatsOnStreet.Count()}");

            var listOfFlats = from h in houses
                              where h.rooms ==2&&h.floor>1&&h.floor<4
                              select h;

            Console.WriteLine("\n Список квартир с двумя комнатами и расположенные на 2 и 3 этажах");
            foreach (House h in listOfFlats)
                Console.Write(h.street + "  " + h.id + " " + h.flatNum + "," + " ");


            List<Adress>adress = new List<Adress>();
            adress.Add(new Adress("Независимости", 5));
            adress.Add(new Adress("Державина", 74));
            adress.Add(new Adress("Победы", 3));

            var res = from h in houses
                      join a in adress on h.street equals a.street
                      select new { street= a.street, id=h.id };

            Console.WriteLine();
            foreach (var item in res)
                Console.WriteLine($"{item.street} - {item.id}");

            List<int> nums = new List<int>() { 1, 54, 42, 12, 23, 64, 37 };
            var res2 = nums.OrderBy(i => i).Take(4).Skip(1).Where(i => i > 20).Aggregate((x, y) => x + y);

            Console.WriteLine(res2);
        }
        
    }
}
