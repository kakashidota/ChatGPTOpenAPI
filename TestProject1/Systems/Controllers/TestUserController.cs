using FluentAssertions;
using Microsoft.AspNetCore.Mvc;
using Moq;
using OpenAIApp.Controllers;
using OpenAIApp.Services;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace TestProject1.Systems.Controllers
{
    public class TestUserController
    {
        [Fact]
        public void IsValidInput_ReturnsFalse_ForNullInput()
        {
            //Arrange
            var service = new ApiController();
            //Act
            var result = service.IsValidInput(null);
            //Assert
            Assert.False(result);
        }

        [Fact]
        public void IsValidInput_ReturnsFalse_ForEmptyInput()
        {
            var service = new ApiController();

            var result = service.IsValidInput("");

            Assert.False(result);
        }

        [Fact]
        public void IsValidInput_ReturnsFalse_ForTooLongInput()
        {
            var service = new ApiController();
            var longInput = new string('a', 4097); // Length is greater than OpenAI's limit

            var result = service.IsValidInput(longInput);

            Assert.False(result);
        }

        [Fact]
        public void IsValidInput_ReturnsTrue_ForValidInput()
        {
            var service = new ApiController();

            var result = service.IsValidInput("This is a valid input.");

            Assert.True(result);
        }
    }
}

