using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BusinessLayer.Models
{
    public class RentalItemDto
    {
        public int RentalItemId { get; set; }
        public int RentalId { get; set; }
        public int BicycleId { get; set; }
        public string RentalItemType { get; set; } = string.Empty;
        public int RentalItemQuantity { get; set; }
        public decimal RentalItemPrice { get; set; }
        public decimal TotalRentalItemAmount { get; set; }
    }
}
