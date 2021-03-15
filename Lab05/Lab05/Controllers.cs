using System;
using System.Collections.Generic;
using System.Text;

namespace Lab05
{
    struct Diciplines
    {
        string d1;
        string d2;
        string d3;
        string d4;
        string d5;

        public Diciplines(string d1, string d2, string d3, string d4, string d5)
        {
            this.d1 = d1;
            this.d2 = d2;
            this.d3 = d3;
            this.d4 = d4;
            this.d5 = d5;
        }
    }

    enum Color
    {
        red = 15,
        green = 254,
        blue = 12
    }

    public class SessionController
    {
        public SessionController() { }
        public void FindByDicip(SessionConteiner sc, string dicip)
        {
            int n = 0;
            foreach (Trial el in sc.trials)
            {
                if (el.dicipline == dicip)
                {
                    n++;
                    Console.Write($"\nНайдено испытание по дисциплине '{el.dicipline}' №{n}");
                }
            }
        }
        public int CountTrials(SessionConteiner sc)
        {
            return sc.trials.Count;
        }
        public void FindTest(SessionConteiner sc, int num)
        {
            foreach (Object el in sc.trials)
            {
                if (el is Test)
                {
                    Test item = (Test)el;
                    if (item.countQuestions == num)
                        Console.WriteLine("\nПредмет: " + item.dicipline + " Преподаватель: " + item.teacher);
                }
            }
        }
    }
    public class SessionConteiner
    {
        public List<Trial> trials;

        public SessionConteiner()
        {
            trials = new List<Trial>();
        }

        public void Delete(int index)
        {
            trials.RemoveAt(index);
        }

        public void Add(Trial item)
        {
            trials.Add(item);
        }

        public void Show()
        {
            foreach (Object el in trials)
            {
                Console.Write(el.GetType());
                Console.Write(el.ToString());
            }
        }

    }
}
