using System;
using System.Collections.Generic;

namespace GradeBook
{
    public class NamedObject
    {
        public NamedObject(string name)
        {
            Name = name;
        }
        public string Name { get; set; }
    }
    public class Book : NamedObject
    {
        private List<double> grades;

        readonly string test; // read only means var only initialized in constructor and can't be changed

         const string CONSTANT = "constant";  // can never be changed, treated as static


        public Book(string name) : base(name)
        {
            grades = new List<double>();
        }

        public void AddGrade(double grade)
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

        public Statistics GetStatistics()
        {
            var result = new Statistics();

            result.High = double.MinValue;
            result.Low = double.MaxValue;

            foreach (var grade in grades)
            {
                result.High = Math.Max(grade, result.High);
                result.Low = Math.Min(grade, result.Low);
                result.Average += grade;
            };

            result.Average /= grades.Count;

            switch (result.Average)
            {
                case var d when d >= 90.0:
                    result.Letter = 'A';
                    break;
                case var d when d >= 80.0:
                    result.Letter = 'B';
                    break;
                case var d when d >= 70.0:
                    result.Letter = 'C';
                    break;
                case var d when d >= 60.0:
                    result.Letter = 'D';
                    break;
                default:
                    result.Letter = 'F';
                    break;
            }

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

            // EVENTS

                public delegate void GradeAddedDelegate(object sender, EventArgs args);

                public event GradeAddedDelegate GradeAdded;

                // see implementation in AddGrade function and program.cs

            // end

        // end


    }
}