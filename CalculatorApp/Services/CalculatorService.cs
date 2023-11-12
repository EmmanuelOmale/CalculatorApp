using CalculatorApp.Infrastructure.Repository.Interfaces;
using CalculatorApp.Services.Interfaces;

namespace CalculatorApp.Services
{
    public class CalculatorService : CalculatorFunctions, ICalculatorService
    {
        private readonly ICalculatorRepository _calculatorRepository;
        public CalculatorService(ICalculatorRepository calculatorRepository)
        {
            _calculatorRepository = calculatorRepository;
        }
        public double PerformCalculation(double num1, double num2, string operation)
        {
            double result;
            switch(operation)
            {
                case "+":
                    result = Add(num1, num2);
                    break;
                case "-":
                    result = Subtract(num1, num2);
                    break;
                case "*":
                    result = Multiply(num1, num2);
                    break;
                case "/":
                    result = Divide(num1, num2);
                    break;
                default:
                    throw new InvalidOperationException("Invalid operator, please try with the available operators");

            }
            return result;

        }

        public double Calculate(double num1, double num2, string operation)
        {
            double result = PerformCalculation(num1, num2, operation);
            _calculatorRepository.AddHistory($"{num1} {operation} {num2}", result);
            return result;
        }

    }
}