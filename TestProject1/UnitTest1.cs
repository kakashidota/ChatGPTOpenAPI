using OpenAIApp.Controllers;
using OpenAIApp.Services;
using OpenAIApp.TestClass;

namespace TestProject1
{
    public class UnitTest1
    {
        [Fact]
        public void Add_ReturnsTwo_WithOneAndOne()
        {
            //Arrange
            var sut = new CalcMetoder();
            var input1 = 1;
            var input2 = 1;

            //ACT
            var result = sut.Add(input1, input2);

            //Assert
            Assert.Equal(2, result);
        }

        [Fact]
        public void Add_ReturnsThree_WithOneAndTwo()
        {
            //Arrange
            var sut = new CalcMetoder();
            var input1 = 1;
            var input2 = 2;
            //Act
            var result = sut.Add(input2 , input1);
            //Assert
            Assert.Equal(3, result);
        }

        [Fact]
        public void Add_ReturnsSum_WithInputOneAndTwo()
        {
            var sut = new CalcMetoder();
            var input1 = 20;
            var input2 = 3;

            var expected = input2 + input1;
            //Act
            var result = sut.Add(input2, input1);
            //Assert
            Assert.Equal(expected, result);
        }


    }
}