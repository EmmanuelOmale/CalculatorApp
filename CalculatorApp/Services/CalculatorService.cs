using CalculatorApp.Infrastructure.Repository.Interfaces;
using CalculatorApp.Services.HelperMethods;
using CalculatorApp.Services.Interfaces;
using System;
using System.Linq;

namespace CalculatorApp.Services
{
    public class CalculatorService : CalculationOperation, ICalculatorService
    {
        private readonly ICalculatorRepository _calculatorRepository;

        public CalculatorService(ICalculatorRepository calculatorRepository)
        {
            _calculatorRepository = calculatorRepository;
        }

        public double Calculate(string expression)
        {
            // Split the expression into numbers and operators
            string[] parts = expression.Split(' ', StringSplitOptions.RemoveEmptyEntries);

            // Separate numbers and operators into arrays
            double[] numbers = parts.Where((x, i) => i % 2 == 0).Select(double.Parse).ToArray();
            string[] operations = parts.Where((x, i) => i % 2 != 0).ToArray();

            double result = PerformCalculation(numbers, operations);

            _calculatorRepository.AddHistory(expression, result);
            return result;
        }
    }
}
