using System.ComponentModel.DataAnnotations;

namespace CalculatorMVC.Models
{
    public class Calculator
    {
        [Key]
        public int Id { get; set; }
        public string? mathExpression { get; set; }
    }
}
