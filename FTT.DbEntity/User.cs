using FTT.Enums;

namespace FTT.DbEntity
{
    public class User : EntityIdentity
    {
        public Guid UserId { get; set; }
        public string Username { get; set; } = string.Empty;
        public string PasswordHash { get; set; } = string.Empty;
        public UserRole Role { get; set; }

        public string Salt { get; set; } = string.Empty;
    }
}
