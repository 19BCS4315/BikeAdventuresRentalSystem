using BikeAdventures.UserAuthentication.DataAccessLayer.Data;
using BikeAdventures.UserAuthentication.DataAccessLayer.Models;

namespace BikeAdventures.UserAuthentication.DataAccessLayer.Repositories
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
