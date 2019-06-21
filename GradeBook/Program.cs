using System;

namespace GradeBook
{
    class Program
    {
        static void Main(string[] args)
        {
            var book = new Book("Mr Tom");

            //book.AddGrade(89.1);
            //book.AddGrade(72.5);
            //book.AddGrade(92.2);
            //book.AddGrade(88.1);

            var stats = book.GetStatistics();

            Console.WriteLine($"Average grade is {stats.Average}.  Low grade is {stats.Low}.  High grade is {stats.High}");
        }
    }
}
