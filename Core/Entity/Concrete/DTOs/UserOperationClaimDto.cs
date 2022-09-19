using Core.Entity.Abstract;

namespace Core.Entity.Concrete.DTOs
{
    public class UserOperationClaimDto : DtoGetBase
    {
        public User User { get; set; } = new User();
        public OperationClaim OperationClaim { get; set; } = new OperationClaim();
    }
}
