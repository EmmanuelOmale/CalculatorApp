namespace CalculatorApp.Services.HelperMethods
{
    public class CalculationOperation : CalculatorFunctions
    {
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
    }
}
