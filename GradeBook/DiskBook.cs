using System;
using System.IO;

namespace GradeBook
{
    internal class DiskBook : Book
    {
        private string name;
        public override event GradeAddedDelegate GradeAdded;

        public DiskBook(string name) : base(name)
        {
            this.name = name;
        }

        public override void AddGrade(double grade)
        {
            using (var writer = File.AppendText($"{name}.txt")) // wrapped in "using" causes writer to be disposed after, even if it fails
            {
                writer.WriteLine(grade);
                if (GradeAdded != null)
                {
                    GradeAdded(this, new EventArgs());
                }
            }
        }

        public override Statistics GetStatistics()
        {
            var results = new Statistics();

            using (var reader = File.OpenText($"{name}.txt"))
            {
                var line = reader.ReadLine();
                var grade = new double();

                while (line != null)
                {
                    grade = double.Parse(line);
                    results.Add(grade);
                    line = reader.ReadLine();
                }
            }

            return results;
        }
    }
}