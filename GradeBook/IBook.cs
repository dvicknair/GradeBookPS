using System;
using System.Collections.Generic;
using System.Text;

namespace GradeBook
{
    public interface IBook  // defines capabilities of a book
    {
        void AddGrade(double grade);
        Statistics GetStatistics();
        string Name { get; }
        event GradeAddedDelegate GradeAdded;
    }
}
