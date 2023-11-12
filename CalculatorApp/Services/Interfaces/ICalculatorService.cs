namespace CalculatorApp.Services.Interfaces
{
    public interface ICalculatorService
    {
        double PerformCalculation(double num1, double num2, string opreation);
        double Calculate(double num1, double num2, string opreation);
    }
}
