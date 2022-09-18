using Core.DataAccess.Abstract;
using Core.Entity.Concrete;
using Microsoft.EntityFrameworkCore;


namespace Core.DataAccess.Concrete.EntityFramework.Repositories
{
    //EntityFramework 6.0.8
    public class EfUserRepository : EfEntityRepositoryBase<User>, IUserRepository
    {
        public EfUserRepository(DbContext context) : base(context)
        {
        }
    }
}
