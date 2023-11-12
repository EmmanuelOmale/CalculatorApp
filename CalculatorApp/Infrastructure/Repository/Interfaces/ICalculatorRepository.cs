using CalculatorApp.Entities;

namespace CalculatorApp.Infrastructure.Repository.Interfaces
{
    public interface ICalculatorRepository
    {
        void AddHistory(string expression, double result);
        IEnumerable<CalculatorHistory> GetHistory();
    }
}
