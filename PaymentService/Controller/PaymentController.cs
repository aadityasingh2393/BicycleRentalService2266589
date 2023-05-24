using BicycleRentalSystem.RentService.BusinessLayer.Models;
using BicycleRentalSystem.RentService.BusinessLayer.Services;
using Microsoft.AspNetCore.Mvc;

namespace BicycleRentalSystem.PaymentService.Controller
{
    [Route("/api/payments")]
    [ApiController]
    public class PaymentController : ControllerBase
    {
        private readonly IPaymentService _paymentService;

        public PaymentController(IPaymentService paymentService)
        {
            _paymentService = paymentService;
        }

        [HttpGet("{id}")]
        public ActionResult<PaymentDto> GetPayment(int id)
        {
            var payment = _paymentService.GetPayment(id);

            if (payment == null)
            {
                return NotFound();
            }

            return Ok(payment);
        }

        [HttpGet("rental/{rentalId}")]
        public ActionResult<IEnumerable<PaymentDto>> GetPaymentsByRental(int rentalId)
        {
            var payments = _paymentService.GetPaymentsByRental(rentalId);

            if (payments == null || payments.Count() == 0)
            {
                return NotFound();
            }

            return Ok(payments);
        }

        [HttpPost]
        public ActionResult<PaymentDto> AddPayment(PaymentDto paymentDto)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            var payment = _paymentService.AddPayment(paymentDto);

            return CreatedAtAction(nameof(GetPayment), new { id = payment.PaymentId }, payment);
        }

        [HttpPut("{id}")]
        public IActionResult UpdatePayment(int id, PaymentDto paymentDto)
        {
            if (id != paymentDto.PaymentId)
            {
                return BadRequest();
            }

            if (!_paymentService.PaymentExists(id))
            {
                return NotFound();
            }

            _paymentService.UpdatePayment(paymentDto);

            return NoContent();
        }

        [HttpDelete("{id}")]
        public IActionResult DeletePayment(int id)
        {
            if (!_paymentService.PaymentExists(id))
            {
                return NotFound();
            }

            _paymentService.DeletePayment(id);

            return NoContent();
        }
    }
}
