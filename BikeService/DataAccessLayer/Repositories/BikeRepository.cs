using BikeAdventures.BikeService.DataAccessLayer.Models;
using BikeAdventures.UserAuthentication.DataAccessLayer.Data;
using Microsoft.EntityFrameworkCore;

namespace BikeAdventures.BikeService.DataAccessLayer.Repositories
{
    public class BikeRepository : IBikeRepository
    {
        private readonly UserData _context;
        public BikeRepository(UserData context)
        {
            _context = context;
        }
        public Bike GetBike(int bikeId)
        {
            var getBike = _context.Bikes.FirstOrDefault(b => b.BikeId == bikeId);

            if (getBike == null)
            {
                throw new ArgumentException("No Bike found with this Id");
            }
            return getBike;
        }
        public IEnumerable<Bike> GetAllBikes()
        {
            return _context.Bikes.ToList();

        }
        public void AddBike(Bike bike)
        {
            _context.Bikes.Add(bike);
            _context.SaveChanges();
        }
        public void UpdateBike(Bike bike)
        {
            _context.Entry(bike).State = EntityState.Modified;
            _context.SaveChanges();
        }
        public void DeleteBike(Bike bike)
        {
            _context.Bikes.Remove(bike);
            _context.SaveChanges();
        }
       
    }
}
