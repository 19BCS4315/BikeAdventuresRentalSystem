using BikeAdventures.UserAuthentication.BusinessLayer.Models;

namespace BikeAdventures.UserAuthentication.BusinessLayer.Services
{
    public interface IAuthUserService
    {
        void Signup(AuthUserDto authUserDto);
        AuthUserDto Login(LoginRequest loginRequest);
        string HashPassword(string password);
    }
}
