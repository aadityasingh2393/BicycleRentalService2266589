using DataAccessLayer.Data;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

using Microsoft.EntityFrameworkCore;
using BicycleRentalSystem.BicycleService.DataAccessLayer.Models;

namespace DataAccessLayer.Repositories
{
    public class RentalItemRepository : IRentalItemRepository
    {
        private readonly RentalDbContext _context;
        public RentalItemRepository(RentalDbContext context)
        {
            _context = context;
        }
        public RentalItem GetRentalItem(int rentalItemId)
        {
      
            var getRental = _context.RentalItems.FirstOrDefault(r => r.RentalItemId == rentalItemId);

            if (getRental == null)
            {
                throw new ArgumentException("No Rental item found with this Id");
            }
            return getRental;
        }
        public IEnumerable<RentalItem> GetAllRentalItems()
        {
            return _context.RentalItems.ToList();
        }
        public IEnumerable<RentalItem> GetRentalItemsByRental(int rentalId)
        {
            return _context.RentalItems.Where(r => r.RentalId == rentalId).ToList();
        }
        public IEnumerable<RentalItem> GetRentalItemsByBicycle(int bicycleId)
        {
            return _context.RentalItems.Where(r => r.BicycleId == bicycleId).ToList();
        }
        public void AddRentalItem(RentalItem rentalItem)
        {
            _context.RentalItems.Add(rentalItem);
        }
        public void UpdateRentalItem(RentalItem rentalItem)
        {
            _context.Entry(rentalItem).State = EntityState.Modified;
        }
        public void DeleteRentalItem(RentalItem rentalItem)
        {
            _context.RentalItems.Remove(rentalItem);
        }
        public bool RentalItemExists(int rentalItemId)
        {
            return _context.RentalItems.Any(r => r.RentalItemId == rentalItemId);
        }
        public void Save()
        {
            _context.SaveChanges();
        }
    }
}
