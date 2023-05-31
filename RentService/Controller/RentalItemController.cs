using BikeAdventures.RentService.BusinessLayer.Models;
using BikeAdventures.RentService.BusinessLayer.Services;
using Microsoft.AspNetCore.Mvc;

namespace BikeAdventures.RentService.Controller
{
    [ApiController]
    [Route("/api/rentalitems")]
    public class RentalItemController : ControllerBase
    {
        private readonly IRentalItemService _rentalItemService;

        public RentalItemController(IRentalItemService rentalItemService)
        {
            _rentalItemService = rentalItemService;
        }

        [HttpGet]
        public ActionResult<IEnumerable<RentalItemDto>> GetAllRentalItems()
        {
            try
            {
                var rentalItems = _rentalItemService.GetAllRentalItems();
                return Ok(rentalItems);
            }
            catch (Exception ex)
            {
                return StatusCode(500, $"Error retrieving rental items: {ex.Message}");
            }
        }

        [HttpGet("{rentalItemId}")]
        public ActionResult<RentalItemDto> GetRentalItemById(int rentalItemId)
        {
            try
            {
                var rentalItem = _rentalItemService.GetRentalItem(rentalItemId);
                if (rentalItem == null)
                {
                    return NotFound();
                }
                return Ok(rentalItem);
            }
            catch (Exception ex)
            {
                return StatusCode(500, $"Error retrieving rental item: {ex.Message}");
            }
        }

        [HttpPost]
        public IActionResult AddRentalItem([FromBody] RentalItemDto rentalItemDto)
        {
            try
            {
                _rentalItemService.AddRentalItem(rentalItemDto);
                return Ok();
            }
            catch (Exception ex)
            {
                return StatusCode(500, $"Error adding rental item: {ex.Message}");
            }
        }

        [HttpDelete("{rentalItemId}")]
        public IActionResult DeleteRentalItem(int rentalItemId)
        {
            try
            {
                _rentalItemService.DeleteRentalItem(rentalItemId);
                return Ok();
            }
            catch (Exception ex)
            {
                return StatusCode(500, $"Error deleting rental item: {ex.Message}");
            }
        }
    }
}
