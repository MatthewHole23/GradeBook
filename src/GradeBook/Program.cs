using System;
using System.Collections.Generic;

namespace GradeBook
{
    class Program
    {
        static void Main() 
        {

            IBook book = new DiskBook("Matthew");
            System.Console.WriteLine(book.Name); // just as reference that a 'name' was added when a book was instantiated
            book.GradeAdded += OnGradeAdded; // called when a new grade is added

            /*
            while(true)
            {
                if (book.Name == null)
                {
                    try
                    {
                        Console.WriteLine("Please enter the name of the student:\n");
                        book.Name = Console.ReadLine();
                    }
                    catch (FormatException ex)
                    {
                        Console.WriteLine(ex.Message);
                    }
                }
                else
                {
                    Console.WriteLine($"{book.Name}'s gradebook has been created!");
                    break;
                }
            } 
            */

            UserIntGrade(book);

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

        // polymorphic class creating where UserIntGrade accepts an object of type 'Book' that utilises a method named 'AddGrade'
        private static void UserIntGrade(IBook book)
        {
            while(true)
            {
                Console.WriteLine("Would you like to add a grade?\nYes(y)   No(n)");
                var add_grade = Console.ReadLine();
                if(add_grade == "y")
                {
                    while (true)
                    {
                        try
                        {
                            Console.WriteLine("Please type in a valid grade or Quit(q):");
                            var ui_grade = Console.ReadLine();
                            
                            if(ui_grade == "q")
                            {
                                break;
                            }
                            else
                            {   
                                if(Double.TryParse(ui_grade, out double value))
                                {
                                    book.AddGrade(value);
                                }
                                else if(Char.TryParse(ui_grade, out char letter_val))
                                {
                                    book.AddGrade(letter_val);
                                }
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
    } 

    
}
