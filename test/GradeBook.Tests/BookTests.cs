using Xunit;

namespace GradeBook.Tests
{
    public delegate string WriteLogDelegate(string logMessage);
    public class BookTests
    {
        public int count = 0;
        [Fact]
        public void WriteLogDelegateCanPointToMethod()
        {
            WriteLogDelegate logDelegate = ReturnMessage;

            // add more methods to make is multucast delegate
            logDelegate += ReturnMessage;
            logDelegate += IncrementCount;


            var result = logDelegate("Hello");

            Assert.Equal(3, count);

        }
        string ReturnMessage(string message)
        {
            count++;
            return message;
        }
        string IncrementCount(string message)
        {
            count++;
            return message.ToLower();
        }


        [Fact]
        public void GetStatisstics_Returns_Statistics()
        {
            // Arrange
            var book = new InMemoryBook("Test");
            book.AddGrade(89.1);
            book.AddGrade(90.5);
            book.AddGrade(77.3);
            // Act 
            var result = book.GetStatistics();

            // Assert
            Assert.Equal(85.6, result.Average, 1);
            Assert.Equal(90.5, result.High);
            Assert.Equal(77.3, result.Low);
            Assert.Equal('B', result.Letter);
        }
    }
}
