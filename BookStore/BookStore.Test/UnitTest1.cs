using BookStore.Models;
using Xunit;

namespace BookStore.Test
{
    public class UnitTest1
    {
        [Fact]
        public void TestGetAllBooks()
        {
            int bookCount = BasicFunctions.GetAllBooks().Count;
            Assert.Equal(3, bookCount);
        }

        [Fact]
        public void TestGetBooksByLastName() 
        {
            int bookCount = BasicFunctions.GetBooksByLastName("Chaucer").Count;
            Assert.Equal(2, bookCount);
        }

        [Fact]
        public void TestGetBookByTitle()
        {
            Book? testBook = BasicFunctions.GetBookByTitle("Canterbury Tales");
            Assert.Equal("Canterbury Tales", testBook?.BookTitle);
        }
    }
}