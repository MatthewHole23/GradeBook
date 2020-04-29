using System;
using System.IO;
using System.Collections.Generic;

namespace GradeBook
{
    class Program
    {
        static void Main() 
        {
            // creating a new DiskBook object of type 'Book'
            Book book = new DiskBook();
            SetName(book);  // setting the name of the book
            book.GradeAdded += OnGradeAdded; // called when a new grade is added                     
            UserIntGrade(book); // adding grades to the InMemory and DiskBook

            

            var stats = book.GetStatistics();
            Console.WriteLine($"These are the statistics for {book.Name}'s Gradebook.");
            Console.WriteLine($"The lowest grade is {stats.Low}%.");
            Console.WriteLine($"The highest grade is {stats.High}%.");
            Console.WriteLine($"The average grade is {stats.Average}%.");
            Console.WriteLine($"Your overall grade is {stats.Letter}.");
        }

        static void OnGradeAdded(object sender, EventArgs e)
        {
            Console.WriteLine($"Success");
        }

   

        // polymorphic class created where UserIntGrade accepts an object of type 'Book' that utilises method 'AddGrade'
        private static void UserIntGrade(Book book)
        {
            while(true)
            {
                Console.WriteLine("Would you like to add a grade for a subject?\nYes(y)   No(n)");
                var add_grade = Console.ReadLine();
                if(add_grade == "y")
                {
                    while (true)
                    {
                        try
                        {  
                            Console.WriteLine("Name of subject to add a grade for:");
                            var subject_name = Console.ReadLine();
                            SubjectName(book, subject_name);
                            try
                            {
                                Console.WriteLine($"Please type in a valid grade for {subject_name}:");
                                var ui_grade = Console.ReadLine();

                                if(Double.TryParse(ui_grade, out double value))
                                {
                                    book.AddGrade(value, subject_name);
                                    break;
                                }
                                else if(Char.TryParse(ui_grade, out char letter_val))
                                {
                                    book.AddGrade(letter_val, subject_name);
                                    break;
                                }
                                                         
                            }
                            catch(ArgumentException ex)
                            {
                                Console.WriteLine(ex.Message);
                            }
                            catch(FormatException ex)
                            {
                                Console.WriteLine(ex.Message);
                            
                            }
                            finally
                            {
                                Console.WriteLine("...");
                            }
                        }
                        catch(ArgumentException ex)
                        {
                            Console.WriteLine(ex.Message);
                        }
                        
                        
                    }
                                       
                }
                else if(add_grade == "n")
                {
                    Console.WriteLine("No grades were added");
                    // ui_decision = true;
                    break;
                }
                else
                {
                    Console.WriteLine($"Please enter a valid option. '{add_grade}' is an invalid entry.");
                }
            }    
        }

        private static void SetName(Book book)
        {
            do
            {              
                try
                {
                    Console.WriteLine("Please enter the name of the student:\n");
                    var new_name = Console.ReadLine();
                    if (!String.IsNullOrEmpty(new_name))
                    {
                        try
                        {
                            string path = $"{Directory.GetCurrentDirectory()}\\{new_name}.txt";
                            if(!File.Exists(path))
                            {
                                book.Name = new_name;
                                Console.WriteLine("Name is OK!");
                                using (File.CreateText(path))
                                break;  
                            }else
                            {
                                Console.WriteLine($"A gradebook for {new_name} already exists.\nDo you with to Overwrite the file (o), add to the file (a), or create a book with a unique name (c)?");
                                var option = Char.Parse(Console.ReadLine());
                                FileOptions(option, book, new_name);
                            } 
                        }
                        catch(ArgumentException ex)
                        {
                            Console.WriteLine(ex.Message);
                        }
                        
                        
                    }
                    else
                    {
                        throw new FormatException("A gradebook's name cannot be empty");
                    }
                }
                catch (FormatException ex)
                {
                    Console.WriteLine(ex.Message);
                }
                
            }while(book.Name == null);
        } 

        private static void FileOptions(char choice, Book book, string new_name)
        {
            switch(choice)
            {
                case 'o':
                    book.Name = new_name;
                    using (File.CreateText($"{new_name}.txt"))
                    Console.WriteLine($"The existing entry for {book.Name} will be overwritten.");
                    break;
                
                case 'a':
                    book.Name = new_name;
                    Console.WriteLine($"The existing entry for {book.Name} will be added to.");
                    break;
                
                case 'c':
                    break;

                default:
                    throw new ArgumentException($"{choice} was not a valid option.");

            }
        }

        private static void SubjectName(Book book, string subject_name)
        {
            if(subject_name != null)
            {
                using(var reader = File.OpenText($"{book.Name}.txt"))
                {   
                    var line = reader.ReadLine();
                    while(line != null)
                    {   
                        var subjfromfile = line.Split(':')[0];
                        if(subjfromfile.ToLower() == subject_name.ToLower())
                        {
                            throw new ArgumentException("There is already a grade stored for this subject.");
                        }
                        line = reader.ReadLine();
                    }
                }
            }
            else
            {
                throw new ArgumentException("Grade names cannot be empty.");
            }
            
        }
    } 

    
}
