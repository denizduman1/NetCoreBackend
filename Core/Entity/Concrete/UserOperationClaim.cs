using Core.Entity.Abstract;

namespace Core.Entity.Concrete
{
    public class UserOperationClaim : EntityBase{
        public int UserId { get; set; }
        public int OperationClaimId { get; set; }
    }
}
