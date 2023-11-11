using CalculatorApp.Services.Interfaces;

namespace CalculatorApp.Services
{
    public class CalculatorService : ICalculatorService
    {
       public double Calculate(double num1, double num2, string operation)
        {
            switch(operation)
            {
                case "+":
                    return Add(num1, num2);
                case "-":
                    return Subtract(num1, num2);
                case "*":
                    return Multiply(num1, num2);
                case "/":
                    return Divide(num1, num2);
                default:
                    throw new InvalidOperationException("Invalid operator, please try with the available operators");

            }

        }

        public double Add(double num1, double num2)
        {
            return num1 + num2;
        }

        public double Subtract(double num1, double num2)
        {
            return num1 - num2;
        }

        public double Multiply(double num1, double num2)
        {
            return num1 * num2;
        }

        public double Divide(double num1, double num2)
        {
            return num1 / num2;
        }

    }
}