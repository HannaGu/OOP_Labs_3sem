using System;
using System.Collections.Generic;
using System.Text;

namespace Lab_08
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
    class Exam : Trial, ITrial
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

        public override string ToString()
        {
            return  " Предмет: " + this.dicipline + " Преподаватель: " + this.teacher + "\n";
        }
    }

}
