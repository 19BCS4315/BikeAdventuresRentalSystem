using BikeAdventures.RentService.BusinessLayer.Models;
using BikeAdventures.RentService.DataAccessLayer.Models;
using BikeAdventures.RentService.DataAccessLayer.Repositories;

namespace BikeAdventures.RentService.BusinessLayer.Services
{
    public class RentalService : IRentalService
    {
        private readonly IRentalRepository _rentalRepository;

        public RentalService(IRentalRepository rentalRepository)
        {
            _rentalRepository = rentalRepository;
        }

        public RentalDto GetRental(int rentalId)
        {
            var rental = _rentalRepository.GetRental(rentalId);
            return MapToDto(rental);
        }

        public IEnumerable<RentalDto> GetAllRental()
        {
            var rentals = _rentalRepository.GetAllRental();
            return rentals.Select(MapToDto);
        }

        public IEnumerable<RentalDto> GetRentalsByCustomer(int customerId)
        {
            var rentals = _rentalRepository.GetRentalsByCustomer(customerId);
            return rentals.Select(MapToDto);
        }

        public void AddRental(RentalDto rentalDto)
        {
            var rental = MapToEntity(rentalDto);
            _rentalRepository.AddRental(rental);
        }

        public void DeleteRental(int rentalId)
        {
            var rental = _rentalRepository.GetRental(rentalId);
            _rentalRepository.DeleteRental(rental);
        }

        private RentalDto MapToDto(Rental rental)
        {
            return new RentalDto
            {
                RentalId = rental.RentalId,
                CustomerId = rental.CustomerId,
                RentalItemId = rental.RentalItemId,
                //CustomerDto= new CustomerDto
                //{
                //    CustomerId = rental.CustomerId,
                //    FirstName=rental.Customer.FirstName,
                //    LastName=rental.Customer.LastName,
                //    Email=rental.Customer.Email,
                //    PhoneNumber=rental.Customer.PhoneNumber,
                //    Address=rental.Customer.Address
                //},
                //RentalItemDto=new RentalItemDto
                //{
                //    RentalItemId=rental.RentalItemId,
                //    BikeId=rental.RentalItem.Bike.BikeId,
                //    CustomerId=rental.RentalItem.Customer.CustomerId,
                //    RentalStartDate=rental.RentalItem.RentalStartDate,
                //    RentalEndDate=rental.RentalItem.RentalEndDate,
                //    RentalPrice=rental.RentalItem.RentalPrice,
                //    //BikeDto or CustomerDto
                //}
                
            };
        }

        private Rental MapToEntity(RentalDto rentalDto)
        {
            return new Rental
            {
                RentalId = rentalDto.RentalId,
                CustomerId = rentalDto.CustomerId,
                RentalItemId = rentalDto.RentalItemId
            };
        }
    }
}
