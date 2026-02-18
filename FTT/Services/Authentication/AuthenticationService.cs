using FTT.DataAccesss;
using FTT.DbEntity;
using FTT.Enums;
using System.Security.Cryptography;
using System.Text;

namespace FTT.Services.Authentication;

public class AuthenticationService : IAuthenticationService
{
    private const string Pbkdf2Prefix = "PBKDF2";
    private const int Pbkdf2Iterations = 100_000;
    private const int Pbkdf2KeySize = 32;
    private readonly IRepository<User> _userRepository = RegisteredServiceProvider.Instance.UserRepository!;

    public bool Register(string username, string password, UserRole role)
    {
        var normalizedUsername = username.Trim();

        if (string.IsNullOrWhiteSpace(normalizedUsername) || string.IsNullOrWhiteSpace(password))
        {
            return false;
        }

        if (GetUserByUsername(normalizedUsername) != null)
        {
            return false; // User already exists
        }

        var salt = GenerateSalt();
        var passwordHash = HashPassword(password, salt);

        var user = new User
        {
            Username = normalizedUsername,
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
        var normalizedUsername = username.Trim();
        var user = GetUserByUsername(normalizedUsername);

        if (user == null || !VerifyPassword(password, user.PasswordHash, user.Salt))
        {
            return false;
        }

        if (!IsPbkdf2Hash(user.PasswordHash))
        {
            user.PasswordHash = HashPassword(password, user.Salt);
            _userRepository.Update(user);
            _userRepository.Commit();
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
        var saltBytes = Convert.FromBase64String(salt);
        var hashBytes = Rfc2898DeriveBytes.Pbkdf2(
            password,
            saltBytes,
            Pbkdf2Iterations,
            HashAlgorithmName.SHA256,
            Pbkdf2KeySize);

        return $"{Pbkdf2Prefix}${Pbkdf2Iterations}${Convert.ToBase64String(hashBytes)}";
    }

    private bool VerifyPassword(string password, string storedHash, string salt)
    {
        if (IsPbkdf2Hash(storedHash))
        {
            var parts = storedHash.Split('$');
            if (parts.Length != 3 || !int.TryParse(parts[1], out var iterations))
            {
                return false;
            }

            var saltBytes = Convert.FromBase64String(salt);
            var actualHashBytes = Rfc2898DeriveBytes.Pbkdf2(
                password,
                saltBytes,
                iterations,
                HashAlgorithmName.SHA256,
                Pbkdf2KeySize);
            var expectedHashBytes = Convert.FromBase64String(parts[2]);

            return CryptographicOperations.FixedTimeEquals(actualHashBytes, expectedHashBytes);
        }

        var hash = HashPasswordLegacy(password, salt);
        return hash == storedHash;
    }

    private static bool IsPbkdf2Hash(string hash)
    {
        return hash.StartsWith($"{Pbkdf2Prefix}$", StringComparison.Ordinal);
    }

    private static string HashPasswordLegacy(string password, string salt)
    {
        using var sha256 = SHA256.Create();
        var saltedPassword = password + salt;
        var hashedBytes = sha256.ComputeHash(Encoding.UTF8.GetBytes(saltedPassword));
        return Convert.ToBase64String(hashedBytes);
    }

    private User? GetUserByUsername(string username)
    {
        return _userRepository
            .Find(x => x.Username == username)
            .FirstOrDefault();
    }

    private string GenerateSalt()
    {
        var rng = RandomNumberGenerator.Create();
        var saltBytes = new byte[16];
        rng.GetBytes(saltBytes);
        return Convert.ToBase64String(saltBytes);
    }
}
