using System;
using System.Collections.Generic;

// Tutorial with Scott Allen reviewing fundamentals of C# and OOP
// https://app.pluralsight.com/library/courses/csharp-fundamentals-dev/table-of-contents

namespace GradeBook
{
    class Program
    {
        public int Length { get; }
        static void Main(string[] args)
        {
            var book = new Book("Scotts GradeBook");
            book.GradeAdded += OnGradeAdded;
            book.GradeAdded += OnGradeAdded;
            book.GradeAdded -= OnGradeAdded;
            book.GradeAdded += OnGradeAdded;

            // Please Enter Grades
            // Enter q to stop entering grades and compute
            
            while(true)
            {
                Console.WriteLine("Enter a grade or type q to quit");
                var input = Console.ReadLine();
                if(input == "q"){break;}
                try
                {
                    var grade = double.Parse(input);
                    book.AddGrade(grade);
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
                    //Console.WriteLine("Do final tasks, like close a file, here");
                }
            }

            //book.AddGrade(89.1);
            //book.AddGrade(90.5);
            //book.AddGrade(77.5);

            var stats = book.GetStats();

            Console.WriteLine($"For the book named: {book.Name}");
            Console.WriteLine($"The lowest grade is {stats.Low}");
            Console.WriteLine($"The highest grade is {stats.High}");
            Console.WriteLine("{0:N2}", "Average Grade: " + stats.Average);
            Console.WriteLine("The letter grade is: " + stats.Letter);         
        }
        static void OnGradeAdded(object sender, EventArgs e)
        {
            Console.WriteLine("This grade was added");

        }
    }
}
