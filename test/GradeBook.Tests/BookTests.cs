using System;
using Xunit;

namespace GradeBook.Tests
{
    
    public class BookTests
    {
        [Fact]
        public void BookCalsAvgGrade()
        {
            // arrange
            var book = new InMemoryBook();
            book.Name = "Matthew";
            book.AddGrade(89.1, "Grade 1");
            book.AddGrade(70.28, "Grade 2");
            book.AddGrade(59.72, "Grade 3");
            var expected = 73.03;
            // act
            var stats = book.GetStatistics();


            // assert
            Assert.Equal(expected, stats.Average, 2); // the 2 is the number of decimal place accuracy
            Assert.Equal(89.1, stats.High, 2);
            //Assert.Equal(59.72, stats.Low, 2);
            //Assert.Equal('B', stats.Letter);
        }

        [Fact]
        public void ValidGradeEntry()
        {
            var book = new InMemoryBook();
            book.Name = "Matt";
            // adding an illegal value to the grades list for object 'book'

            // Checking that an 'ArgumentException' is thrown when an illegal grade is inputted

            Assert.Throws<ArgumentException>(() => book.AddGrade(105, "Grade n")); 

        }

        

    }
}
