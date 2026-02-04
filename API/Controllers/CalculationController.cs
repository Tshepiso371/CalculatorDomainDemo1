using CalculatorDomain.Domain;  
using CalculatorDomain.Logic;
using Microsoft.AspNetCore.Mvc;
using CalculatorDomain.Domain; 
using CalculatorDomain;


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

        [HttpGet] //GET /api/calculations
        public async Task<IActionResult> GetAll()
        {
            var calculations = await _calculator.GetAllAsync(); 
            return Ok(calculations);
        }


        // 4 February 2026
        [HttpPost]
        public async Task<IActionResult> Calculate([FromBody] CreateCalculationDto dto)
        {

             if(ModelState.Invalid)
          {
            return BadRequest(ModelState);
          } 

          else
            {
                 CalculationRequest request = new(dto.left,dto.right,dto.Operand);
                 var results = await _calculator.CalculateAsync(request);
                 return Ok(results);
            }
           
        }
        
    }

}