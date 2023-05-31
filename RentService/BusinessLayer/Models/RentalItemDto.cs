using BikeAdventures.BikeService.BusinessLayer.Models;
using BikeAdventures.BikeService.DataAccessLayer.Models;
using BikeAdventures.RentService.DataAccessLayer.Models;

namespace BikeAdventures.RentService.BusinessLayer.Models
{
    public class RentalItemDto
    {
        public int RentalItemId { get; set; }
        public int BikeId { get; set; }
        public int CustomerId { get; set; }
        public DateTime RentalStartDate { get; set; }
        public DateTime RentalEndDate { get; set; }
        public decimal RentalPrice { get; set; }
        public virtual BikeDto BikeDto { get; set; } = null!;
        public virtual CustomerDto CustomerDto { get; set; } = null!;
    }
}
