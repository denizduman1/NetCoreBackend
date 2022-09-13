using Core.Entity.Abstract;

namespace Core.Entity.Concrete
{
    public class OperationClaim : EntityBase
    {
        public string Name { get; set; } = string.Empty;
        public ICollection<UserOperationClaim> UserOperationClaims { get; set; } = new List<UserOperationClaim>();
    }
}
