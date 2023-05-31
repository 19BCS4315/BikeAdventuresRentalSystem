using BikeAdventures.RentService.DataAccessLayer.Models;

namespace BikeAdventures.RentService.DataAccessLayer.Repositories
{
    public interface IRentalRepository
    {
        Rental GetRental(int rentalId);
        IEnumerable<Rental> GetAllRental();
        IEnumerable<Rental> GetRentalsByCustomer(int customerId);
        void AddRental(Rental rental);
        void DeleteRental(Rental rental);
    }
}
