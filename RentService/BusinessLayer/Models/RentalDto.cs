using BikeAdventures.RentService.DataAccessLayer.Models;

namespace BikeAdventures.RentService.BusinessLayer.Models
{
    public class RentalDto
    {
        public int RentalId { get; set; }
        public int CustomerId { get; set; }
        public virtual CustomerDto CustomerDto { get; set; } = null!;
        public int RentalItemId { get; set; }
        public virtual RentalItemDto RentalItemDto { get; set; } = null!;
        
    }
}
