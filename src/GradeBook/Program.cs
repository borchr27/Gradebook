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
            book.AddGrade(98);
            book.AddGrade(90.5);

            var result = 0.0; 
            var grades = new List<double>() {82.6, 60.3, 104};
            grades.Add(56.1);

            foreach (var val in grades)
            {
                result += val;
            } 
            result /= grades.Count;
            Console.WriteLine(result);           
        }
    }
}
