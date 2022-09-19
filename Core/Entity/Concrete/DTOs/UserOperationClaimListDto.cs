using Core.Entity.Abstract;

namespace Core.Entity.Concrete.DTOs
{
    public class UserOperationClaimListDto : DtoGetBase
    {
        public IList<UserOperationClaimDto> UserOperationClaimDtos { get; set; } = new List<UserOperationClaimDto>();
    }
}
