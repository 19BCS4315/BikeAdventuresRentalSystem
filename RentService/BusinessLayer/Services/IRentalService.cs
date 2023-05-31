using BikeAdventures.RentService.BusinessLayer.Models;

namespace BikeAdventures.RentService.BusinessLayer.Services
{
    public interface IRentalService
    {
        RentalDto GetRental(int rentalId);
        IEnumerable<RentalDto> GetAllRental();
        IEnumerable<RentalDto> GetRentalsByCustomer(int customerId);
        void AddRental(RentalDto rentalDto);
        void DeleteRental(int rentalId);
    }
}
