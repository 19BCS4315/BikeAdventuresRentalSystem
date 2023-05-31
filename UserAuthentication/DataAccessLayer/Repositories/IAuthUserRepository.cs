using BikeAdventures.UserAuthentication.DataAccessLayer.Models;

namespace BikeAdventures.UserAuthentication.DataAccessLayer.Repositories
{
    public interface IAuthUserRepository
    {
        AuthUser GetUserByEmail(string email);
        void CreateUser(AuthUser user);
    }
}
