using CalculatorApp.Entities;
using CalculatorApp.Services.Interfaces;
using Microsoft.AspNetCore.Mvc;
using System.Linq.Expressions;
using System.Net;

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

        [HttpPost("[action]")]
        [ProducesResponseType((int) HttpStatusCode.OK)]
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

        [HttpGet("[action]")]
        [ProducesResponseType((int)HttpStatusCode.OK)]
        [ProducesResponseType((int)HttpStatusCode.NotFound)]
        public IActionResult GetCalculationHistory()
        {
            var result = _calculatorService.CalculationHistory();
            return Ok(result);
        }

    }
}