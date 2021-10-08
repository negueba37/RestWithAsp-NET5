using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Logging;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace RestWithASPNET5.Controllers
{
    [ApiController]
    [Route("[controller]")]
    public class CalculatorController : ControllerBase
    {
        private readonly ILogger<CalculatorController> _logger;

        public CalculatorController(ILogger<CalculatorController> logger)
        {
            _logger = logger;
        }

        [HttpGet("sum/{firstNumber}/{secoundNumber}")]
        public IActionResult Somar(string firstNumber,string secoundNumber)
        {
            if (IsNumeric(firstNumber) && IsNumeric(secoundNumber)) {
                var sum = ConvertToDecimal(firstNumber) + ConvertToDecimal(secoundNumber);
                return Ok(sum.ToString());
            }
            return BadRequest("Invalid input");
        }

        [HttpGet("sub/{firstNumber}/{secoundNumber}")]
        public IActionResult Subtrair(string firstNumber, string secoundNumber)
        {
            if (IsNumeric(firstNumber) && IsNumeric(secoundNumber))
            {
                var sum = ConvertToDecimal(firstNumber) - ConvertToDecimal(secoundNumber);
                return Ok(sum.ToString());
            }
            return BadRequest("Invalid input");
        }
        
        [HttpGet("mult/{firstNumber}/{secoundNumber}")]
        public IActionResult multiplicacao(string firstNumber, string secoundNumber)
        {
            if (IsNumeric(firstNumber) && IsNumeric(secoundNumber))
            {
                var sum = ConvertToDecimal(firstNumber) * ConvertToDecimal(secoundNumber);
                return Ok(sum.ToString());
            }
            return BadRequest("Invalid input");
        }

        [HttpGet("media/{firstNumber}/{secoundNumber}")]
        public IActionResult media(string firstNumber, string secoundNumber)
        {
            if (IsNumeric(firstNumber) && IsNumeric(secoundNumber))
            {
                var sum = ConvertToDecimal(firstNumber) + ConvertToDecimal(secoundNumber) / 2;
                return Ok(sum.ToString());
            }
            return BadRequest("Invalid input");
        }
        
        [HttpGet("raiz/{Number}")]
        public IActionResult raizQuadrada(string Number)
        {
            if (IsNumeric(Number))
            {
                var squareRoot = Math.Sqrt((double)ConvertToDecimal(Number));
                return Ok(squareRoot.ToString());
            }
            return BadRequest("Invalid input");
        }


        [HttpGet("div/{firstNumber}/{secoundNumber}")]
        public IActionResult divisao(string firstNumber, string secoundNumber)
        {
            if (IsNumeric(firstNumber) && IsNumeric(secoundNumber))
            {
                var sum = ConvertToDecimal(firstNumber) / ConvertToDecimal(secoundNumber); 
                return Ok(sum.ToString());
            }
            return BadRequest("Invalid input");
        }

        private decimal ConvertToDecimal(string strNumber)
        {
            decimal decimalValue;
            if (decimal.TryParse(strNumber, out decimalValue)) {
                return decimalValue;
            }
            return 0;
        }

        private bool IsNumeric(string strNumber)
        {
            double number;
            bool isNumber = double.TryParse(
                strNumber, System.Globalization.NumberStyles.Any,
                System.Globalization.NumberFormatInfo.InvariantInfo, 
                out number);
            return isNumber;
            
        }
    }
}
