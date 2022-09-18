using Core.Entity.Abstract;

namespace Core.Entity.Concrete.DTOs
{
    public class OperationClaimUpdateDto : IDto
    {
        public int ID { get; set; }
        public string Name { get; set; } = string.Empty;
    }
}
