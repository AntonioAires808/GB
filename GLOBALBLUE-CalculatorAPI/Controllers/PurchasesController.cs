using GLOBALBLUE_CalculatorAPI.Models;
using GLOBALBLUE_CalculatorAPI.Services;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace GLOBALBLUE_CalculatorAPI.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class PurchasesController : ControllerBase
    {
        private readonly ITaxCalculatorService _taxCalculatorService;
        private readonly ILogger<PurchasesController> _logger;
        public PurchasesController(ITaxCalculatorService taxCalculatorService, ILogger<PurchasesController> logger)
        {
            _taxCalculatorService = taxCalculatorService;
            _logger = logger;
        }

        [HttpGet("GetCalculatedTax")]
        public async Task<IActionResult> GetCalculatedTax([FromQuery]TaxData taxData)
        {
            try
            {
                var finalValues = await _taxCalculatorService.CalculateFinalValues(taxData);

                if (finalValues == null)
                {
                    _logger.LogInformation("Can't calculate. Please fill only one value, and no more than one.");
                    return NotFound();
                }

                _logger.LogInformation("Returning the calculated data sucessfully.");

                return Ok(finalValues);
            }
            catch (Exception ex)
            {
                _logger.LogInformation("Problem returning the data." + ex.Message + " \n\n " + ex.StackTrace);

                return BadRequest();
            }
        }
    }
}
