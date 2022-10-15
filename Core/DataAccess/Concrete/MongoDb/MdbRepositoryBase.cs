using Core.DataAccess.Abstract;
using Core.Entity.Abstract;
using MongoDB.Driver;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using System.Text;
using System.Threading.Tasks;

namespace Core.DataAccess.Concrete.MongoDb
{
    public abstract class MdbRepositoryBase<T, TContext> : IEntityRepository<T>
         where T : class, IEntity, new()
         where TContext : MongoDbBaseContext, new()
    {
        private TContext _context;
        private IMongoCollection<T> _collection;

        public MdbRepositoryBase(TContext context, string collectionName)
        {
            _context = context;
            _collection = _context.ConnectToMongo<T>(collectionName);
        }

        public void Add(T entity)
        {
            _collection.InsertOne(entity);
        }

        public bool Any(Expression<Func<T, bool>>? predicate = null)
        {
            return predicate != null ? _collection.Find(predicate).ToList().Any() : _collection.Find(_ => true).ToList().Any();
        }

        public int Count(Expression<Func<T, bool>>? predicate = null)
        {
            return predicate != null ? _collection.Find(predicate).ToList().Count() : _collection.Find(_ => true).ToList().Count();
        }

        public T? Get(Expression<Func<T, bool>> predicate, params Expression<Func<T, object>>[] includes)
        {
            IList<T> entities = predicate != null ? _collection.Find(predicate).ToList() : _collection.Find(_ => true).ToList();
            return entities.FirstOrDefault();
        }

        public IList<T> GetAll(Expression<Func<T, bool>>? predicate = null, params Expression<Func<T, object>>[] includes)
        {
            return predicate != null ? _collection.Find(predicate).ToList() : _collection.Find(_ => true).ToList();
        }

        public void Remove(T entity)
        {
            //_collection.DeleteOne(e=>e.Id);
        }

        public void Update(T entity)
        {
            //throw new NotImplementedException();
        }
    }
}
