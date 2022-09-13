using Core.DataAccess.Abstract;
using Core.Entity.Abstract;
using Microsoft.EntityFrameworkCore;
using System.Linq.Expressions;

namespace Core.DataAccess.Concrete.EntityFramework
{
    //EntityFramework 6.0.8
    public abstract class EfEntityRepositoryBase<T> : IEntityRepository<T> where T : class, IEntity, new()
    {
        private readonly DbContext _context;

        protected EfEntityRepositoryBase(DbContext context)
        {
            _context = context;
        }

        public async Task AddAsync(T entity)
        {
            await _context.Set<T>().AddAsync(entity);
        }

        public async Task<bool> AnyAsync(Expression<Func<T, bool>>? predicate = null)
        {
            if (predicate != null)
            {
                return await _context.Set<T>().AnyAsync(predicate);
            }
            return await _context.Set<T>().AnyAsync();
        }

        public async Task<int> CountAsync(Expression<Func<T, bool>>? predicate = null)
        {
            if (predicate != null)
            {
                return await _context.Set<T>().CountAsync(predicate);
            }
            return await _context.Set<T>().CountAsync();
        }

        public async Task<IList<T>> GetAllAsync(Expression<Func<T, bool>>? predicate = null, params Expression<Func<T, object>>[] includes)
        {
            IQueryable<T> query = _context.Set<T>();
            if (predicate != null)
            {
                query = query.Where(predicate);
            }
            if (includes.Any())
            {
                foreach (var inc in includes)
                {
                    query = query.Include(inc);
                }
            }
            return await query.ToListAsync();
        }

        public async Task<T?> GetAsync(Expression<Func<T, bool>> predicate, params Expression<Func<T, object>>[] includes)
        {
            IQueryable<T> query = _context.Set<T>();
            if (predicate != null)
            {
                query = query.Where(predicate);
            }
            if (includes.Any())
            {
                foreach (var inc in includes)
                {
                    query = query.Include(inc);
                }
            }
            return await query.SingleOrDefaultAsync() ?? null; 
        }

        public async Task RemoveAsync(T entity)
        {
            await Task.Run(() => _context.Set<T>().Remove(entity));
        }

        public async Task UpdateAsync(T entity)
        {
            await Task.Run(() => _context.Set<T>().Update(entity));
        }
    }
}
