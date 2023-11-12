using CalculatorApp.Entities;

namespace CalculatorApp.Services.Interfaces
{
    public interface ICalculatorService
    {
        double PerformCalculation(double[] numbers, string[] operations);
        double Calculate(string expression);
        IEnumerable<CalculatorHistory> CalculationHistory();
    }
}
