using BikeAdventures.PaymentService.DataAccessLayer.Models;

namespace BikeAdventures.PaymentService.DataAccessLayer.Repositories
{
    public interface IPaymentRepository
    {
        Payment GetPayment(int paymentId);
        IEnumerable<Payment> GetAllPayments();
        IEnumerable<Payment> GetPaymentsByRental(int rentalId);
        void AddPayment(Payment payment);
        void UpdatePayment(Payment payment);
        void DeletePayment(Payment payment);
       
        
    }
}
