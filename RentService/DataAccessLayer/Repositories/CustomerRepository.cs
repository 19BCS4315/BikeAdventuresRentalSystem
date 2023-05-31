using BikeAdventures.RentService.DataAccessLayer.Models;
using BikeAdventures.UserAuthentication.DataAccessLayer.Data;
using Microsoft.EntityFrameworkCore;

namespace BikeAdventures.RentService.DataAccessLayer.Repositories
{
    public class CustomerRepository : ICustomerRepository
    {
        private readonly UserData _context;
        public CustomerRepository(UserData context)
        {
            _context = context;
        }
        public Customer GetCustomer(int customerId)
        {
            var getCustomer = _context.Customers.FirstOrDefault(c => c.CustomerId == customerId);

            if (getCustomer == null)
            {
                throw new ArgumentException("No Customer found with this Id");
            }
            return getCustomer;
        }
        public IEnumerable<Customer> GetAllCustomers()
        {
            return _context.Customers.ToList();
        }
        public void AddCustomer(Customer customer)
        {
            _context.Customers.Add(customer);
            _context.SaveChanges();
        }
        public void UpdateCustomer(Customer customer)
        {
            _context.Entry(customer).State = EntityState.Modified;
            _context.SaveChanges();
        }
        public void DeleteCustomer(Customer customer)
        {
            _context.Customers.Remove(customer);
            _context.SaveChanges();
        }

        
    }
}
