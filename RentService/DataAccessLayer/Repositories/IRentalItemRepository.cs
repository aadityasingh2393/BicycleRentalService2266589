using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DataAccessLayer.Repositories
{
    public interface IRentalItemRepository
    {
        RentalItem GetRentalItem(int rentalItemId);
        IEnumerable<RentalItem> GetAllRentalItems();
        IEnumerable<RentalItem> GetRentalItemsByRental(int rentalId);
        IEnumerable<RentalItem> GetRentalItemsByBicycle(int bicycleId);
        void AddRentalItem(RentalItem rentalItem);
        void UpdateRentalItem(RentalItem rentalItem);
        void DeleteRentalItem(RentalItem rentalItem);
        bool RentalItemExists(int rentalItemId);
        void Save();
    }
}
