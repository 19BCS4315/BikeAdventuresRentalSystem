using BikeAdventures.RentService.DataAccessLayer.Models;
using BikeAdventures.UserAuthentication.DataAccessLayer.Data;
using Microsoft.EntityFrameworkCore;

namespace BikeAdventures.RentService.DataAccessLayer.Repositories
{
    public class RentalItemRepository : IRentalItemRepository
    {
        private readonly UserData _context;
        public RentalItemRepository(UserData context)
        {
            _context = context;
        }
        public RentalItem GetRentalItem(int rentalItemId)
        {

            var getRental = _context.RentalItems.FirstOrDefault(r => r.RentalItemId == rentalItemId);

            if (getRental == null)
            {
                throw new ArgumentException("No Rental item found with this Id");
            }
            return getRental;
        }
        public IEnumerable<RentalItem> GetAllRentalItems()
        {
            return _context.RentalItems.ToList();
        }
        public IEnumerable<RentalItem> GetRentalItemsByBike(int bikeId)
        {
            return _context.RentalItems.Where(r => r.BikeId == bikeId).ToList();
        }
        public void AddRentalItem(RentalItem rentalItem)
        {
            _context.RentalItems.Add(rentalItem);
            _context.SaveChanges();
        }
        public void DeleteRentalItem(RentalItem rentalItem)
        {
            _context.RentalItems.Remove(rentalItem);
            _context.SaveChanges();
        }
    }
}
