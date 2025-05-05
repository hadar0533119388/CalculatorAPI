using Xunit;
using Moq;
using Microsoft.AspNetCore.Mvc;
using Calculator.Controllers;
using Calculator.Models;
using Calculator.Core.Services;
using System;
using Microsoft.Extensions.Logging;

namespace Calculator.Tests
{
    public class CalculatorApiControllerTests
    {
        private readonly Mock<ICalculatorService> _mockCalculatorService;
        private readonly Mock<ILogger<CalculatorApiController>> _mockLogger;
        private readonly CalculatorApiController _controller;

        public CalculatorApiControllerTests()
        {
            _mockCalculatorService = new Mock<ICalculatorService>();
            _mockLogger = new Mock<ILogger<CalculatorApiController>>();
            _controller = new CalculatorApiController(_mockCalculatorService.Object, _mockLogger.Object);
        }


        [Fact]
        public void Calculate_ReturnsOkResult_WhenCalculationIsSuccessful()
        {
            // Arrange
            var request = new CalculationRequest { FirstNumber = 5, SecondNumber = 3 };
            var operation = "+";
            var expectedResult = 8.0;

            _mockCalculatorService
                .Setup(service => service.PerformCalculation(request.FirstNumber, request.SecondNumber, operation))
                .Returns(expectedResult);

            // Act
            var result = _controller.Calculate(request, operation) as OkObjectResult;

            // Assert
            Assert.NotNull(result);
            Assert.Equal(200, result.StatusCode);
            Assert.Equal(expectedResult, result.Value);
        }

        [Fact]
        public void Calculate_ReturnsBadRequest_WhenArgumentExceptionIsThrown()
        {
            // Arrange
            var request = new CalculationRequest { FirstNumber = 5, SecondNumber = 0 };
            var operation = "/";

            _mockCalculatorService
                .Setup(service => service.PerformCalculation(request.FirstNumber, request.SecondNumber, operation))
                .Throws(new ArgumentException("Division by zero is not allowed."));

            // Act
            var result = _controller.Calculate(request, operation) as BadRequestObjectResult;

            // Assert
            Assert.NotNull(result);
            Assert.Equal(400, result.StatusCode);
            Assert.Equal("Division by zero is not allowed.", result.Value);
        }

        [Fact]
        public void Calculate_ReturnsInternalServerError_WhenUnexpectedExceptionIsThrown()
        {
            // Arrange
            var request = new CalculationRequest { FirstNumber = 5, SecondNumber = 3 };
            var operation = "+";

            _mockCalculatorService
                .Setup(service => service.PerformCalculation(request.FirstNumber, request.SecondNumber, operation))
                .Throws(new Exception("Unexpected error occurred."));

            // Act
            var result = _controller.Calculate(request, operation) as ObjectResult;

            // Assert
            Assert.NotNull(result);
            Assert.Equal(500, result.StatusCode);
            Assert.Equal("Unexpected error occurred.", result.Value);
        }
    }
}
