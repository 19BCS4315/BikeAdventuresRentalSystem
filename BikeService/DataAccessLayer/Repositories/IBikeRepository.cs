using BikeAdventures.BikeService.DataAccessLayer.Models;

namespace BikeAdventures.BikeService.DataAccessLayer.Repositories
{
    public interface IBikeRepository
    {
        Bike GetBike(int bikeId);
        IEnumerable<Bike> GetAllBikes();

        void AddBike(Bike bike);
        void UpdateBike(Bike bike);
        void DeleteBike(Bike bike);
        
        
    }
}
