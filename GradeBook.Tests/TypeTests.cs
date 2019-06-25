using System;
using Xunit;

namespace GradeBook.Tests
{
    public class TypeTests
    {
        [Fact]
        public void GetBookReturnsDifferentObjects()
        {
            // arrange
            var book1 = GetBook("Book 1");
            var book2 = GetBook("Book 2");

            // act

            // assert
            Assert.NotSame(book1, book2);
            Assert.Equal("Book 1", book1.Name);
            Assert.Equal("Book 2", book2.Name);
        }

        [Fact]
        public void StringsBehaveLikeValueTypes()
        {
            // arrange
            string name = "Scott";

            // act
            name = MakeUpperCase(name);

            // assert
            Assert.Equal("SCOTT", name);
        }

        private string MakeUpperCase(string parameter)
        {
            return parameter.ToUpper();
        }

        [Fact]
        public void Test1()
        {
            // arrange
            var x = GetInt();

            // act
            SetInt(ref x);

            // assert
            Assert.Equal(42, x);
        }

        private void SetInt(ref int x)
        {
            x = 42;
        }

        private int GetInt()
        {
            return 3;
        }

        [Fact]
        public void TwoVariablesCanReferenceSameObject()
        {
            // arrange
            var book1 = GetBook("Book 1");
            var book2 = book1;  // NOT making a copy of the object, rather a copy of the pointer

            // act

            // assert
            Assert.Same(book1, book2);
            Assert.Equal("Book 1", book1.Name);
            Assert.Equal("Book 1", book2.Name);
        }

        [Fact]
        public void CSharpCanPassByRef()
        {
            // arrange
            var book1 = GetBook("Book 1");

            // act
            GetBookSetName(ref book1, "New Name");

            // assert
            Assert.Equal("New Name", book1.Name);
        }
        // out instead of ref, out assumes variable uninitialized and requires it be
        private void GetBookSetName(ref InMemoryBook book, string name)
        {
            book = new InMemoryBook(name);
        }

        [Fact]
        public void CSharpIsPassByValue()
        {
            // arrange
            var book1 = GetBook("Book 1");

            // act
            GetBookSetName(book1, "New Name");

            // assert
            Assert.Equal("Book 1", book1.Name);
        }

        private void GetBookSetName(InMemoryBook book, string name)
        {
            book = new InMemoryBook(name);
        }

        [Fact]
        public void CanSetNameFromReference()
        {
            // arrange
            var book1 = GetBook("Book 1");

            // act
            SetName(book1, "New Name");

            // assert
            Assert.Equal("New Name", book1.Name);
        }

        [Fact]
        public void GetStatisticsCalculatesLetterGrade()
        {
            // arrange
            var book = GetBook("book1");
            book.AddGrade(96.1);

            // act
            var result = book.GetStatistics();

            // assert
            Assert.Equal('A', result.Letter);
        }

        private void SetName(InMemoryBook book, string name)
        {
            book.Name = name;
        }

        private InMemoryBook GetBook(string name)
        {
            return new InMemoryBook(name);
        }
    }
}
