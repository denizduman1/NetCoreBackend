using Core.Entity.Abstract;

namespace Core.Entity.Concrete.DTOs
{
    public class UserOperationClaimUpdateDto : IDto
    {
        public int ID { get; set; }
        public int UserId { get; set; }
        public int OperationClaimId { get; set; }
    }
}
