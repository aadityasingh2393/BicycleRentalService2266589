using BicycleRentalSystem.RentService.DataAccessLayer.Models;
using Microsoft.EntityFrameworkCore;

namespace BicycleRentalSystem.RentService.DataAccessLayer.Repositories
{
    public interface IPaymentRepository
    {
        Payment GetPayment(int paymentId);
        IEnumerable<Payment> GetAllPayments();
        IEnumerable<Payment> GetPaymentsByRental(int rentalId);
        void AddPayment(Payment payment);
        void UpdatePayment(Payment payment);
        void DeletePayment(Payment payment);
        bool PaymentExists(int paymentId);
        void Save();
    }
}
