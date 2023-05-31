using BikeAdventures.BikeService.DataAccessLayer.Models;

namespace BikeAdventures.RentService.DataAccessLayer.Models
{
    public class RentalItem
    {
        public int RentalItemId { get; set; }
        public int BikeId { get; set; }
        public Bike Bike { get; set; } = null!;
        public int CustomerId { get; set; }
        public Customer Customer { get; set; } = null!;
        public DateTime RentalStartDate { get; set; }
        public DateTime RentalEndDate { get; set; }
        public decimal RentalPrice { get; set; }
    }
}
