using MobileOnlineShopSystem.UserMicroservice.Data_Access_Layer.Models;
using System.ComponentModel.DataAnnotations;

namespace BicycleRentalService.AthUser.BusinessLayer.Models
{
    public class AuthUserDto
    {
        public int AuthUserDtoId { get; set; }
        [Required]
        [StringLength(100, MinimumLength = 3)]
        public string Name { get; set; } = null!;
        [Required]
        public string Email { get; set; } = null!;
        [Required]
        [StringLength(150, MinimumLength = 6)]
        [DataType(DataType.Password)]
        public string Password { get; set; } = null!;
        [Required]
        [StringLength(150, MinimumLength = 6)]
        [DataType(DataType.Password)]
        [Compare(nameof(Password), ErrorMessage = "The password and confirmation password do not match.")]
        public string PasswordConfirmation { get; set; } = null!;
        public AuthRoleType Role { get; set; }
    }
}
