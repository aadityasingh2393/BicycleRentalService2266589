using BicycleRentalSystem.BicycleService.DataAccessLayer.Models;

namespace BicycleRentalSystem.BicycleService.DataAccessLayer.Repositories
{
    public interface IBicycleRepository
    {
        Bicycle GetBicycle(int bicycleId);
        IEnumerable<Bicycle> GetAllBicycle();
        IEnumerable<Bicycle> GetAvailableBicycle();

        void AddBicycle(Bicycle bicycle);
        void UpdateBicycle(Bicycle bicycle);
        void DeleteBicycle(Bicycle bicycle);
        bool BicycleExists(int bicycleId);
        void Save();
        void UpdateBicycle(IEnumerable<Bicycle> bicycle);
    }
}
