using System;
using System.Collections.Generic;
using System.Text;

namespace Lab09
{
    class Director
    {
        public delegate void DirectorHandler(string message);
        public event DirectorHandler RaiseNotify;
        public event DirectorHandler LowNotify;

        int salary { get; set; }
        public Director(int sal)
        {
            salary = sal;
        }

        public void RaiseSalary(int delta)
        {
            this.salary = this.salary + delta;
            RaiseNotify?.Invoke($"Зарплата повышена на: {delta}. Текущая сумма: {this.salary}.");
        }


        public void LowerSalary(int delta)
        {
            if (delta < this.salary)
            {
                this.salary = this.salary-delta;
                LowNotify?.Invoke($"Зарплата понижена на: {delta}.Текущая сумма: {this.salary}.");
            }
            else
            {
                this.salary = 0;
                LowNotify?.Invoke($"Текущая сумма равна 0.");
            }
        }
    }
}
