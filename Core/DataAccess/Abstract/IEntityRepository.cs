using Core.Entity.Abstract;
using System.Linq.Expressions;


namespace Core.DataAccess.Abstract
{
    public interface IEntityRepository<T>
        where T : class, IEntity, new()
    {
        public T? Get(Expression<Func<T, bool>> predicate, params Expression<Func<T, object>>[] includes);
        public IList<T> GetAll(Expression<Func<T, bool>>? predicate = null, params Expression<Func<T, object>>[] includes);
        public void Add(T entity);
        public void Remove(T entity);
        public void Update(T entity);
        public bool Any(Expression<Func<T, bool>>? predicate = null);
        public int Count(Expression<Func<T, bool>>? predicate = null);
    }
}
