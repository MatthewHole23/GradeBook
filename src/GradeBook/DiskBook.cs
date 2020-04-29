using System;
using System.Collections.Generic;
using System.Text;
using System.IO;

namespace GradeBook
{
    public class DiskBook : Book, IBook
    {
        public DiskBook() : base()
        {
            Name = name;
        }

        public override event GradeAddedDelegate GradeAdded;

        public override void AddGrade(double grade, string subject_name)
        {
            if ((grade >= 0) && (grade <= 100))
            {
                using(var writer = File.AppendText($"{Name}.txt"))
                {
                writer.WriteLine($"{subject_name}: {grade}%");
                if(GradeAdded != null)
                {
                    GradeAdded(this, new EventArgs());
                }
                }
            }
            else
            {
                throw new ArgumentException("Invalid Grade");
            }
            
        }

        public override Statistics GetStatistics()
        {
            var result = new Statistics();
            try
            {
                using(var reader = File.OpenText($"{Name}.txt"))
                {
                    var line = reader.ReadLine();
                    while(line != null)
                    {
                        // Add string interpolation to extract just the grade
                        var numfromfile = line.Split(':')[1].Trim(' ','%');
                        var number = double.Parse(numfromfile);
                        result.Add(number);
                        line = reader.ReadLine();
                    }
                    return result;                                                 
                }
            }
            catch(System.IO.FileNotFoundException)
            {
                Console.WriteLine("No file is present.");
            }
            catch(FormatException)
            {
                System.Console.WriteLine("Stored grade value not in correct format.");
            }

            return result;
            
        }

    }
}
