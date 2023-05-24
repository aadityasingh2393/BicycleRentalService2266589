using DataAccessLayer.Data;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

using Microsoft.EntityFrameworkCore;

namespace DataAccessLayer.Repositories
{
    public class RentalRepository : IRentalRepository
    {
        private readonly RentalDbContext _context;
        public RentalRepository(RentalDbContext context)
        {
            _context = context;
        }
        public Rental GetRental(int rentalId)
        {
            var getRental = _context.Rentals.FirstOrDefault(r => r.RentalId == rentalId);

            if (getRental == null)
            {
                throw new ArgumentException("No Rental found with this Id");
            }
            return getRental;
        }
        //- We have to check this method
        public IEnumerable<Rental> GetAllRental()
        {
            return _context.Rentals.Include(r => r.RentalItems).ToList();
        }
        public IEnumerable<Rental> GetRentalsByBicycle(int bicycleId)
        {
            return _context.Rentals.Include(r => r.RentalItems).Where(r => r.BicycleId == bicycleId).ToList();
        }
        public IEnumerable<Rental> GetRentalsByCustomer(int customerId)
        {
            return _context.Rentals.Include(r => r.RentalItems).Where(r => r.CustomerId == customerId).ToList();
        }
        public IEnumerable<Rental> GetRentalsByPaymentStatus(string paymentStatus)
        {
            return _context.Rentals.Include(r => r.RentalItems).Where(r => r.PaymentStatus == paymentStatus).ToList();
        }
        public void AddRental(Rental rental)
        {
            _context.Rentals.Add(rental);
        }
        public void UpdateRental(Rental rental)
        {
            _context.Entry(rental).State = EntityState.Modified;

        }
        public void DeleteRental(Rental rental)
        {
            _context.Rentals.Remove(rental);
        }
        public bool RentalExists(int rentalId)
        {
            return _context.Rentals.Any(r => r.RentalId == rentalId);
        }
        public void Save()
        {
            _context.SaveChanges();
        }
    }
}
