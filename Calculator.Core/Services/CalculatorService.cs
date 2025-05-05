using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Microsoft.Extensions.Logging;

namespace Calculator.Core.Services
{
    /// <summary>
    /// Provides calculation operations between two numeric values.
    /// </summary>
    public class CalculatorService : ICalculatorService
    {

        /// <summary>
        ///  Performs a basic arithmetic calculation based on the specified operation.
        /// </summary>
        /// <param name="firstNumber">The first operand.</param>
        /// <param name="secondNumber">The second operand.</param>
        /// <param name="operation">
        /// A string representing the operation to perform. 
        /// Supported values: "+", "-", "*", "/".
        /// </param>
        /// <returns>The result of the calculation.</returns>
        /// <exception cref="ArgumentException">Thrown when attempting to divide by zero.</exception>
        /// <exception cref="ArgumentException">Thrown when an unsupported operation is specified.</exception>
        public double? PerformCalculation(double? firstNumber, double? secondNumber, string operation)
        {
            return operation switch
            {
                "+" => firstNumber + secondNumber,
                "-" => firstNumber - secondNumber,
                "*" => firstNumber * secondNumber,
                "/" => secondNumber == 0
                    ? throw new ArgumentException("Cannot divide by zero.")
                    : firstNumber / secondNumber,
                _ => throw new ArgumentException($"Unsupported operation: {operation}")
            };
        }
    }
}
