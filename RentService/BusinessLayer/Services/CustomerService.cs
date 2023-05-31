using BikeAdventures.RentService.BusinessLayer.Models;
using BikeAdventures.RentService.DataAccessLayer.Models;
using BikeAdventures.RentService.DataAccessLayer.Repositories;

namespace BikeAdventures.RentService.BusinessLayer.Services
{
    public class CustomerService : ICustomerService
    {
        private readonly ICustomerRepository _customerRepository;

        public CustomerService(ICustomerRepository customerRepository)
        {
            _customerRepository = customerRepository;
        }

        public CustomerDto GetCustomer(int customerId)
        {
            var customer = _customerRepository.GetCustomer(customerId);
            return MapToDto(customer);
        }

        public IEnumerable<CustomerDto> GetAllCustomers()
        {
            var customers = _customerRepository.GetAllCustomers();
            return customers.Select(MapToDto);
        }

        public void AddCustomer(CustomerDto customerDto)
        {
            var customer = MapToEntity(customerDto);
            _customerRepository.AddCustomer(customer);
        }

        public void UpdateCustomer(CustomerDto customerDto)
        {
            var customer = MapToEntity(customerDto);
            _customerRepository.UpdateCustomer(customer);
        }

        public void DeleteCustomer(int customerId)
        {
            var customer = _customerRepository.GetCustomer(customerId);
            _customerRepository.DeleteCustomer(customer);
        }

        private CustomerDto MapToDto(Customer customer)
        {
            return new CustomerDto
            {
                CustomerId = customer.CustomerId,
                FirstName = customer.FirstName,
                LastName = customer.LastName,
                Email = customer.Email,
                PhoneNumber = customer.PhoneNumber,
                Address = customer.Address
            };
        }

        private Customer MapToEntity(CustomerDto customerDto)
        {
            return new Customer
            {
                CustomerId = customerDto.CustomerId,
                FirstName = customerDto.FirstName,
                LastName = customerDto.LastName,
                Email = customerDto.Email,
                PhoneNumber = customerDto.PhoneNumber,
                Address = customerDto.Address
            };
        }
    }
}
