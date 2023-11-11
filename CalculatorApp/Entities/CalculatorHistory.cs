using System.ComponentModel.DataAnnotations;

namespace CalculatorApp.Entities
{
    public class CalculatorHistory
    {
        [Key]
        public int Id { get; set; }
        public string Expression { get; set; } = string.Empty;
        public double Result { get; set; } 
    }
}
