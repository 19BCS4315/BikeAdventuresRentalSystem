using BikeAdventures.PaymentService.BusinessLayer.Models;
using BikeAdventures.PaymentService.DataAccessLayer.Models;
using BikeAdventures.PaymentService.DataAccessLayer.Repositories;

namespace BikeAdventures.PaymentService.BusinessLayer.Services
{
    public class PaymentService : IPaymentService
    {
        private readonly IPaymentRepository _paymentRepository;

        public PaymentService(IPaymentRepository paymentRepository)
        {
            _paymentRepository = paymentRepository;
        }

        public PaymentDto GetPayment(int paymentId)
        {
            var payment = _paymentRepository.GetPayment(paymentId);
            if (payment == null)
            {
                throw new Exception("Payment not not found");
            }
            return new PaymentDto
            {
                PaymentId = payment.PaymentId,
                RentalId = payment.RentalId,
                PaymentType = payment.PaymentType,
                PaymentDate = payment.PaymentDate,
                PaymentAmount = payment.PaymentAmount,
                PaymentStatus = payment.PaymentStatus,

            };
        }

        public IEnumerable<PaymentDto> GetAllPayments()
        {
            var payments = _paymentRepository.GetAllPayments();
            return payments.Select(payment => new PaymentDto
            {
                PaymentId = payment.PaymentId,
                RentalId = payment.RentalId,
                PaymentType = payment.PaymentType,
                PaymentDate = payment.PaymentDate,
                PaymentAmount = payment.PaymentAmount,
                PaymentStatus = payment.PaymentStatus,

            });
        }

        public IEnumerable<PaymentDto> GetPaymentsByRental(int rentalId)
        {
            var payments = _paymentRepository.GetPaymentsByRental(rentalId);
            return payments.Select(payment => new PaymentDto
            {
                PaymentId = payment.PaymentId,
                RentalId = payment.RentalId,
                PaymentType = payment.PaymentType,
                PaymentDate = payment.PaymentDate,
                PaymentAmount = payment.PaymentAmount,
                PaymentStatus = payment.PaymentStatus,

            });
        }

        public PaymentDto AddPayment(PaymentDto paymentDto)
        {
            var payment = new Payment
            {
                RentalId = paymentDto.RentalId,
                PaymentType = paymentDto.PaymentType,
                PaymentDate = paymentDto.PaymentDate,
                PaymentAmount = paymentDto.PaymentAmount,
                PaymentStatus = paymentDto.PaymentStatus,

            };
            _paymentRepository.AddPayment(payment);
            paymentDto.PaymentId = payment.PaymentId;
            return paymentDto;
        }

        public void UpdatePayment(PaymentDto paymentDto)
        {
            var payment = _paymentRepository.GetPayment(paymentDto.PaymentId);
            if (payment == null)
            {
                return;
            }
            payment.RentalId = paymentDto.RentalId;
            payment.PaymentType = paymentDto.PaymentType;
            payment.PaymentDate = paymentDto.PaymentDate;
            payment.PaymentAmount = paymentDto.PaymentAmount;
            payment.PaymentStatus = paymentDto.PaymentStatus;
            _paymentRepository.UpdatePayment(payment);
        }

        public void DeletePayment(int paymentId)
        {
            var payment = _paymentRepository.GetPayment(paymentId);
            if (payment == null)
            {
                return;
            }
            _paymentRepository.DeletePayment(payment);
        }

       
    }
}
