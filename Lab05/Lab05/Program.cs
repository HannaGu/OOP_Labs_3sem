using System;
using System.Collections;
using Lab05.Exceptions;
using static Lab05.Logger;

using System.IO;
using System.Diagnostics;

namespace Lab05
{
    class Program
    {
        static void Main(string[] args)
        {
            Test test1 = new Test(25, "Иванов", "ООП", 5, 4);
            //Test test2 = new Test(10, "Сидоров", "КСИС", 2, 4);
            //Test test3 = new Test(10, "Краснов", "АЛОЦВМ", 8, 4);
            Exam exam1 = new Exam(45, "Петров", "ЭВМ и ПО", 10, 4);
            //FinalExam fexam1 = new FinalExam(3, 2, 45, "Петров", "ЭВМ и ПО", 7, 4);
            //Exam exam2 = fexam1;
            //FinalExam fexam2 = exam2 as FinalExam;
            //Question question = new Question(2, "Свойства функций", 25, "Иванов", "ООП", 5, 4);
            //Printer printer = new Printer();
            //bool checkExam = exam1 is Exam;

            //Same s = new Same("methods");
            //Console.WriteLine(s.Letters()+"\n");
            //Console.WriteLine(((ISame)s).Letters()+"\n");

            //ArrayList list = new ArrayList();
            //list.Add(test1);
            //list.Add(exam1);
            //list.Add(fexam1);
            //list.Add(question);

            //foreach(Object el in list)
            //{
            //   printer.IAmPrinting(el);
            //}

            ////------------------- lab 06 ---------------------
            //Diciplines diciplines = new Diciplines("ООП", "ЯП", "КСИС", "Математика", "ЭВМ");
            //Console.Write(Color.red);
            //Console.Write((int)Color.red);

            //SessionConteiner session = new SessionConteiner();
            //SessionController sessionContr = new SessionController();
            //session.Add(test1);
            //session.Add(test2);
            //session.Add(test3);
            //session.Add(exam1);
            //session.Add(fexam1);
            //sessionContr.FindByDicip(session, "ООП");
            //sessionContr.CountTrials(session);
            //sessionContr.FindTest(session, 10);

            //------------------ lab 07 ---------------------
            try
            {
                string path = @"D:\data.txt";
                FileInfo fileInf = new FileInfo(path);
                if (!fileInf.Exists)
                { throw new FileException("Файл не существует"); }
            }
            catch(FileException ex)
            {
                Console.WriteLine($"Error Type: {ex.ErrorType}; Error: {ex.Message}");
            }

            try
            { test1.MinMarkErr(2); }
            catch (WrongData ex)
            {
                Console.WriteLine($"Error Type: {ex.ErrorType}; Error: {ex.Message}: {ex.ErrorData}");
            }

            try 
            { test1.NullRef(0); }
            catch (NullReferensEx ex)
            {
                Console.WriteLine($"Error Type: {ex.ErrorType}; Error: {ex.Message} : {ex.ErrorData}");
            }

            try
            { test1.IndexOutofRange(4); }
            catch (IndexOutofRange ex)
            {
                Console.WriteLine($"Error Type: {ex.ErrorType}; Error: {ex.Message} : {ex.ErrorData}");
            }

            try
            { Test test2 = new Test(-5, "Сидоров", "КСИС", 2, 4); }
            catch (NullReferensEx ex)
            {
                Console.WriteLine($"Error Type: {ex.ErrorType}; Error: {ex.Message} : {ex.ErrorData}");
            }
            catch(NewExceptions ex)
            {
                Console.WriteLine($"Error Type: {ex.ErrorType}; Error: {ex.Message}");
                FileLogger.WriteLog(ex);
            }

            try 
            { exam1.RaiseMark(); }
            catch (NewExceptions ex)
            {
                Console.WriteLine($"Error Type: {ex.ErrorType}; Error: {ex.Message}");
            }
            finally
            {
                Console.WriteLine("Работа после обнаружения ошибки.");
            }

        }
    }
}
