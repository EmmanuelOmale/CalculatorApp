using CalculatorApp.Infrastructure.Repository.Interfaces;
using CalculatorApp.Services.Interfaces;
using System;
using System.Linq;

namespace CalculatorApp.Services
{
    public class CalculatorService : CalculatorFunctions, ICalculatorService
    {
        private readonly ICalculatorRepository _calculatorRepository;

        public CalculatorService(ICalculatorRepository calculatorRepository)
        {
            _calculatorRepository = calculatorRepository;
        }

        public double PerformCalculation(double[] numbers, string[] operations)
        {
            if (numbers.Length == 0)
            {
                throw new InvalidOperationException("At least one number is required for calculation.");
            }

            double result = numbers[0];

            for (int i = 0; i < operations.Length; i++)
            {
                if (i + 1 < numbers.Length)
                {
                    switch (operations[i])
                    {
                        case "+":
                            result = Add(result, numbers[i + 1]);
                            break;
                        case "-":
                            result = Subtract(result, numbers[i + 1]);
                            break;
                        case "*":
                            result = Multiply(result, numbers[i + 1]);
                            break;
                        case "/":
                            result = Divide(result, numbers[i + 1]);
                            break;
                        default:
                            throw new InvalidOperationException($"Invalid operator '{operations[i]}'. Please use valid operators: +, -, *, /");
                    }
                }
                else
                {
                    throw new InvalidOperationException("Mismatched number of numbers and operators.");
                }
            }

            return result;
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
