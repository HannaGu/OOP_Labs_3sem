using System;
using System.Collections.Generic;
using System.Text;

namespace Lab05
{
    partial class Exam : Trial, ITrial
    {
        public override string ToString()
        {
            return "Время экзамена: " + this.time + " Предмет: " + this.dicipline + " Преподаватель: " + this.teacher + "\n";
        }
    }
}
