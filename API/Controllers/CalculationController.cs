using CalculatorDomainDemo.Domain;
using CalculatorDomain.Logic;
using Microsoft.AspNetCore.Mvc;
using CalculatorDomainDemo;


namespace API.controllers
{
    [ApiController]
    [Route("api/calculations")]
    public class CalculationsController : ControllerBase
    {
        private readonly CalculatorService _calculator;

        public CalculationsController(CalculatorService calculator)
        {
            _calculator = calculator;
        }

        [HttpPost] //POST /api/calculations
        public async Task<IActionResult> Calculate([FromBody] CreateCalculationDto dto)
        {

            try {         // 05 Feb 2026
        
             var request = new CalculationRequest(
                dto.left,
                dto.right,
                dto.operand
                );
                var calculation = await _calculator.CalculateAsync(request);

                var response = new CalculationResultDto
                {
                    Result = calculation.Result,
                    Operation = calculation.Operation.ToString()
                };

                return Ok(response);

                   
            }
            catch (ArgumentException ex)
            {
                return BadRequest(new { error = ex.Message });
            }


        }

    }

}