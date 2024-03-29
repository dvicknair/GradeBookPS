﻿using System;
using System.Collections.Generic;
using System.Text;

namespace GradeBook
{
    public class InMemoryBook : Book
    {
        public override event GradeAddedDelegate GradeAdded;  // override allows this book implementation to differ from the base class
        private List<double> grades;

        readonly string test; // read only means var only initialized in constructor and can't be changed

        const string CONSTANT = "constant";  // can never be changed, treated as static


        public InMemoryBook(string name) : base(name)
        {
            grades = new List<double>();
        }

        public override void AddGrade(double grade)
        {
            if (grade <= 100 && grade >= 0)
            {
                grades.Add(grade);

                //  EVENT UNDER DELEGATE SECTION
                GradeAdded?.Invoke(this, new EventArgs());
            }
            else
                throw new ArgumentException($"Invalid {nameof(grade)}");
        }

        public override Statistics GetStatistics()  // override allows this book implementation to change the behavior of this method from that in the base class
        {
            var result = new Statistics();

            foreach (var grade in grades)
            {
                result.Add(grade);
            }

            // -----  ALL MOVED TO STATISTICS CLASS / MODEL
            //result.High = double.MinValue;
            //result.Low = double.MaxValue;

            //foreach (var grade in grades)
            //{
            //    result.High = Math.Max(grade, result.High);
            //    result.Low = Math.Min(grade, result.Low);
            //    result.Average += grade;
            //};

            //result.Average /= grades.Count;

            //switch (result.Average)
            //{
            //    case var d when d >= 90.0:
            //        result.Letter = 'A';
            //        break;
            //    case var d when d >= 80.0:
            //        result.Letter = 'B';
            //        break;
            //    case var d when d >= 70.0:
            //        result.Letter = 'C';
            //        break;
            //    case var d when d >= 60.0:
            //        result.Letter = 'D';
            //        break;
            //    default:
            //        result.Letter = 'F';
            //        break;
            //}

            return result;
        }

        // Property member example

        private string name;

        public string Name1
        {
            get
            {
                return name;
            }
            set
            {
                if (!string.IsNullOrEmpty(value))
                    name = value;
                else
                    Console.WriteLine("name can't be empty");
            }
        }

        // LATER SIMPLIFIED TO

        public string Name2 { get; set; }  // get or set can be set to private

        // end

        // DELEGATES  ----------------------------------------------------------------------

        public delegate string WriteLogDelegate(string logMessage);

        public void WriteLog(string message)
        {
            WriteLogDelegate logger = LogMessage;
            logger += LogMessageToDatabase;

            logger(message);
        }

        string LogMessage(string message)
        {
            Console.WriteLine($"LogMessage called {message}");

            return "";
        }

        string LogMessageToDatabase(string message)
        {
            Console.WriteLine($"LogMessageToDatabase called {message}");

            return "";
        }


        // end


    }
}
