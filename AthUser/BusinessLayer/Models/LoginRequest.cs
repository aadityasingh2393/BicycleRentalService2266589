using System.ComponentModel.DataAnnotations;

namespace BicycleRentalService.AthUser.BusinessLayer.Models
{
   public class LoginRequest
    {
        [Required]
        [EmailAddress]
        public string Email { get; set; } = null!;
        [Required]
        public string Password { get; set; } = null!;
    }
}
