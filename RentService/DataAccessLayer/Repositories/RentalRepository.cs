using BikeAdventures.RentService.DataAccessLayer.Models;
using BikeAdventures.UserAuthentication.DataAccessLayer.Data;
using Microsoft.EntityFrameworkCore;

namespace BikeAdventures.RentService.DataAccessLayer.Repositories
{

        public class RentalRepository : IRentalRepository
        {
            private readonly UserData _context;
            public RentalRepository(UserData context)
            {
                _context = context;
            }
            public Rental GetRental(int rentalId)
            {
                var getRental = _context.Rentals.FirstOrDefault(r => r.RentalId == rentalId);

                if (getRental == null)
                {
                    throw new ArgumentException("No Rental found with this Id");
                }
                return getRental;
            }
            //- We have to check this method
            public IEnumerable<Rental> GetAllRental()
            {
                return _context.Rentals.ToList();
            }
            public IEnumerable<Rental> GetRentalsByCustomer(int customerId)
            {
                return _context.Rentals.Where(r => r.CustomerId == customerId).ToList();
            }
            public void AddRental(Rental rental)
            {
                _context.Rentals.Add(rental);
                _context.SaveChanges();
            }
            public void DeleteRental(Rental rental)
            {
                _context.Rentals.Remove(rental);
                _context.SaveChanges();
            }

        }
}
