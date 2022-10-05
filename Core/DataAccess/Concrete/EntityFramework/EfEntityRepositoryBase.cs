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

        public void Add(T entity)
        {
            _context.Set<T>().Add(entity);
            _context.SaveChanges();
        }

        public bool Any(Expression<Func<T, bool>>? predicate = null)
        {
            if (predicate != null)
            {
                return _context.Set<T>().Any(predicate);
            }
            return _context.Set<T>().Any();
        }

        public int Count(Expression<Func<T, bool>>? predicate = null)
        {
            if (predicate != null)
            {
                return _context.Set<T>().Count(predicate);
            }
            return _context.Set<T>().Count();
        }

        public IList<T> GetAll(Expression<Func<T, bool>>? predicate = null, params Expression<Func<T, object>>[] includes)
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
            return query.ToList();
        }

        public T? Get(Expression<Func<T, bool>> predicate, params Expression<Func<T, object>>[] includes)
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
            return query.SingleOrDefault() ?? null;
        }

        public void Remove(T entity)
        {
            _context.Set<T>().Remove(entity);
            _context.SaveChanges();
        }

        public void Update(T entity)
        {
            _context.Set<T>().Update(entity);
            _context.SaveChanges();
        }
    }
}
