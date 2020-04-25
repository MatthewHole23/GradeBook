using System;
using Xunit;

namespace GradeBook.Tests
{
    public delegate string WriteLogDelegate(string logMessage);

    public class TypeTests
    {
        int count = 0;  // setting an int to count the numebr of times the delegate variable invokes a method.

        [Fact]
        public void WriteLogDelegateCanPointToMethod()
        {
            WriteLogDelegate log = ReturnMessage;   //count = 1

            log += ReturnMessage;   // count = 2
            log += IncrementCount;  // count = 3
            var result = log("Hello");  // redundant code 


            Assert.Equal(3, count); // this assert to checking that the delegate is infact invoking the 2 different methods
        }

        private string IncrementCount(string message)   // same type and no. of arguments as the delegate
        {
            count++;
            return message.ToLower();
        }


        private string ReturnMessage(string message)    // sam type and no. of arguments as the delegate
        {
            count++;
            return message;
        }


        [Fact]
        public void StringsBehaveLikeValueTypes()
        {
            string name = "Matthew";
            var upper = MakeUpperCase(name);

            Assert.Equal("MATTHEW", upper);
        }

        private string MakeUpperCase(string parameter)
        {
            return parameter.ToUpper();
                       
        }

        [Fact]
        public void ValueTypesAlsoPassByValue()
        {
            var x = GetInt();
            SetInt(ref x);
            Assert.Equal(46, x);
        }

        private void SetInt(ref int z)
        {
            z = 46;
        }

        private int GetInt()
        {
            return 3;
        }
        
        [Fact]
        public void CSharpcanPassByRef()
        {
            var book1 = GetBook("Book 1");
            GetBookSetName(ref book1, "New Name");

            Assert.Equal("New Name", book1.Name);

        }

        private void GetBookSetName(ref InMemoryBook book, string name)
        {
            book.Name = name;
            

        }


        [Fact]
        public void CSharpIsPassByValue()
        {
            var book1 = GetBook("Book 1");
            GetBookSetName(book1, "New Name");

            Assert.Equal("Book 1", book1.Name);

        }

        private void GetBookSetName(InMemoryBook book, string name)
        {
            book = new InMemoryBook("Matthew");
            book.Name = name;

        }


        [Fact]
        public void CanSetNameFromReference()
        {
            var book1 = GetBook("Book1");
            SetName(book1, "New Name");

            Assert.Equal("New Name", book1.Name);

        }

        private void SetName(InMemoryBook book, string name)
        {
            book.Name = name;
        }



        [Fact]
        public void GetBookReturnsDiffObjects()
        {
            // arrange
            var book1 = GetBook("Book 1");
            var book2 = GetBook("Book 2");

            // assert
            Assert.Equal("Book 1", book1.Name);
            Assert.Equal("Book 2", book2.Name);
        }

        [Fact]
        public void TwoVarsRefSameObject()
        {
            // arrange
            var book1 = GetBook("Book 1");
            
            var book2 = book1;

            // assert
            Assert.Same(book1, book2);
            Assert.True(Object.ReferenceEquals(book1, book2));
        }

        
        InMemoryBook GetBook(string name)
        {
            var book = new InMemoryBook("Matthew");
            book.Name = name;
            return book;
        }
    }
}
