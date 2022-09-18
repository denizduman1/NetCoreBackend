using Core.Entity.Abstract;

namespace Core.Entity.Concrete.DTOs
{
    public class OperationClaimDto : DtoGetBase
    {
        public string Name { get; set; } = string.Empty;
    }
}
