using BikeAdventures.BikeService.BusinessLayer.Models;
using BikeAdventures.RentService.BusinessLayer.Models;
using BikeAdventures.RentService.DataAccessLayer.Models;
using BikeAdventures.RentService.DataAccessLayer.Repositories;

namespace BikeAdventures.RentService.BusinessLayer.Services
{
    public class RentalItemService : IRentalItemService
    {
        private readonly IRentalItemRepository _rentalItemRepository;

        public RentalItemService(IRentalItemRepository rentalItemRepository)
        {
            _rentalItemRepository = rentalItemRepository;
        }

        public RentalItemDto GetRentalItem(int rentalItemId)
        {
            var rentalItem = _rentalItemRepository.GetRentalItem(rentalItemId);
            return MapToDto(rentalItem);
        }

        public IEnumerable<RentalItemDto> GetAllRentalItems()
        {
            var rentalItems = _rentalItemRepository.GetAllRentalItems();
            return rentalItems.Select(MapToDto);
        }

        public IEnumerable<RentalItemDto> GetRentalItemsByBike(int bikeId)
        {
            var rentalItems = _rentalItemRepository.GetRentalItemsByBike(bikeId);
            return rentalItems.Select(MapToDto);
        }

        public void AddRentalItem(RentalItemDto rentalItemDto)
        {
            var rentalItem = MapToEntity(rentalItemDto);
            _rentalItemRepository.AddRentalItem(rentalItem);
        }

        public void DeleteRentalItem(int rentalItemId)
        {
            var rentalItem = _rentalItemRepository.GetRentalItem(rentalItemId);
            _rentalItemRepository.DeleteRentalItem(rentalItem);
        }

        private RentalItemDto MapToDto(RentalItem rentalItem)
        {
            return new RentalItemDto
            {
                RentalItemId = rentalItem.RentalItemId,
                BikeId = rentalItem.BikeId,
                CustomerId = rentalItem.CustomerId,
                RentalStartDate = rentalItem.RentalStartDate,
                RentalEndDate = rentalItem.RentalEndDate,
                RentalPrice = rentalItem.RentalPrice,
                

                //BikeDto = new BikeDto
                //{
                //    BikeId = rentalItem.BikeId,
                //    BikeType = rentalItem.Bike.BikeType,
                //    Brand = rentalItem.Bike.Brand,
                //    Model = rentalItem.Bike.Model,
                //    RentalPricePerHour = rentalItem.Bike.RentalPricePerHour,
                //    RentalPricePerDay = rentalItem.Bike.RentalPricePerDay,
                //    RentalPricePerWeek = rentalItem.Bike.RentalPricePerWeek
                //},
                //CustomerDto = new CustomerDto
                //{
                //    CustomerId = rentalItem.CustomerId,
                //    FirstName = rentalItem.Customer.FirstName,
                //    LastName = rentalItem.Customer.LastName,
                //    Email = rentalItem.Customer.Email,
                //    PhoneNumber = rentalItem.Customer.PhoneNumber,
                //    Address = rentalItem.Customer.Address
                //},
            };
        }

        private RentalItem MapToEntity(RentalItemDto rentalItemDto)
        {
            return new RentalItem
            {
                RentalItemId = rentalItemDto.RentalItemId,
                BikeId = rentalItemDto.BikeId,
                CustomerId = rentalItemDto.CustomerId,
                RentalStartDate = rentalItemDto.RentalStartDate,
                RentalEndDate = rentalItemDto.RentalEndDate,
                RentalPrice = rentalItemDto.RentalPrice
            };
        }
    }
}
