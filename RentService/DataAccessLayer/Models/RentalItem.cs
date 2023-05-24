using BicycleRentalSystem.BicycleService.DataAccessLayer.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DataAccessLayer
{
    public class RentalItem
    {
        public int RentalItemId { get; set; }
        public int RentalId { get; set; }
        public int BicycleId { get; set; }
        public string RentalItemType { get; set; } = string.Empty;
        public int RentalItemQuantity { get; set; }
        public decimal RentalItemPrice { get; set; }
        public decimal TotalRentalItemAmount { get; set; }
        public Rental Rental { get; set; } = null!;
        public Bicycle Bicycle { get; set; } = null!;
    }
}
