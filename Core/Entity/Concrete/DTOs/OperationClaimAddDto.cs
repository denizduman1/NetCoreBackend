using Core.Entity.Abstract;

namespace Core.Entity.Concrete.DTOs
{
    public class OperationClaimAddDto : IDto
    {
        public string Name { get; set; } = string.Empty;
    }
}
