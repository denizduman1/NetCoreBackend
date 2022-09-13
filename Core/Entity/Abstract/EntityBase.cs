namespace Core.Entity.Abstract
{
    public abstract class EntityBase : IEntity
    {
        public int ID { get; set; }
        public bool Deleted { get; set; }
        public DateTime CreatedDate { get; set; }
        public DateTime ModifiedDate { get; set; }
    }
}
