using Xunit;
using Calculator.Core.Services;
using System;
using Microsoft.Extensions.Logging;
using Moq;

namespace Calculator.Tests
{
    public class CalculatorServiceTests
    {
        private readonly CalculatorService _calculatorService;
        private readonly Mock<ILogger<CalculatorService>> _mockLogger;

        public CalculatorServiceTests()
        {
            _mockLogger = new Mock<ILogger<CalculatorService>>();
            _calculatorService = new CalculatorService();
        }

        [Fact]
        public void PerformCalculation_Addition_ReturnsCorrectResult()
        {
            // Arrange
            double? firstNumber = 5;
            double? secondNumber = 3;
            string operation = "+";

            // Act
            var result = _calculatorService.PerformCalculation(firstNumber, secondNumber, operation);

            // Assert
            Assert.Equal(8, result);
        }

        [Fact]
        public void PerformCalculation_Subtraction_ReturnsCorrectResult()
        {
            // Arrange
            double? firstNumber = 5;
            double? secondNumber = 3;
            string operation = "-";

            // Act
            var result = _calculatorService.PerformCalculation(firstNumber, secondNumber, operation);

            // Assert
            Assert.Equal(2, result);
        }

        [Fact]
        public void PerformCalculation_Multiplication_ReturnsCorrectResult()
        {
            // Arrange
            double? firstNumber = 5;
            double? secondNumber = 3;
            string operation = "*";

            // Act
            var result = _calculatorService.PerformCalculation(firstNumber, secondNumber, operation);

            // Assert
            Assert.Equal(15, result);
        }

        [Fact]
        public void PerformCalculation_Division_ReturnsCorrectResult()
        {
            // Arrange
            double? firstNumber = 6;
            double? secondNumber = 3;
            string operation = "/";

            // Act
            var result = _calculatorService.PerformCalculation(firstNumber, secondNumber, operation);

            // Assert
            Assert.Equal(2, result);
        }

        [Fact]
        public void PerformCalculation_DivisionByZero_ThrowsArgumentException()
        {
            // Arrange
            double? firstNumber = 6;
            double? secondNumber = 0;
            string operation = "/";

            // Act & Assert
            var exception = Assert.Throws<ArgumentException>(() =>
                _calculatorService.PerformCalculation(firstNumber, secondNumber, operation));
            Assert.Equal("Cannot divide by zero.", exception.Message);
        }

        [Fact]
        public void PerformCalculation_UnsupportedOperation_ThrowsArgumentException()
        {
            // Arrange
            double? firstNumber = 6;
            double? secondNumber = 3;
            string operation = "%";

            // Act & Assert
            var exception = Assert.Throws<ArgumentException>(() =>
                _calculatorService.PerformCalculation(firstNumber, secondNumber, operation));
            Assert.Equal("Unsupported operation.", exception.Message);
        }
    }
}
