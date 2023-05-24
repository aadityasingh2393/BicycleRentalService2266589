using BicycleRentalSystem.BicycleService.DataAccessLayer.Data;
using BicycleRentalSystem.BicycleService.DataAccessLayer.Models;
using Microsoft.EntityFrameworkCore;


namespace BicycleRentalSystem.BicycleService.DataAccessLayer.Repositories
{
    public class BicycleRepository : IBicycleRepository
    {
        private readonly BicycleDbContext _context;
        public BicycleRepository(BicycleDbContext context)
        {
            _context = context;
        }
        public Bicycle GetBicycle(int bicycleId)
        {
            var getBicycle = _context.Bicycle.FirstOrDefault(b=>b.BicycleId == bicycleId);

            if(getBicycle == null)
            {
                throw new ArgumentException("No Bicycle found with this Id");
            }
            return getBicycle;
        }
        public IEnumerable<Bicycle> GetAllBicycle()
        {
            return _context.Bicycle.ToList();

        }
        public IEnumerable<Bicycle> GetAvailableBicycle()
        {
            return _context.Bicycle.Where(b => b.AvailableQuantity > 0);
        }
        public void AddBicycle(Bicycle bicycle)
        {
            _context.Bicycle.Add(bicycle);
        }
        public void UpdateBicycle(Bicycle bicycle)
        {
            _context.Entry(bicycle).State = EntityState.Modified;
        }
        public void DeleteBicycle(Bicycle bicycle)
        {
            _context.Bicycle.Remove(bicycle);
        }
        public bool BicycleExists(int bicycleId)
        {
            return _context.Bicycle.Any(b => b.BicycleId == bicycleId);
        }
        public void Save()
        {
            _context.SaveChanges();
        }
        public void UpdateBicycle(IEnumerable<Bicycle> bicycle)
        {
            foreach (var b in bicycle)
            {
                var existingBicycle = _context.Bicycle.FirstOrDefault(ba => ba.BicycleId == b.BicycleId &&
                                                                     ba.BicycleType == b.BicycleType &&
                                                                     ba.Brand == b.Brand &&
                                                                     ba.Model == b.Model &&
                                                                     ba.PurchaseDate == b.PurchaseDate &&
                                                                     ba.PurchasePrice == b.PurchasePrice &&
                                                                     ba.RentalPricePerHour == b.RentalPricePerHour &&
                                                                     ba.RentalPricePerDay == b.RentalPricePerDay &&
                                                                     ba.RentalPricePerWeek == b.RentalPricePerWeek &&
                                                                     ba.AvailableQuantity == b.AvailableQuantity);
                if (existingBicycle != null)
                {
                    existingBicycle.BicycleId = b.BicycleId;
                    existingBicycle.BicycleType = b.BicycleType;
                    existingBicycle.Brand = b.Brand;
                    existingBicycle.Model = b.Model;
                    existingBicycle.PurchaseDate = b.PurchaseDate;
                    existingBicycle.PurchasePrice = b.PurchasePrice;
                    existingBicycle.RentalPricePerHour = b.RentalPricePerHour;
                    existingBicycle.RentalPricePerDay = b.RentalPricePerDay;
                    existingBicycle.RentalPricePerWeek = b.RentalPricePerWeek;
                    existingBicycle.AvailableQuantity = b.AvailableQuantity;
                }

            }
        }
    }
}
