using System;
using System.Collections.Generic;
using System.Text;

namespace Lab11
{
    public class House
    {
       
        static int count;
        public int id;
        public int flatNum;
        int square;
        public int floor;
        public int rooms;
        public string street;
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
                if (value > 5)
                {
                    rooms = 5;
                    Console.WriteLine("Количество комнат не должно превышать 5.");
                }
                else { rooms = value; }
            }
        }

       
        public House(int i, int fN, int s, int f, int r, string str, string ty)
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

        private House()
        {
            id = 0;
            flatNum = 1;
            square = 65;
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
            int hash = this.street.Length * 111111 / id;
            return hash;
        }

        public override string ToString()
        {
            return $"Объект №{count}\nНомер дома: {this.id}\nНомер квартиры: {this.flatNum}\nПлощадь квартиры: {this.square}\nЭтаж: {this.floor}\nКоличество комнат: {this.rooms}\nУлица: {this.street}\nТип здания: {this.type}\nСрок эксплуатации: {this.term}\n";
        }
    }
}
