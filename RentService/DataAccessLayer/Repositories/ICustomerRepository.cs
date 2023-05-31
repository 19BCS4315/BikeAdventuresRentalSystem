using BikeAdventures.RentService.DataAccessLayer.Models;

namespace BikeAdventures.RentService.DataAccessLayer.Repositories
{
    public interface ICustomerRepository
    {
        Customer GetCustomer(int customerId);
        IEnumerable<Customer> GetAllCustomers();
        void AddCustomer(Customer customer);
        void UpdateCustomer(Customer customer);
        void DeleteCustomer(Customer customer);

    }
}
