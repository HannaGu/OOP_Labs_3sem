using System;

namespace Lab_08
{
    abstract class A { }
    class Program
    {
        static void Main(string[] args)
        {
            try
            {
                CollectionType<int> ct1 = new CollectionType<int>();
                int a = 3, b = 12, c = -7;
                ct1.Add(a);
                ct1.Add(b);
                ct1.Add(0);
                ct1.Add(-6);
                ct1.Show();
                //ct1.Delete(c);
                ct1.Show();
                CollectionType<double> ct2 = new CollectionType<double>();
                ct2.Add(14.22);
                ct2.Add(-784.202);
                CollectionType<Exam> ct3 = new CollectionType<Exam>();
                Exam exam1 = new Exam(45, "Петров", "ЭВМ и ПО", 9, 4);
                ct3.Add(exam1);
                ct3.Show();
                //CTInherit<A> ct4 = new CTInherit<A>();       //проверка ограничения
                ct1.WriteToFile(0);
                ct1.WriteToFile(1);
                ct1.ReadFromFile();

            }
            catch(NewExceptions ex)
            {
                Console.WriteLine($"Error Type: {ex.ErrorType}; Error: {ex.Message}");
            }
            finally
            {
                Console.WriteLine("End оf program");
            }

        }
    }
}
