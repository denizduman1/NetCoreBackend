using Core.DataAccess.Abstract;
using Core.Entity.Concrete;
using Microsoft.EntityFrameworkCore;

namespace Core.DataAccess.Concrete.EntityFramework.Repositories
{
    public class EfOperationClaimRepository : EfEntityRepositoryBase<OperationClaim>, IOperationClaimRepository
    {
        public EfOperationClaimRepository(DbContext context) : base(context)
        {
        }
    }
}
