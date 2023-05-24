using BicycleRentalSystem.RentService.BusinessLayer.Models;

namespace BicycleRentalSystem.RentService.BusinessLayer.Services
{
    public interface IPaymentService
    {
        PaymentDto GetPayment(int paymentId);
        IEnumerable<PaymentDto> GetAllPayments();
        IEnumerable<PaymentDto> GetPaymentsByRental(int rentalId);
        PaymentDto AddPayment(PaymentDto paymentDto);
        void UpdatePayment(PaymentDto paymentDto);
        void DeletePayment(int paymentId);
        bool PaymentExists(int paymentId);
    }
}
