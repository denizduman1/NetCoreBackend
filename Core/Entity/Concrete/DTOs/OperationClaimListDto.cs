using Core.Entity.Abstract;

namespace Core.Entity.Concrete.DTOs
{
    public class OperationClaimListDto : DtoGetBase
    {
        public IList<OperationClaimDto> OperationClaimDtos { get; set; } = new List<OperationClaimDto>();
    }
}
