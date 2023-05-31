namespace BikeAdventures.RentService.DataAccessLayer.Models
{
    public class Rental
    {
        public int RentalId { get; set; }
        public int CustomerId { get; set; }
        public Customer Customer { get; set; } = null!;
        public int RentalItemId { get; set; }
        public RentalItem RentalItem { get; set; } = null!;
        

    }
}
