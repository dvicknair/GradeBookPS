using System;
using System.Collections.Generic;
using System.Text;

namespace GradeBook
{
    public class Statistics
    {
        public int Count;
        public double Sum;
        public double High;
        public double Low;


        public Statistics()
        {
            Count = 0;
            High = double.MinValue;
            Low = double.MaxValue;
        }

        public void Add(double grade)
        {
            Sum += grade;
            Count++;
            Low = Math.Min(grade, Low);
            High = Math.Max(grade, High);
        }

        public double Average => Sum / Count;
        public char Letter
        {
            get
            {
                switch (Average)
                {
                    case var d when d >= 90.0:
                        return 'A';
                    case var d when d >= 80.0:
                        return 'B';
                    case var d when d >= 70.0:
                        return 'C';
                    case var d when d >= 60.0:
                        return 'D';
                    default:
                        return 'F';
                }
            }
        }
    }
}
