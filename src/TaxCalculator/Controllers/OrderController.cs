using Microsoft.AspNetCore.Mvc;
using TaxCalculator.Contract;
using TaxCalculator.Model;

namespace TaxCalculator.Controllers
{
    [ApiController]
    [Route("[controller]")]
    public class OrderController : ControllerBase
    {
        private readonly ILogger<OrderController> _logger;
        private readonly ITaxCalculator _taxCalculator;

        public OrderController(ILogger<OrderController> logger, ITaxCalculator taxCalculator)
        {
            _logger = logger;
            _taxCalculator = taxCalculator;
        }

        [HttpPost]
        public IActionResult Post([FromBody] Order order)
        {
            var result = _taxCalculator.CalulateTax(order);
            return Ok(result);
        }
    }
}