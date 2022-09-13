using Core.Entity.Abstract;

namespace Core.Entity.Concrete
{
    public class UserOperationClaim : EntityBase{
        public int UserId { get; set; }
        public int OperationClaimId { get; set; }
        public User User { get; set; }  = new User();
        public OperationClaim OperationClaim { get; set; } = new OperationClaim();
    }
}
