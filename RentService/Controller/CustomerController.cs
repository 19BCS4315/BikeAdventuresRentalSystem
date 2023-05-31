using BikeAdventures.RentService.BusinessLayer.Models;
using BikeAdventures.RentService.BusinessLayer.Services;
using Microsoft.AspNetCore.Mvc;

namespace BikeAdventures.RentService.Controller
{
    [ApiController]
    [Route("/api/customers")]
    public class CustomerController : ControllerBase
    {
        private readonly ICustomerService _customerService;

        public CustomerController(ICustomerService customerService)
        {
            _customerService = customerService;
        }

        [HttpGet]
        public ActionResult<IEnumerable<CustomerDto>> GetAllCustomers()
        {
            try
            {
                var customers = _customerService.GetAllCustomers();
                return Ok(customers);
            }
            catch (Exception ex)
            {
                return StatusCode(500, $"Error retrieving customers: {ex.Message}");
            }
        }

        [HttpGet("{customerId}")]
        public ActionResult<CustomerDto> GetCustomerById(int customerId)
        {
            try
            {
                var customer = _customerService.GetCustomer(customerId);
                if (customer == null)
                {
                    return NotFound();
                }
                return Ok(customer);
            }
            catch (Exception ex)
            {
                return StatusCode(500, $"Error retrieving customer: {ex.Message}");
            }
        }

        [HttpPost]
        public IActionResult AddCustomer([FromBody] CustomerDto customerDto)
        {
            try
            {
                _customerService.AddCustomer(customerDto);
                return Ok();
            }
            catch (Exception ex)
            {
                return StatusCode(500, $"Error adding customer: {ex.Message}");
            }
        }

        [HttpPut("{customerId}")]
        public IActionResult UpdateCustomer(int customerId, [FromBody] CustomerDto customerDto)
        {
            try
            {
                if (customerDto.CustomerId != customerId)
                {
                    return BadRequest("Invalid customer ID");
                }

                _customerService.UpdateCustomer(customerDto);
                return Ok();
            }
            catch (Exception ex)
            {
                return StatusCode(500, $"Error updating customer: {ex.Message}");
            }
        }

        [HttpDelete("{customerId}")]
        public IActionResult DeleteCustomer(int customerId)
        {
            try
            {
                _customerService.DeleteCustomer(customerId);
                return Ok();
            }
            catch (Exception ex)
            {
                return StatusCode(500, $"Error deleting customer: {ex.Message}");
            }
        }
    }
}
