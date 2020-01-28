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
            book.AddGrade(89.1);
            book.AddGrade(90.5);
            book.AddGrade(77.5);
            book.ShowStats();        
        }
    }
}
