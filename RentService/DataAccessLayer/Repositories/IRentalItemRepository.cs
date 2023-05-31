using BikeAdventures.RentService.DataAccessLayer.Models;

namespace BikeAdventures.RentService.DataAccessLayer.Repositories
{
    public interface IRentalItemRepository
    {
        RentalItem GetRentalItem(int rentalItemId);
        IEnumerable<RentalItem> GetAllRentalItems();
        IEnumerable<RentalItem> GetRentalItemsByBike(int bikeId);
        void AddRentalItem(RentalItem rentalItem);
        void DeleteRentalItem(RentalItem rentalItem);

    }
}
