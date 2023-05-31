using BikeAdventures.RentService.BusinessLayer.Models;

namespace BikeAdventures.RentService.BusinessLayer.Services
{
    public interface IRentalItemService
    {
        RentalItemDto GetRentalItem(int rentalItemId);
        IEnumerable<RentalItemDto> GetAllRentalItems();
        IEnumerable<RentalItemDto> GetRentalItemsByBike(int bikeId);
        void AddRentalItem(RentalItemDto rentalItemDto);
        void DeleteRentalItem(int rentalItemId);
    }
}
