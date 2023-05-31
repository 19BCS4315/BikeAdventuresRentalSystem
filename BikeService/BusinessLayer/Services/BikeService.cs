using BikeAdventures.BikeService.BusinessLayer.Models;
using BikeAdventures.BikeService.DataAccessLayer.Models;
using BikeAdventures.BikeService.DataAccessLayer.Repositories;

namespace BikeAdventures.BikeService.BusinessLayer.Services
{
    public class BikeService:IBikeService
    {
        private readonly IBikeRepository _bikeRepository;
        public BikeService(IBikeRepository bikeRepository)
        {
            _bikeRepository = bikeRepository;
        }
        public IEnumerable<BikeDto> GetBikes()
        {
            try
            {
                var bikes = _bikeRepository.GetAllBikes();
                return bikes.Select(bike => new BikeDto
                {
                    BikeId = bike.BikeId,
                    BikeType = bike.BikeType,
                    Brand = bike.Brand,
                    Model = bike.Model,
                    RentalPricePerDay = bike.RentalPricePerDay,
                    RentalPricePerHour = bike.RentalPricePerHour,
                    RentalPricePerWeek = bike.RentalPricePerWeek,
                });
            }
            catch (Exception ex)
            {
                throw new Exception("An error occurred while retrieving all bikes.", ex);
            }
        }
        public BikeDto GetBikeById(int bikeId)
        {
            var bike = _bikeRepository.GetBike(bikeId);
            if (bike == null)
            {
                throw new Exception("Bike not found");
            }
            return new BikeDto
            {
                BikeId = bike.BikeId,
                BikeType = bike.BikeType,
                Brand = bike.Brand,
                Model = bike.Model,
                RentalPricePerDay = bike.RentalPricePerDay,
                RentalPricePerHour = bike.RentalPricePerHour,
                RentalPricePerWeek = bike.RentalPricePerWeek,

            };
        }
        public void AddBike(BikeDto bikeDto)
        {
            var bike = new Bike
            {
                BikeId = bikeDto.BikeId,
                BikeType = bikeDto.BikeType,
                Brand = bikeDto.Brand,
                Model = bikeDto.Model,
                RentalPricePerDay = bikeDto.RentalPricePerDay,
                RentalPricePerHour = bikeDto.RentalPricePerHour,
                RentalPricePerWeek = bikeDto.RentalPricePerWeek,
            };
            _bikeRepository.AddBike(bike);
           
        }
        public void UpdateBike(BikeDto bikeDto)
        {
            var bike = new Bike
            {
                BikeId = bikeDto.BikeId,
                BikeType = bikeDto.BikeType,
                Brand = bikeDto.Brand,
                Model = bikeDto.Model,
                RentalPricePerDay = bikeDto.RentalPricePerDay,
                RentalPricePerHour = bikeDto.RentalPricePerHour,
                RentalPricePerWeek = bikeDto.RentalPricePerWeek
            };
            _bikeRepository.UpdateBike(bike);
         
        }
        public void DeleteBike(int bikeId)
        {
            var bike = _bikeRepository.GetBike(bikeId);
            _bikeRepository.DeleteBike(bike);
            
        }
    }
}
