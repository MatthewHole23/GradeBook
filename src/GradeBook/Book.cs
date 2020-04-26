using System;
using System.Collections.Generic;
using System.Text;

namespace GradeBook
{
    public abstract class Book : NamedObject, IBook
    {
        public Book() : base()
        {
        }

        public abstract event GradeAddedDelegate GradeAdded;

        public abstract void AddGrade(double grade);

        public abstract Statistics GetStatistics();
        
    }
}
