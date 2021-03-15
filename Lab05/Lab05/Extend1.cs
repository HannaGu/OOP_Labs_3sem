using System;
using System.Collections;
using System.Collections.Generic;
using System.Text;
using Lab05.Exceptions;
using System.Diagnostics;

namespace Lab05
{
    public abstract class Trial
    {
        public string teacher { get; set; }
        public string dicipline { get; set; }
        protected int mark { get; set; }
        protected int minMark { get; set; }
        protected bool passed { get; set; }

        public int RaiseMark()
        {
           Debug.Assert(this.mark > 10);
            return this.mark++;      
        }

        public virtual bool IsPassed()
        {
            if (this.mark >= this.minMark)
            {
                Console.WriteLine("Испытание успешно пройдено");
                return true;
            }
            else
            {
                Console.WriteLine("Испытание не пройдено");
                return false;
            }
        }

        public Trial(string teacher, string dicipline, int mark, int minMark)
        {
            this.teacher = teacher;
            this.dicipline = dicipline;
            this.mark = mark;
            this.minMark = minMark;
            this.passed = IsPassed();
        }
    }

    abstract class SameMethods
    { public abstract bool Letters(); }

    class Test : Trial, ITrial
    {
        public Trial[] trials=new Trial[2];
        public int countQuestions
        {
            get { return countQuestions; }
            set
            { 
                if (value < 1)
                 throw new NewExceptions("Выход из допустимого диапазона ", "Custom exception");
            }
        }
        public override bool IsPassed()
        {
            if (this.mark >= this.minMark)
            {
                Console.WriteLine("Тест сдан.");
                return true;
            }
            else
            {
                Console.WriteLine("Тест не сдан");
                return false;
            }
        }
        public void MinMarkErr(int minMark)
        {
            if (minMark < 4)
                throw new WrongData("Минимальная оценка не может быть <4", minMark);
            this.minMark = minMark;
        }

        public void NullRef(int index)
        {
            if (this.trials[index] == null)
                throw new NullReferensEx("Элемент списка не инициализирован ", index);
        }
        public void IndexOutofRange(int index)
        {
            if (index > this.trials.Length)
                throw new IndexOutofRange("Индекс превышает допустимое значение ", index);
            else { Console.Write(this.trials[index]); }
        }
        
        public Test(int countQuestions, string teacher, string dicipline, int mark, int minMark) : base(teacher, dicipline, mark, minMark)
        {
           this.countQuestions = countQuestions;
        }

        public override string ToString()
        {
            return "Количество вопросов: " + this.countQuestions + " Предмет: " + this.dicipline + " Преподаватель: " + this.teacher + "\n";
        }

    }

   partial class Exam : Trial, ITrial
    {
        protected int time { get; set; }
        public override bool IsPassed()
        {
            if (this.mark >= this.minMark)
            {
                Console.WriteLine("Экзамен сдан.");
                return true;
            }
            else
            {
                Console.WriteLine("Экзамен не сдан");
                return false;
            }
        }

        public Exam(int time, string teacher, string dicipline, int mark, int minMark) : base(teacher, dicipline, mark, minMark)
        {
            this.time = time;
        }
    }

    public class Credit : Trial, ITrial
    {
        protected int time { get; set; }
        public override bool IsPassed()
        {
            if (this.mark >= this.minMark)
            {
                Console.WriteLine("Зачет сдан.");
                return true;
            }
            else
            {
                Console.WriteLine("Зачет не сдан");
                return false;
            }
        }

        public Credit(int time, string teacher, string dicipline, int mark, int minMark) : base(teacher, dicipline, mark, minMark)
        {
            this.time = time;
        }

        public override string ToString()
        {
            return "Время зачета: " + this.time + " Предмет: " + this.dicipline + " Преподаватель: " + this.teacher + "\n";
        }
    }

    sealed class FinalExam : Exam
    {
        int numOfQuestions { get; set; }
        int numOfTasks { get; set; }
        public FinalExam(int numOfQuestions, int numOfTasks, int time, string teacher, string dicipline, int mark, int minMark) : base(time, teacher, dicipline, mark, minMark)
        {
            this.numOfTasks = numOfTasks;
            this.numOfQuestions = numOfQuestions;
        }

        public override string ToString()
        {
            return "Количество вопросов: " + this.numOfQuestions + " Количество заданий: " + this.numOfTasks + " Предмет: " + this.dicipline + " Преподаватель: " + this.teacher + "\n";
        }
    }
    class Question : Test
    {
        int points { get; set; }
        string value { get; set; }

        public Question(int points, string value, int countQuestions, string teacher, string dicipline, int mark, int minMark) : base(countQuestions, teacher, dicipline, mark, minMark)
        {
            this.points = points;
            this.value = value;
        }
        public override string ToString()
        {
            return "Вопрос: " + this.value + " Вес вопроса: " + this.points + " Предмет: " + this.dicipline + " Преподаватель: " + this.teacher + "\n";
        }
        public override bool Equals(object obj)
        {
            if (obj.GetType() != this.GetType())
                return false;
            Question elem = (Question)obj;
            if (elem.points == this.points) return true;
            else { return false; }
        }

        public override int GetHashCode()
        {
            int hash = this.value.Length * 111111 / this.countQuestions;
            return hash;
        }
    }

    class Same : SameMethods, ISame
    {
        string word { get; set; }

        public Same(string word)
        { this.word = word; }
        public override bool Letters()
        {
            if (word.Length % 2 == 0) return true;
            else { return false; }
        }

        bool ISame.Letters()
        {
            if (word.Length % 2 == 0) return false;
            else { return true; }
        }
    }
    public class Printer
    {
        public void IAmPrinting(Object A)
        {
            Console.Write(A.GetType());
            Console.Write(A.ToString());
        }
    }
}


