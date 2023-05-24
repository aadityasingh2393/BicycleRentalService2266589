using BicycleRentalSystem.RentService.DataAccessLayer.Data;
using BicycleRentalSystem.RentService.DataAccessLayer.Models;
using DataAccessLayer;
using Microsoft.EntityFrameworkCore;

namespace BicycleRentalSystem.RentService.DataAccessLayer.Repositories
{
    public class PaymentRepository : IPaymentRepository
    {
        private readonly PaymentDbContext _context;

        public PaymentRepository(PaymentDbContext context)
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
        }

        public void UpdatePayment(Payment payment)
        {
            _context.Entry(payment).State = EntityState.Modified;
        }

        public void DeletePayment(Payment payment)
        {
            _context.Payments.Remove(payment);
        }

        public bool PaymentExists(int paymentId)
        {
            return _context.Payments.Any(p => p.PaymentId == paymentId);
        }

        public void Save()
        {
            _context.SaveChanges();
        }
    }
}
