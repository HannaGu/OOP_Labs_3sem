using System;

namespace Lab09
{
    class Program
    {
        static void Main(string[] args)
        {
            Director d1 = new Director(200);
            Director d2 = new Director(200);
            Director d3 = new Director(200);

            d1.RaiseNotify += DisplayMessage;
            d1.LowNotify += DisplayMessage;
            d1.RaiseSalary(10);
            d1.LowerSalary(20);

            d2.RaiseNotify += DisplayMessage;
            d2.RaiseSalary(100);

            d3.LowNotify += DisplayMessage;
            d3.LowerSalary(100);

            string str = "Hello. World";
            Action<string> stringDelegate = (s) => Console.WriteLine(s);
            Func<string> function = str.DeleteDrops;
            stringDelegate(str = function());
            function += str.Up;
            stringDelegate(str = function());
            function += str.Down;
            stringDelegate(str = function());
            function += str.DeleteSpaces;
            stringDelegate(str = function());
            function += str.AddStr;
            stringDelegate(str = function());

        }
        private static void DisplayMessage(string message)
        {
            Console.WriteLine(message);
        }
    }
}
