namespace BicycleRentalSystem.BicycleService.DataAccessLayer.Models
{
    public class Bicycle
    {
        public int BicycleId { get; set; }
        public string BicycleType { get; set; } = null!;
        public string Brand { get; set; } = null!;
        public string Model { get; set; } = null!;
        public DateTime PurchaseDate { get; set; }

        public decimal PurchasePrice { get; set; }
        public decimal RentalPricePerHour { get; set; }
        public decimal RentalPricePerDay { get; set; }
        public decimal RentalPricePerWeek { get; set; }
        public int AvailableQuantity { get; set; }
    }
}
