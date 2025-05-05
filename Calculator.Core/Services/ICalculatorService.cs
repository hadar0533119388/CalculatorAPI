using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Calculator.Core.Services
{
    /// <summary>
    /// Provides calculation operations between two numeric values.
    /// </summary>
    public interface ICalculatorService
    {
        double? PerformCalculation(double? firstNumber, double? secondNumber, string operation);
    }
}
