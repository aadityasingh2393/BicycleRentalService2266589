
using BusinessLayer.Models;
using BusinessLayer.Services;
using DataAccessLayer;
using DataAccessLayer.Repositories;

namespace BicycleRentalSystem.RentService.BusinessLayer.Services
{
    public class RentalService : IRentalService
    {
        private readonly IRentalRepository _rentalRepository;
        private readonly IRentalItemRepository _rentalItemRepository;
        private readonly ICustomerRepository _customerRepository;

        public RentalService(IRentalRepository rentalRepository,
                             IRentalItemRepository rentalItemRepository,
                             ICustomerRepository customerRepository)
        {
            _rentalRepository = rentalRepository;
            _rentalItemRepository = rentalItemRepository;
            _customerRepository = customerRepository;
        }

        public RentalDto GetRental(int rentalId)
        {
            var rental = _rentalRepository.GetRental(rentalId);
            if (rental == null)
            {
                throw new Exception("Rental Id not not found");
            }

            var customer = _customerRepository.GetCustomer(rental.CustomerId);

            return new RentalDto
            {
                RentalId = rental.RentalId,
                CustomerId = rental.CustomerId,
                BicycleId = rental.BicycleId,
                RentalType = rental.RentalType,
                RentalStartDate = rental.RentalStartDate,
                RentalEndDate = rental.RentalEndDate,
                RentalDuration = rental.RentalDuration,
                TotalRentalAmount = rental.TotalRentalAmount,
                PaymentStatus = rental.PaymentStatus
            };
        }

        public IEnumerable<RentalDto> GetAllRentals()
        {
            var rentals = _rentalRepository.GetAllRental();

            return rentals.Select(rental => new RentalDto
            {
                RentalId = rental.RentalId,
                CustomerId = rental.CustomerId,
                RentalType = rental.RentalType,
                RentalStartDate = rental.RentalStartDate,
                RentalEndDate = rental.RentalEndDate,
                RentalDuration = rental.RentalDuration,
                TotalRentalAmount = rental.TotalRentalAmount,
                PaymentStatus = rental.PaymentStatus
            });
        }

        public IEnumerable<RentalDto> GetRentalsByBicycle(int bicycleId)
        {
            var rentalItems = _rentalItemRepository.GetAllRentalItems()
                .Where(ri => ri.BicycleId == bicycleId)
                .Select(ri => ri.RentalId)
                .Distinct();

            var rentals = _rentalRepository.GetAllRental()
                .Where(r => rentalItems.Contains(r.RentalId));

            return rentals.Select(rental => new RentalDto
            {
                RentalId = rental.RentalId,
                CustomerId = rental.CustomerId,
                RentalType = rental.RentalType,
                RentalStartDate = rental.RentalStartDate,
                RentalEndDate = rental.RentalEndDate,
                RentalDuration = rental.RentalDuration,
                TotalRentalAmount = rental.TotalRentalAmount,
                PaymentStatus = rental.PaymentStatus
            });
        }

        public IEnumerable<RentalDto> GetRentalsByCustomer(int customerId)
        {
            var rentals = _rentalRepository.GetAllRental()
                .Where(r => r.CustomerId == customerId);

            return rentals.Select(rental => new RentalDto
            {
                RentalId = rental.RentalId,
                CustomerId = rental.CustomerId,
                RentalType = rental.RentalType,
                RentalStartDate = rental.RentalStartDate,
                RentalEndDate = rental.RentalEndDate,
                RentalDuration = rental.RentalDuration,
                TotalRentalAmount = rental.TotalRentalAmount,
                PaymentStatus = rental.PaymentStatus
            });
        }
        public IEnumerable<RentalDto> GetRentalsByPaymentStatus(string paymentStatus)
        {
            var rentals = _rentalRepository.GetAllRental().Where(r => r.PaymentStatus == paymentStatus);
            var rentalDtos = new List<RentalDto>();

            foreach (var rental in rentals)
            {
                var rentalDto = new RentalDto
                {
                    RentalId = rental.RentalId,
                    CustomerId = rental.CustomerId,
                    RentalType = rental.RentalType,
                    RentalStartDate = rental.RentalStartDate,
                    RentalEndDate = rental.RentalEndDate,
                    RentalDuration = rental.RentalDuration,
                    TotalRentalAmount = rental.TotalRentalAmount,
                    PaymentStatus = rental.PaymentStatus
                };

                rentalDtos.Add(rentalDto);
            }

            return rentalDtos;
        }

        public void AddRental(RentalDto rental)
        {
            var newRental = new Rental
            {
                CustomerId = rental.CustomerId,
                RentalType = rental.RentalType,
                RentalStartDate = rental.RentalStartDate,
                RentalEndDate = rental.RentalEndDate,
                RentalDuration = rental.RentalDuration,
                TotalRentalAmount = rental.TotalRentalAmount,
                PaymentStatus = rental.PaymentStatus
            };

            _rentalRepository.AddRental(newRental);
            _rentalRepository.Save();
        }
        public void UpdateRental(RentalDto rental)
        {
            var existingRental = _rentalRepository.GetRental(rental.RentalId);
            if (existingRental == null)
            {
                throw new ArgumentException($"Rental with id {rental.RentalId} not found");
            }
            existingRental.CustomerId = rental.CustomerId;
            existingRental.RentalType = rental.RentalType;
            existingRental.RentalStartDate = rental.RentalStartDate;
            existingRental.RentalEndDate = rental.RentalEndDate;
            existingRental.RentalDuration = rental.RentalDuration;
            existingRental.TotalRentalAmount = rental.TotalRentalAmount;
            existingRental.PaymentStatus = rental.PaymentStatus;
            _rentalRepository.UpdateRental(existingRental);
            _rentalRepository.Save();
        }

        public void DeleteRental(int rentalId)
        {
            var existingRental = _rentalRepository.GetRental(rentalId);
            if (existingRental == null)
            {
                throw new ArgumentException($"Rental with id {rentalId} not found");
            }
            _rentalRepository.DeleteRental(existingRental);
            _rentalRepository.Save();
        }

        public bool RentalExists(int rentalId)
        {
            return _rentalRepository.GetRental(rentalId) != null;
        }
    }
}
