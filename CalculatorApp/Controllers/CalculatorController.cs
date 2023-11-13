using CalculatorApp.Entities;
using CalculatorApp.Services.Interfaces;
using Microsoft.AspNetCore.Mvc;
using System.Linq.Expressions;

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

        [HttpPost("{expression}")]
        public IActionResult Calculate([FromBody] Expressions expression)
        {
            try
            {
                double result = _calculatorService.Calculate(expression.Request);
                return Ok(result);
            }
            catch (Exception ex)
            {
                return BadRequest(ex.Message);
            }
        }

        [HttpGet("{calculationHistory}")]
        public IActionResult GetCalculatoionHistory()
        {
            var result = _calculatorService.CalculationHistory();
            return Ok(result);
        }
       
    }
}