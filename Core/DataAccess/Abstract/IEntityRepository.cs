using Core.Entity.Abstract;
using System.Linq.Expressions;


namespace Core.DataAccess.Abstract
{
    public interface IEntityRepository<T> 
        where T : class, IEntity, new()
    {
        public Task<T?> GetAsync(Expression<Func<T, bool>> predicate, params Expression<Func<T, object>>[] includes);
        public Task<IList<T>> GetAllAsync(Expression<Func<T,bool>>? predicate = null, params Expression<Func<T, object>>[] includes);
        public Task AddAsync(T entity);
        public Task RemoveAsync(T entity);
        public Task UpdateAsync(T entity);
        public Task<bool> AnyAsync(Expression<Func<T,bool>>? predicate = null);
        public Task<int> CountAsync(Expression<Func<T,bool>>? predicate = null);
    }
}
