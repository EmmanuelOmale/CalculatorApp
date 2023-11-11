using CalculatorApp.Services.Interfaces;
using Microsoft.AspNetCore.Mvc;

namespace CalculatorApp.Controllers
{
    [ApiController]
    [Route("[controller]")]
    public class CalculatorController : ControllerBase
    {
        private readonly ICalculatorService _calculatorService;

        public CalculatorController(ICalculatorService calculatorService)
        {
            _calculatorService = calculatorService;
        }

        [HttpGet]
        public IActionResult Calculate(double num1, double num2, string operation)
        {
           double result = _calculatorService.Calculate(num1, num2, operation);
            return Ok(result);
        }
    }
}