using Core.Utilities.Results.ComplexTypes;


namespace Core.Entity.Abstract
{
    public abstract class DtoGetBase : IDto
    {
        public virtual ResultStatus ResultStatus { get; set; }
        public virtual string Message { get; set; } = string.Empty;
    }
}
