using BikeAdventures.RentService.BusinessLayer.Models;
using BikeAdventures.RentService.BusinessLayer.Services;
using Microsoft.AspNetCore.Mvc;

namespace BikeAdventures.RentService.Controller
{
    [ApiController]
    [Route("/api/rentals")]
    public class RentalController : ControllerBase
    {
        private readonly IRentalService _rentalService;

        public RentalController(IRentalService rentalService)
        {
            _rentalService = rentalService;
        }

        [HttpGet]
        public ActionResult<IEnumerable<RentalDto>> GetAllRentals()
        {
            try
            {
                var rentals = _rentalService.GetAllRental();
                return Ok(rentals);
            }
            catch (Exception ex)
            {
                return StatusCode(500, $"Error retrieving rentals: {ex.Message}");
            }
        }

        [HttpGet("{rentalId}")]
        public ActionResult<RentalDto> GetRentalById(int rentalId)
        {
            try
            {
                var rental = _rentalService.GetRental(rentalId);
                if (rental == null)
                {
                    return NotFound();
                }
                return Ok(rental);
            }
            catch (Exception ex)
            {
                return StatusCode(500, $"Error retrieving rental: {ex.Message}");
            }
        }

        [HttpPost]
        public IActionResult AddRental([FromBody] RentalDto rentalDto)
        {
            try
            {
                _rentalService.AddRental(rentalDto);
                return Ok();
            }
            catch (Exception ex)
            {
                return StatusCode(500, $"Error adding rental: {ex.Message}");
            }
        }

        [HttpDelete("{rentalId}")]
        public IActionResult DeleteRental(int rentalId)
        {
            try
            {
                _rentalService.DeleteRental(rentalId);
                return Ok();
            }
            catch (Exception ex)
            {
                return StatusCode(500, $"Error deleting rental: {ex.Message}");
            }
        }
    }
}
