using System;
using System.Data.SqlTypes;
using System.Security.Cryptography;

namespace Lab03
{
    public partial class House
    {
        public const double u = 18.451;
        static int staticField;
        static int count;
        readonly int id;
        int flatNum;
        int square;
        int floor;
        int rooms;
        string street;
        string type;
        int term;

        public static void Print(House house)
        {
            
            Console.WriteLine($"id: {house.id}, номер квартиры: {house.flatNum}, площадь: {house.square}, этаж: {house.floor}, комнаты: {house.rooms}, " +
                $"улица: {house.street}, тип здания: {house.type}.");
            Console.WriteLine($"статический счетчик: {count}.");
        }

        public int Renovation
        {
            get
            {
                return term;
            }
            set
            {
                if (value > 25)
                { 
                    Console.WriteLine("Здание нуждается в капитальном ремонте.");
                    term = value;
                    Console.WriteLine($"срок эксплуатации: {term}");
                }
                else 
                {
                    Console.WriteLine("Здание не нуждается в капитальном ремонте."); 
                    term = value;
                    Console.WriteLine($"срок эксплуатации: {term}");
                }
            }            
        }

        public int Rooms
        {
            get { return rooms; }
            protected set
            {
                if(value>5)
                {
                    rooms = 5;
                    Console.WriteLine("Количество комнат не должно превышать 5.");
                }
                else { rooms = value; }
            }
        }

        public void NewTerm(ref int t)
        {
            this.term = t;
        }
        public int RoomArea(out int area )
        {
            area = this.square / this.rooms;
            return area;
        }

        public House(int i, int fN, int s, int f, int r, string str, string ty )
        {
            id = i;
            flatNum = fN;
            square = s;
            floor = f;
            rooms = r;
            street = str;
            type = ty;
            count++;
        }

        static House()
        {
            staticField=7;
        }

        private House()
        { 
            id = 0;
            flatNum = 1;
            square =65;
            floor = 1;
            rooms = 2;
            street = "Победителей";
            type = "Трехэтажное";
            count++;
        }

        //Переопределение методов
        public override bool Equals(object obj)
        {
            if (obj.GetType() != this.GetType())
                return false;
            House elem = (House)obj;
            if (elem.GetHashCode() != GetHashCode())
                return false;
            return true;
        }

        public override int GetHashCode()
        {
            int hash =this.street.Length*111111/id;            
            return hash;
        }

        public override string ToString()
        {
            return $"Объект №{count}\nНомер дома: {this.id}\nНомер квартиры: {this.flatNum}\nПлощадь квартиры: {this.square}\nЭтаж: {this.floor}\nКоличество комнат: {this.rooms}\nУлица: {this.street}\nТип здания: {this.type}\nСрок эксплуатации: {this.term}\n";
        }
  }

    public partial class House
    {
        public static void FindFlat(House[] obj, int r)
        {
            int j = 0;
            for (int i = 0; i < obj.Length; i++)
            {
                if (obj[i].rooms == r)
                {
                    Console.WriteLine($"Квартира №: {obj[i].flatNum}, номер дома: {obj[i].id}.\n");
                    j++;
                }
            }
            if (j == 0) Console.WriteLine("Квартиры с таким количеством комнат не найдены.");
        }

        public static void FindFloorFlat(House[] obj, int r, int f1, int f2)
        {
            int j = 0;
            for (int i = 0; i < obj.Length; i++)
            {
               if (obj[i].rooms ==r&& obj[i].floor>=f1&& obj[i].floor <=f2)
                    {
                     Console.WriteLine($"Квартира №: {obj[i].flatNum}, номер дома: {obj[i].id}.\n");
                    j++;
                    }
                if (j == 0) Console.WriteLine("Квартиры с такими параметрами не найдены.");
            }
        }
    }
    class Program
    {
        static void Main(string[] args)
        {
            House h1 = new House(1, 1, 30, 4, 1,"Кибернетиков", "пятиэтажное");
            h1.Renovation = 26;
            //h1.Rooms = 6;
            //h1.u = 4.5;
            int t = 25; int a;
            h1.NewTerm(ref t);
            h1.RoomArea(out a);
           
            House h2 = new House(52, 47, 90, 2, 3,"Воскобойникова", "трехэтажное");
            h1.Renovation = 14;
            Console.Write(h2.GetHashCode()+"\n");    
            Console.Write(h1.GetHashCode()+"\n");    
            Console.Write(h1.Equals(h2)+"\n");
            Console.Write(h2.ToString()+"\n");

            House[] Houses = new House[2];
            Houses[0] = h1;
            Houses[1] = h2;
            House.FindFlat(Houses, 3);
            House.FindFloorFlat(Houses, 1, 3, 5);

            House.Print(h1);

            var anon = new { id = 67, flatN=15, floor=2};
            Console.WriteLine(anon.id+"\n"+ anon.flatN + "\n"+ anon.floor + "\n");
        }
    }
}
