using BicycleRentalService.AthUser.BusinessLayer.Models;

namespace BicycleRentalService.AthUser.BusinessLayer.Services
{
    public interface IAuthUserService
    {
        void Signup(AuthUserDto authUserDto);
        AuthUserDto Login(LoginRequest loginRequest);
        string HashPassword(string password);
    }
}
