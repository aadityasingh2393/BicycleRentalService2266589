using BicycleRentalSystem.BicycleService.BusinessLayer.Models;

namespace BicycleRentalSystem.BicycleService.BusinessLayer.Services
{
    public interface IBicycleService
    {
        IEnumerable<BicycleDto> GetBicycles();
        BicycleDto GetBicycleById(int bicycleId);
        void AddBicycle(BicycleDto bicycleDto);
        void UpdateBicycle(BicycleDto bicycleDto);
        void DeleteBicycle(int bicycleId);
    }
}
