using System;
using Xunit;

namespace GradeBook.Tests
{
    // Dotnet runtime does garbage collection
    // Knows when no variables are using an object

    public class TypeTests
    {
        [Fact]
        public void AddGradeTest()
        {
            var book = new Book("Test");
            AddWrongGrade(book, 99);
            AddWrongGrade(book, 105);
            
        }

        private void AddWrongGrade(Book book, int v)
        {
            book.AddGrade(v);
        }

        [Fact]
        public void ValueTypesAlsoPassByValue()
        {
            var x = GetInt();
            SetInt(ref x);

            Assert.Equal(42, x);
        }

        private void SetInt(ref int z)
        {
            z = 42;
        }

        private int GetInt()
        {
            return 3;
        }

        [Fact]
        public void CSharpCanPassbyRef()
        {
            // Arrange Section
            var book1 = GetBook("Book 1");
            // Out keyword also passes by reference (replace ref)
            GetBookSetName(ref book1, "New Name");

            // Acting or Perform Section
            
            // Assert
            Assert.Equal("New Name", book1.Name);
        }

        private void GetBookSetName(ref Book book, string name)
        {
            book = new Book(name);
        }


        [Fact]
        public void CSharpIsPassByValue()
        {
            // Arrange Section
            var book1 = GetBook("Book 1");
            GetBookSetName(book1, "New Name");

            // Acting or Perform Section
            
            // Assert
            Assert.Equal("Book 1", book1.Name);
        }

        private void GetBookSetName(Book book, string name)
        {
            book = new Book(name);
            book.Name = name;
        }


        [Fact]
        public void CanSetNameFromReference()
        {

            // Arrange Section
            var book1 = GetBook("Book 1");
            SetName(book1, "New Name");

            // Acting or Perform Section
            
            // Assert
            Assert.Equal("New Name", book1.Name);
        }

        private void SetName(Book book, string name)
        {
            book.Name = name;
        }


        [Fact]
        public void StingsBehaveLikeValueTypes()
        {
            //Cant change a string once ive created it (immutable)
            string name = "Mitchell";
            var upper = MakeUpperCase(name);

            Assert.Equal("Mitchell", name);
            Assert.Equal("MITCHELL", upper);
        }

        private string MakeUpperCase(string parameter)
        {
            return parameter.ToUpper();
        }

        [Fact]
        public void GetBookReturnsDifferentObjects()
        {

            // Arrange Section
            var book1 = GetBook("Book 1");
            var book2 = GetBook("Book 2");

            // Acting or Perform Section
            
            // Assert
            Assert.Equal("Book 1", book1.Name);
            Assert.Equal("Book 2", book2.Name);
            Assert.NotSame(book1, book2);
        }

        [Fact]
        public void TwoVarsCanReferenceSameObjects()
        {

            // Arrange Section
            var book1 = GetBook("Book 1");
            var book2 = book1;

            // Acting or Perform Section
            
            // Assert
            Assert.Same(book1, book2);
            Assert.True(Object.ReferenceEquals(book1, book2));
        }

        Book GetBook(string name)
        {
            return new Book(name);
        }
    }
}
