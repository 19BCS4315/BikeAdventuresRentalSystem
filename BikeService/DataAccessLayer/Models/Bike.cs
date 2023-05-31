namespace BikeAdventures.BikeService.DataAccessLayer.Models
{
    public class Bike
    {
        public int BikeId { get; set; }
        public string BikeType { get; set; } = string.Empty;
        public string Brand { get; set; } = string.Empty;
        public string Model { get; set; } = string.Empty;
        public decimal RentalPricePerHour { get; set; }
        public decimal RentalPricePerDay { get; set; }
        public decimal RentalPricePerWeek { get; set; }
    }
}
