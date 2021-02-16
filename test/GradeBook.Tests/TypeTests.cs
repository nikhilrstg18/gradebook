using System;
using Xunit;

namespace GradeBook.Tests
{
    public class TypeTests
    {
        [Fact]
        public void StringsBehaveLikeValueTypes()
        {
            string name = "Nikhil";

            var upper = MakeUpperCase(name);

            Assert.Equal("Nikhil", name);
            Assert.Equal("NIKHIL", upper);

        }
        private string MakeUpperCase(string name)
        {
            return name.ToUpper();
        }

        [Fact]
        public void ValueTypesCanPassByRef()
        {
            var x = GetInt();
            SetInt(ref x);
            Assert.Equal(42, x);
        }
        // private void SetInt(ref int z)
        private void SetInt(ref int z)
        {
            z = 42;
        }
        private int GetInt()
        {
            return 3;
        }

        [Fact]
        public void CSharpCanPassByReference()
        {
            var book1 = new InMemoryBook("Book1");
            GetBookSetName(out book1, "NewBook1");

            Assert.Equal("NewBook1", book1.Name);
        }

        private void GetBookSetName(out InMemoryBook book, string name)
        {
            book = new InMemoryBook(name);
        }


        [Fact]
        public void CSharpIsPassByValue()
        {
            var book1 = new InMemoryBook("Book1");
            GetBookSetName(book1, "NewBook1");

            Assert.Equal("Book1", book1.Name);
        }
        private void GetBookSetName(InMemoryBook book, string name)
        {
            book = new InMemoryBook(name);
            book.Name = name;
        }

        [Fact]
        public void CanSetNameFromReference()
        {
            var book1 = new InMemoryBook("Book1");

            SetName(book1, "NewBook1");

            Assert.Equal("NewBook1", book1.Name);
        }
        private void SetName(InMemoryBook book, string name)
        {
            book.Name = name;
        }

        [Fact]
        public void TwoVarsCanReferenceSameObject()
        {
            var book1 = GetBook("Book1");
            var book2 = book1;

            Assert.Equal("Book1", book1.Name);
            Assert.Equal("Book1", book2.Name);
            Assert.Same(book1, book2);
            Assert.True(Object.ReferenceEquals(book1, book2));
        }
        [Fact]
        public void GetBookReturnsDifferentObject()
        {
            var book1 = GetBook("Book1");
            var book2 = GetBook("Book2");

            Assert.Equal("Book1", book1.Name);
            Assert.Equal("Book2", book2.Name);
        }
        private InMemoryBook GetBook(string name)
        {
            return new InMemoryBook(name);
        }
    }
}