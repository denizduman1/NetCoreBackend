using Core.Entity.Abstract;


namespace Core.Entity.Concrete
{
    public class User : EntityBase
    {
        public string FirstName { get; set; } = string.Empty;
        public string LastName { get; set; } = string.Empty;
        public string Email { get; set; } = string.Empty;
        public byte[] PasswordSalt { get; set; } = Array.Empty<byte>();
        public byte[] PasswordHash { get; set; } = Array.Empty<byte>();
        public bool Status { get; set; }
        public ICollection<UserOperationClaim> UserOperationClaims { get; set; } = new List<UserOperationClaim>();
    }
}
