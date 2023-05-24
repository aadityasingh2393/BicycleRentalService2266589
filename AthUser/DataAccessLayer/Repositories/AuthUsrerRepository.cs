using MobileOnlineShopSystem.UserMicroservice.Data_Access_Layer.Data;
using MobileOnlineShopSystem.UserMicroservice.Data_Access_Layer.Models;

namespace BicycleRentalService.AthUser.DataAccessLayer.Repositories
{
    public class AuthUserRepository : IAuthUserRepository
    {
        private readonly UserData _context;



        public AuthUserRepository(UserData applicationDbContext)
        {
            _context = applicationDbContext;
        }
        public AuthUser GetUserByEmail(string email)
        {
            return _context.Users.SingleOrDefault(u => u.Email == email);
        }



        public void CreateUser(AuthUser user)
        {
            _context.Users.Add(user);
            _context.SaveChanges();
        }
    }
}
