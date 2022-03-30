using DevFreela.Payments.API.Models;
using DevFreela.Payments.API.Services;
using Microsoft.AspNetCore.Mvc;

namespace DevFreela.Payments.API.Controllers
{
    [Route("api/payments")]
    public class PaymentsController : ControllerBase
    {
        private readonly IPaymentService _service;
        public PaymentsController(IPaymentService service)
        {
            _service = service;
        }
        [HttpPost]
        public async Task<IActionResult> Post([FromBody] PaymentInfoInputModel paymentInfoInputModel)
        {
            var result = await _service.Process(paymentInfoInputModel);
            if (!result) return BadRequest();

            return NoContent();
        }
    }
}
