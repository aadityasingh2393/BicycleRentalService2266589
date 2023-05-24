using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DataAccessLayer.Repositories
{
    public interface IRentalRepository
    {
        Rental GetRental(int rentalId);
        IEnumerable<Rental> GetAllRental();
        IEnumerable<Rental> GetRentalsByBicycle(int bicycleId);
        IEnumerable<Rental> GetRentalsByCustomer(int customerId);
        IEnumerable<Rental> GetRentalsByPaymentStatus(string paymentStatus);
        void AddRental(Rental rental);
        void UpdateRental(Rental rental);
        void DeleteRental(Rental rental);
        bool RentalExists(int rentalId);
        void Save();
    }
}
