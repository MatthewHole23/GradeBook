using System;
using System.Collections.Generic;

namespace GradeBook
{
    public delegate void GradeAddedDelegate(object sender, EventArgs args);   

    public class InMemoryBook : Book
    {

        public List<double> grades;
             
        
        public InMemoryBook() : base() 
        {
            Name = name;
            grades = new List<double>(); 
        }

        public void AddGrade(char letter)
        {
            switch (letter)
            {
                case 'A':
                    AddGrade(90);
                    break;

                case 'B':
                    AddGrade(80);
                    break;

                case 'C':
                    AddGrade(70);
                    break;
                case 'D':
                    AddGrade(60);
                    break;

                default:
                    throw new ArgumentException("Invalid Grade");
            }
        }
       
        public override void AddGrade(double grade)
        {
          
            if ((grade >= 0) && (grade <= 100))
            {
                grades.Add(grade);
                if(GradeAdded != null)
                {
                    GradeAdded(this, new EventArgs());
                }
                Console.WriteLine($"A new grade has been added {Name}'s gradebook.");
            }
            else
            {
                throw new ArgumentException("Invalid Grade");
            }
        }

        public override event GradeAddedDelegate GradeAdded;

        public override Statistics GetStatistics()
        {
            var result = new Statistics();
                      
            for(int i = 0; i < grades.Count; i++)
            {
                result.Add(grades[i]);                               
            }
            return result;    
        }
       
    }
}