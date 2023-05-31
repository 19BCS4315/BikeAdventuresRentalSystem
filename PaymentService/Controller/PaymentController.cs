using BikeAdventures.PaymentService.BusinessLayer.Models;
using BikeAdventures.PaymentService.BusinessLayer.Services;
using Microsoft.AspNetCore.Mvc;

namespace BikeAdventures.PaymentService.Controller
{
    [ApiController]
    [Route("/api/payments")]
    public class PaymentController : ControllerBase
    {
        private readonly IPaymentService _paymentService;

        public PaymentController(IPaymentService paymentService)
        {
            _paymentService = paymentService;
        }

        [HttpGet]
        public ActionResult<IEnumerable<PaymentDto>> GetAllPayments()
        {
            try
            {
                var payments = _paymentService.GetAllPayments();
                return Ok(payments);
            }
            catch (Exception ex)
            {
                return StatusCode(500, $"Error retrieving payments: {ex.Message}");
            }
        }

        [HttpGet("{paymentId}")]
        public ActionResult<PaymentDto> GetPaymentById(int paymentId)
        {
            try
            {
                var payment = _paymentService.GetPayment(paymentId);
                return Ok(payment);
            }
            catch (Exception ex)
            {
                return StatusCode(500, $"Error retrieving payment: {ex.Message}");
            }
        }

        [HttpGet("rental/{rentalId}")]
        public ActionResult<IEnumerable<PaymentDto>> GetPaymentsByRental(int rentalId)
        {
            try
            {
                var payments = _paymentService.GetPaymentsByRental(rentalId);
                return Ok(payments);
            }
            catch (Exception ex)
            {
                return StatusCode(500, $"Error retrieving payments: {ex.Message}");
            }
        }

        [HttpPost]
        public IActionResult AddPayment([FromBody] PaymentDto paymentDto)
        {
            try
            {
                var addedPayment = _paymentService.AddPayment(paymentDto);
                return Ok(addedPayment);
            }
            catch (Exception ex)
            {
                return StatusCode(500, $"Error adding payment: {ex.Message}");
            }
        }

        [HttpPut("{paymentId}")]
        public IActionResult UpdatePayment(int paymentId, [FromBody] PaymentDto paymentDto)
        {
            try
            {
                if (paymentDto.PaymentId != paymentId)
                {
                    return BadRequest("Invalid payment ID");
                }

                _paymentService.UpdatePayment(paymentDto);
                return Ok();
            }
            catch (Exception ex)
            {
                return StatusCode(500, $"Error updating payment: {ex.Message}");
            }
        }

        [HttpDelete("{paymentId}")]
        public IActionResult DeletePayment(int paymentId)
        {
            try
            {
                _paymentService.DeletePayment(paymentId);
                return Ok();
            }
            catch (Exception ex)
            {
                return StatusCode(500, $"Error deleting payment: {ex.Message}");
            }
        }
    }
}
