using BusinessLayer.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;


namespace BusinessLayer.Services
{
    public interface IRentalService
    {
        RentalDto GetRental(int rentalId);
        IEnumerable<RentalDto> GetAllRentals();
        IEnumerable<RentalDto> GetRentalsByBicycle(int bicycleId);
        IEnumerable<RentalDto> GetRentalsByCustomer(int customerId);
        IEnumerable<RentalDto> GetRentalsByPaymentStatus(string paymentStatus);
        void AddRental(RentalDto rental);
        void UpdateRental(RentalDto rental);
        void DeleteRental(int rentalId);
        bool RentalExists(int rentalId);

        

        
    }
}
