using FTT.DataAccesss;
using FTT.DbEntity;
using FTT.Enums;
using Microsoft.Extensions.DependencyInjection;
using System.Security.Cryptography;
using System.Text;

namespace FTT.Services.Authentication;

public class AuthenticationService : IAuthenticationService
{
    private readonly IRepository<User> _userRepository;

    public AuthenticationService()
    {
        _userRepository = Session.Instance.ServiceProvider.GetRequiredService<IRepository<User>>();
    }

    public bool Register(string username, string password, UserRole role)
    {
        if (GetUserByUsername(username) != null)
        {
            return false; // User already exists
        }

        var salt = GenerateSalt();
        var passwordHash = HashPassword(password, salt);

        var user = new User
        {
            Username = username,
            PasswordHash = passwordHash,
            Role = role,
            Salt = salt,
            UserId = Guid.NewGuid(),
        };

        _userRepository.Add(user);
        _userRepository.Commit();

        return (user.Id > 0);
    }

    public bool Login(string username, string password)
    {
        var user = GetUserByUsername(username);

        if (user == null || !VerifyPassword(password, user.PasswordHash, user.Salt))
        {
            return false;
        }

        Session.Instance.CurrentUser = user;

        return Session.Instance.CurrentUser != null;
    }

    public bool Logout()
    {
        Session.Instance.CurrentUser = null!;

        return Session.Instance.CurrentUser == null;
    }

    private string HashPassword(string password, string salt)
    {
        using var sha256 = SHA256.Create();
        var saltedPassword = password + salt;
        var hashedBytes = sha256.ComputeHash(Encoding.UTF8.GetBytes(saltedPassword));
        return Convert.ToBase64String(hashedBytes);
    }

    private bool VerifyPassword(string password, string storedHash, string salt)
    {
        var hash = HashPassword(password, salt);
        return hash == storedHash;
    }

    private User? GetUserByUsername(string username)
    {
        return _userRepository
            .Find(x => x.Username == username)
            .FirstOrDefault();
    }

    private string GenerateSalt()
    {
        var rng = new RNGCryptoServiceProvider();
        var saltBytes = new byte[16];
        rng.GetBytes(saltBytes);
        return Convert.ToBase64String(saltBytes);
    }
}

