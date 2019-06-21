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
        public void Test1()
        {
            // arrange
            var book1 = GetBook("Book 1");

            // act
            SetName(book1, "New Name");

            // assert
            Assert.Equal("Book 1", book1.Name);
        }

        private void SetName(Book book, string name)
        {
            book.Name = name;
        }

        private Book GetBook(string name)
        {
            return new Book(name);
        }
    }
}
