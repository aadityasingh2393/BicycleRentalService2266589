using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BusinessLayer.Models
{
    public class RentalDto
    {
        public int RentalId { get; set; }
        public int BicycleId { get; set; }
        public int CustomerId { get; set; }
        public string RentalType { get; set; } = string.Empty;
        public DateTime RentalStartDate { get; set; }
        public DateTime RentalEndDate { get; set; }
        public int RentalDuration { get; set; }
        public decimal TotalRentalAmount { get; set; }
        public string PaymentStatus { get; set; } = string.Empty;
        public IEnumerable<RentalItemDto> RentalItems { get; set; } = null!;


    }
}
