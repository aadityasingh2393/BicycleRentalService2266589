using MobileOnlineShopSystem.UserMicroservice.Data_Access_Layer.Models;

namespace BicycleRentalService.AthUser.DataAccessLayer.Repositories
{
    public interface IAuthUserRepository
    {
        AuthUser GetUserByEmail(string email);
        void CreateUser(AuthUser user);
    }
}
