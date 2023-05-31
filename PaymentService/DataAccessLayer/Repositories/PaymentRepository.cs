using BikeAdventures.PaymentService.DataAccessLayer.Models;
using BikeAdventures.UserAuthentication.DataAccessLayer.Data;
using Microsoft.EntityFrameworkCore;

namespace BikeAdventures.PaymentService.DataAccessLayer.Repositories
{
    public class PaymentRepository : IPaymentRepository
    {
        private readonly UserData _context;

        public PaymentRepository(UserData context)
        {
            _context = context;
        }

        public Payment GetPayment(int paymentId)
        {
            var getPayment = _context.Payments.FirstOrDefault(c => c.PaymentId == paymentId);

            if (getPayment == null)
            {
                throw new ArgumentException("No Payment found with this Id");
            }
            return getPayment;
        }

        public IEnumerable<Payment> GetAllPayments()
        {
            return _context.Payments.ToList();
        }

        public IEnumerable<Payment> GetPaymentsByRental(int rentalId)
        {
            return _context.Payments.Where(p => p.RentalId == rentalId).ToList();
        }

        public void AddPayment(Payment payment)
        {
            _context.Payments.Add(payment);
            _context.SaveChanges();
        }

        public void UpdatePayment(Payment payment)
        {
            _context.Entry(payment).State = EntityState.Modified;
            _context.SaveChanges();
        }

        public void DeletePayment(Payment payment)
        {
            _context.Payments.Remove(payment);
            _context.SaveChanges();
        }


    }
}
