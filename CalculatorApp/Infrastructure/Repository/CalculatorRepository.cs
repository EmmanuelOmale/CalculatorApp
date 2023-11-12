using CalculatorApp.Entities;
using CalculatorApp.Infrastructure.Data;
using CalculatorApp.Infrastructure.Repository.Interfaces;

namespace CalculatorApp.Infrastructure.Repository
{
    public class CalculatorRepository : ICalculatorRepository
    {
        private readonly CalculatorContext _calculatorContext;

        public CalculatorRepository(CalculatorContext calculatorContext)
        {
            _calculatorContext = calculatorContext;
        }

        public void AddHistory(string expression, double result)
        {
            var history = new CalculatorHistory
            {
                Expression = expression,
                Result = result
            };

            _calculatorContext.CalculationHistories.Add(history);
            _calculatorContext.SaveChanges();
        }

        public IEnumerable<CalculatorHistory> GetHistory()
        {
            var list = _calculatorContext.CalculationHistories.ToList();
            return list;
        }
    }
}
