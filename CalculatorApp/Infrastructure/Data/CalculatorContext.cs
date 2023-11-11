using CalculatorApp.Entities;
using Microsoft.EntityFrameworkCore;

namespace CalculatorApp.Infrastructure.Data
{
    public class CalculatorContext : DbContext
    {
        public CalculatorContext(DbContextOptions<CalculatorContext> options) : base(options) { }

        public DbSet<CalculatorHistory> CalculationHistories { get; set; }

    }
}
