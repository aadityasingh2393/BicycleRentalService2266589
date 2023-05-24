using BicycleRentalSystem.BicycleService.BusinessLayer.Models;
using BicycleRentalSystem.BicycleService.DataAccessLayer.Models;
using BicycleRentalSystem.BicycleService.DataAccessLayer.Repositories;

namespace BicycleRentalSystem.BicycleService.BusinessLayer.Services
{
    public class BicycleService : IBicycleService
    {
        private readonly IBicycleRepository _bicycleRepository;
        public BicycleService(IBicycleRepository bicycleRepository)
        {
            _bicycleRepository = bicycleRepository;
        }
        public IEnumerable<BicycleDto> GetBicycles()
        {
            var bicycle = _bicycleRepository.GetAllBicycle();
            return bicycle.Select(bicycle => new BicycleDto
            {
                BicycleId = bicycle.BicycleId,
                BicycleType = bicycle.BicycleType,
                Brand = bicycle.Brand,
                Model = bicycle.Model,
                PurchaseDate = bicycle.PurchaseDate,
                PurchasePrice = bicycle.PurchasePrice,
                RentalPricePerDay = bicycle.RentalPricePerDay,
                RentalPricePerHour = bicycle.RentalPricePerHour,
                RentalPricePerWeek = bicycle.RentalPricePerWeek,
                AvailableQuantity = bicycle.AvailableQuantity
            });
        }
        public BicycleDto GetBicycleById(int bicycleId)
        {
            var bicycle = _bicycleRepository.GetBicycle(bicycleId);
            if (bicycle == null)
            {
                throw new Exception("Bicycle not found");
            }
            return new BicycleDto
            {
                BicycleId = bicycle.BicycleId,
                BicycleType = bicycle.BicycleType,
                Brand = bicycle.Brand,
                Model = bicycle.Model,
                PurchaseDate = bicycle.PurchaseDate,
                PurchasePrice = bicycle.PurchasePrice,
                RentalPricePerDay = bicycle.RentalPricePerDay,
                RentalPricePerHour = bicycle.RentalPricePerHour,
                RentalPricePerWeek = bicycle.RentalPricePerWeek,
                AvailableQuantity = bicycle.AvailableQuantity
            };
        }
        public void AddBicycle(BicycleDto bicycleDto)
        {
            var bicycle = new Bicycle
            {
                BicycleId = bicycleDto.BicycleId,
                BicycleType = bicycleDto.BicycleType,
                Brand = bicycleDto.Brand,
                Model = bicycleDto.Model,
                PurchaseDate = bicycleDto.PurchaseDate,
                PurchasePrice = bicycleDto.PurchasePrice,
                RentalPricePerDay = bicycleDto.RentalPricePerDay,
                RentalPricePerHour = bicycleDto.RentalPricePerHour,
                RentalPricePerWeek = bicycleDto.RentalPricePerWeek,
                AvailableQuantity = bicycleDto.AvailableQuantity
            };
            _bicycleRepository.AddBicycle(bicycle);
            _bicycleRepository.Save();
        }
        public void UpdateBicycle(BicycleDto bicycleDto)
        {
            var bicycle = _bicycleRepository.GetAllBicycle();
            _bicycleRepository.UpdateBicycle(bicycle);
            _bicycleRepository.Save();
        }
        public void DeleteBicycle(int bicycleId)
        {
            var bicycle = _bicycleRepository.GetBicycle(bicycleId);
            _bicycleRepository.DeleteBicycle(bicycle);
            _bicycleRepository.Save();
        }
    }
}
