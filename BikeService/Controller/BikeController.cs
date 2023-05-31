
using BikeAdventures.BikeService.BusinessLayer.Models;
using BikeAdventures.BikeService.BusinessLayer.Services;
using Microsoft.AspNetCore.Mvc;

namespace BikeAdventures.BikeService.Controller
{
    [ApiController]
    [Route("/api/bikes")]
    public class BikeController : ControllerBase
    {
        private readonly IBikeService _bikeService;

        public BikeController(IBikeService bikeService)
        {
            _bikeService = bikeService;
        }

        [HttpGet]
        public ActionResult<IEnumerable<BikeDto>> GetBikes()
        {
            try
            {
                var bikes = _bikeService.GetBikes();
                return Ok(bikes);
            }
            catch (Exception ex)
            {
                return StatusCode(500, $"Error retrieving bikes: {ex.Message}");
            }
        }

        [HttpGet("{bikeId}")]
        public ActionResult<BikeDto> GetBikeById(int bikeId)
        {
            try
            {
                var bike = _bikeService.GetBikeById(bikeId);
                return Ok(bike);
            }
            catch (Exception ex)
            {
                return StatusCode(500, $"Error retrieving bike: {ex.Message}");
            }
        }

        [HttpPost]
        public IActionResult AddBike([FromBody] BikeDto bikeDto)
        {
            try
            {
                _bikeService.AddBike(bikeDto);
                return Ok();
            }
            catch (Exception ex)
            {
                return StatusCode(500, $"Error adding bike: {ex.Message}");
            }
        }

        [HttpPut("{bikeId}")]
        public IActionResult UpdateBike(int bikeId, [FromBody] BikeDto bikeDto)
        {
            try
            {
                if (bikeDto.BikeId != bikeId)
                {
                    return BadRequest("Invalid bike ID");
                }

                _bikeService.UpdateBike(bikeDto);
                return Ok();
            }
            catch (Exception ex)
            {
                return StatusCode(500, $"Error updating bike: {ex.Message}");
            }
        }

        [HttpDelete("{bikeId}")]
        public IActionResult DeleteBike(int bikeId)
        {
            try
            {
                _bikeService.DeleteBike(bikeId);
                return Ok();
            }
            catch (Exception ex)
            {
                return StatusCode(500, $"Error deleting bike: {ex.Message}");
            }
        }
    }
}
