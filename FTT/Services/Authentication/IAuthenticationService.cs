using FTT.Enums;

namespace FTT.Services.Authentication;

public interface IAuthenticationService
{
    bool Register(string username, string password, UserRole role);
    bool Login(string username, string password);
    bool Logout();
}

