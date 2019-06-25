using System;

namespace GradeBook
{
    class Program
    {
        static void Main(string[] args)
        {
            var book = new DiskBook("Gradebook");

            //book.WriteLog("fish and grits");

            book.GradeAdded += OnGradeAdded;

            book.Name = "";

            Console.WriteLine(book.Name);
            EnterGrades(book);

            var stats = book.GetStatistics();

            Console.WriteLine($"Average grade is {stats.Average}.  Low grade is {stats.Low}.  High grade is {stats.High}. " +
                $"Letter grade is {stats.Letter}");
        }

        private static void EnterGrades(IBook book)
        {
            while (true)
            {
                var input = Console.ReadLine();

                if (input == "q") break;

                try
                {
                    book.AddGrade(double.Parse(input));
                }
                catch (ArgumentException ex)
                {
                    Console.WriteLine(ex.Message);
                }
                catch (FormatException ex)
                {
                    Console.WriteLine(ex.Message);
                }
                finally
                {
                    // code runs everytime
                }
            }
        }

        private static void OnGradeAdded(object sender, EventArgs args)
        {
            Console.WriteLine("OnGradeAdded called");
        }
    }
}
