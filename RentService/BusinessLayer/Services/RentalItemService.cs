using BicycleRentalSystem.BicycleService.DataAccessLayer.Models;
using BicycleRentalSystem.BicycleService.DataAccessLayer.Repositories;
using BusinessLayer.Models;
using DataAccessLayer;
using DataAccessLayer.Repositories;

namespace BicycleRentalSystem.RentService.BusinessLayer.Services
{
    public class RentalItemService : IRentalItemService
    {
        private readonly  IRentalItemRepository _rentalItemRepository;
        private readonly IBicycleRepository _bicycleRepository;

        public RentalItemService(IRentalItemRepository rentalItemRepository, IBicycleRepository bicycleRepository)
        {
            _rentalItemRepository = rentalItemRepository;
            _bicycleRepository = bicycleRepository;
        }

        public RentalItemDto GetRentalItem(int rentalItemId)
        {
            var rentalItem = _rentalItemRepository.GetRentalItem(rentalItemId);
            return ToRentalItemDto(rentalItem);
        }

        public IEnumerable<RentalItemDto> GetAllRentalItems()
        {
            var rentalItems = _rentalItemRepository.GetAllRentalItems();
            return rentalItems.Select(r => ToRentalItemDto(r));
        }

        public IEnumerable<RentalItemDto> GetRentalItemsByRental(int rentalId)
        {
            var rentalItems = _rentalItemRepository.GetAllRentalItems().Where(r => r.RentalId == rentalId);
            return rentalItems.Select(r => ToRentalItemDto(r));
        }

        public IEnumerable<RentalItemDto> GetRentalItemsByBicycle(int bicycleId)
        {
            var rentalItems = _rentalItemRepository.GetAllRentalItems().Where(r => r.BicycleId == bicycleId);
            return rentalItems.Select(r => ToRentalItemDto(r));
        }

        public void AddRentalItem(RentalItemDto rentalItem)
        {
            var newRentalItem = new RentalItem
            {
                RentalId = rentalItem.RentalId,
                BicycleId = rentalItem.BicycleId,
                RentalItemType = rentalItem.RentalItemType,
                RentalItemQuantity = rentalItem.RentalItemQuantity,
                RentalItemPrice = rentalItem.RentalItemPrice
            };

            _rentalItemRepository.AddRentalItem(newRentalItem);
            _rentalItemRepository.Save();
        }

        public void UpdateRentalItem(RentalItemDto rentalItem)
        {
            var existingRentalItem = _rentalItemRepository.GetRentalItem(rentalItem.RentalItemId);

            if (existingRentalItem == null)
            {
                throw new InvalidOperationException($"Rental item with ID {rentalItem.RentalItemId} not found");
            }

            // Update the properties of the existing rental item entity with the properties of the DTO
            existingRentalItem.RentalItemType = rentalItem.RentalItemType;
            existingRentalItem.RentalItemQuantity = rentalItem.RentalItemQuantity;
            existingRentalItem.RentalItemPrice = rentalItem.RentalItemPrice;
            existingRentalItem.TotalRentalItemAmount = rentalItem.TotalRentalItemAmount;

            _rentalItemRepository.Save();
        }

        public void DeleteRentalItem(int rentalItemId)
        {
            var rentalItem = _rentalItemRepository.GetRentalItem(rentalItemId);

            if (rentalItem == null)
            {
                throw new InvalidOperationException($"Rental item with ID {rentalItemId} not found");
            }

            _rentalItemRepository.DeleteRentalItem(rentalItem);
            _rentalItemRepository.Save();
        }

        public bool RentalItemExists(int rentalItemId)
        {
            var rentalItem = _rentalItemRepository.GetRentalItem(rentalItemId);
            return rentalItem != null;
        }


        private RentalItemDto ToRentalItemDto(RentalItem rentalItem)
        {
            if (rentalItem == null)
            {
                throw new Exception("Rental Id not not found");
            }

            return new RentalItemDto
            {
                RentalItemId = rentalItem.RentalItemId,
                RentalId = rentalItem.RentalId,
                BicycleId = rentalItem.BicycleId,
                RentalItemType = rentalItem.RentalItemType,
                RentalItemQuantity = rentalItem.RentalItemQuantity,
                RentalItemPrice = rentalItem.RentalItemPrice,
                TotalRentalItemAmount = rentalItem.TotalRentalItemAmount
            };
        }


    }

}

