using Core.DataAccess.Abstract;
using Core.Entity.Concrete;
using Microsoft.EntityFrameworkCore;

namespace Core.DataAccess.Concrete.EntityFramework.Repositories
{
    public class EfUserOperationClaimRepository : EfEntityRepositoryBase<UserOperationClaim>, IUserOperationClaimRepository
    {
        public EfUserOperationClaimRepository(DbContext context) : base(context)
        {
        }
    }
}
