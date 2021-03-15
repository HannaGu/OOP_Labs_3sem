using System;
using System.Text;

namespace Lab02
{
    class Program
    {
        static void Main(string[] args)
        {
            //1a
            bool sBool = true; //8
            short sNum = 2; //16
            int iNum = -12; //32
            long lNum = 684951351; //64
            byte bNum = 113; //8
            sbyte sbNum = -126;
            ushort usNum = 65531;
            uint uiNum = 321;
            ulong ulNum = 543345233;
            char cSym = 'A'; //16
            float fNum = 3.14f; //32
            double dNum = 3.15; //64
            decimal decNum = 312.4323242m;

            Console.WriteLine($"bool {sBool}, short {sNum}, int {iNum}, long {lNum} ");
            Console.WriteLine($"byte {bNum}, sbyte {sbNum}, char {cSym}");
            Console.WriteLine($"ushort {usNum}, uint {uiNum}, ulong {ulNum}");
            Console.WriteLine($"float {fNum}, double {dNum}, decimal {decNum}");

            Console.WriteLine($"Введите свой возраст: ");
            int age = Convert.ToInt32(Console.ReadLine());

            //1b
            bNum = (byte)iNum;
            bNum = (byte)usNum;
            uiNum = (uint)sNum;
            sbNum = (sbyte)iNum;
            decNum = (decimal)dNum;

            ulNum = uiNum;
            dNum = fNum;
            iNum = sNum;
            lNum = bNum;
            iNum = usNum;

            //1c
            float num = 14.32f;
            Object u = num; //упаковка
            double d = (double)(float)num;//распаковка с привидением типа

            //1d
            var f = 12.5;
            Console.Write(f.GetType()); Console.WriteLine();
            var str = "Hello";
            Console.Write(str.GetType()); Console.WriteLine();

            //1e
            int? z1 = null;
            Nullable<int> z2 = null;
            Console.WriteLine($"NULL : { z1 == z2}");

            ////1f
            //var a = 14;
            //a = "Yes";

            Console.WriteLine("\nСравнение строковых литералов:");
            char s1 = 'l', s2 = 'K';
            Console.WriteLine(s1 > s2);
            Console.WriteLine(s1 < s2);
            Console.WriteLine(s1 == s2);

            //2b
            string str1 = "The answer to everything is ", str2 = "42", str3 = "24";
            Console.WriteLine($"Сцепление : {str1 + str2}");
            Console.WriteLine($"Копирование : {str2 = str3}");
            Console.WriteLine($"Выделение подстроки : {str1.Substring(14)}");
            //Разделение на слова
            string[] words = (str1 + str2).Split(new char[] { ' ' });
            foreach (string s in words)
            {
                Console.WriteLine(s);
            }
            Console.WriteLine($"Вставка: {str3.Insert(2, "Hello")}");
            Console.WriteLine($"Удаление: {str1.Remove(0, 11)}");

            //2c
            string isEmpty = "";
            Console.WriteLine("Пуста ли строка? " + string.IsNullOrEmpty(isEmpty));
            //2d
            StringBuilder sb = new StringBuilder("ABC", 26);
            sb.Append(new char[] { 'D', 'E', 'F' });
            sb.Insert(0, new char[] { 'G', 'H' });
            Console.WriteLine(sb);
            sb.Remove(1, 1);
            sb.Remove(3, 1);
            Console.WriteLine(sb);

            //3a
            int[,] mass = new int[3, 3] { { 654, 2, -5 }, { 18, 7, 62 }, { 0, 8, 9 } };
            Console.WriteLine();
            for (int i = 0; i < 3; i++)
            {
                for (int j = 0; j < 3; j++)
                {
                    Console.Write(mass[i, j]);
                }
                Console.WriteLine();
            }

            //3b
            Console.WriteLine();
            string[] strMass = new String[] { "Apple", "Lemon", "Orange" };

            foreach (string sString in strMass)
            {
                Console.WriteLine(sString + " " + sString.Length);
            }

            //Console.Write("Введите номер элемента: "); int x = Console.Read();
            //Console.Write("Введите значение: "); string n = Console.ReadLine();
            //strMass[x] = n;
            //foreach (string sString in strMass)
            //{
            //    Console.WriteLine(sString + " " + sString.Length);
            //}

            //3c
            int[][] matrix = new int[3][];
            matrix[0] = new int[2];
            matrix[1] = new int[3];
            matrix[2] = new int[4];

            for (int i = 0; i < matrix.Length; i++)
            {
                for (int j = 0; j < matrix[i].Length; j++)
                {
                    matrix[i][j] = Convert.ToInt16(Console.ReadLine());
                }
            }

            foreach (int[] arr in matrix)
            {
                foreach (int a in arr)
                {
                    Console.Write(a + " ");
                }
                Console.WriteLine();
            }

            //3d
            var aNontypedArr = new[] { 1, 2 };
            var sNontypedStr = new[] { "Hello" };

            //4a
            (int mark, string subj, char name, string lName, ulong number) exam = (7, "OOP", 'A', "Ivanov", 654961);
            (int mark, string subj, char name, string lName, ulong number) exam2 = (7, "OOP", 'A', "Ivanov", 654961);

            //4b
            Console.WriteLine("\n" + exam.mark);
            Console.WriteLine(exam.lName);
            Console.WriteLine(exam.number);
            Console.WriteLine(exam);


            //4d
            int mark = exam.Item1;
            var subj = exam.Item2;


            //4e
            if (exam == exam2)
            {
                Console.WriteLine("Tuples are equal");
            }
            else
            {
                Console.WriteLine("Tuples are not equal");
            }

            //6
            int[] A = { 1, 0, 30, 87, 9, 6 };
            string B = "Пример";
            Console.WriteLine(GetTuple(A, B));

            //7
           CheckedRes();
           UncheckedRes();
        }

        static (int max, int min, int sum, string s) GetTuple(int[] arr, string word)
        {
            Array.Sort(arr);
            int max = arr[arr.Length - 1];
            int min = arr[0];
            int sum = 0;
            for (int i = 0; i < arr.Length; i++)
            {
                sum += arr[i];
            }
            string s = word.Substring(0, 1);

            return (max, min, sum, s);
        }
        static void CheckedRes()
        {
            try
            {
                checked
                {
                    int N = 2147483647;
                }
            }
            catch (OverflowException)
            { 
            Console.Write("Переполнение\n\n");
            }

        }
        static void UncheckedRes()
        {
            try
            {
                unchecked
                {
                    int N = 2147483647;
                }
            }
            catch (OverflowException)
            {
                Console.Write("Переполнение\n\n");
            }
        }
    }
}
