using CalculatorApp.Infrastructure.Data;

namespace CalculatorApp.Infrastructure.Repository.Interfaces
{
    public interface ICalculatorRepository
    {
        void AddHistory(string expression, double result);
        IEnumerable<CalculatorRepository> GetHistory();
    }
}
