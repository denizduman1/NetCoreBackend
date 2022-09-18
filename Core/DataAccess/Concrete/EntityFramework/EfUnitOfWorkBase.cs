using Core.DataAccess.Abstract;
using Core.DataAccess.Concrete.EntityFramework.Repositories;
using Microsoft.EntityFrameworkCore;

namespace Core.DataAccess.Concrete.EntityFramework
{
    public abstract class EfUnitOfWorkBase : IUnitOfWorkBase
    {
        private readonly DbContext _context;
        private readonly IUserRepository _userRepository;
        private readonly IUserOperationClaimRepository _userOperationClaimRepository;
        private readonly IOperationClaimRepository _operationClaimRepository;

        protected EfUnitOfWorkBase(DbContext context)
        {
            _context = context;
            _userRepository = new EfUserRepository(_context);
            _userOperationClaimRepository = new EfUserOperationClaimRepository(_context);
            _operationClaimRepository = new EfOperationClaimRepository(_context);
        }

        public IUserRepository UserRepository => _userRepository ?? new EfUserRepository(_context);

        public IUserOperationClaimRepository UserOperationClaimRepository => _userOperationClaimRepository ?? new EfUserOperationClaimRepository(_context);

        public IOperationClaimRepository OperationClaimRepository => _operationClaimRepository ?? new EfOperationClaimRepository(_context);

        public async ValueTask DisposeAsync()
        {
            await _context.DisposeAsync();
        }

        public async Task<int> SaveAsync()
        {
            return await _context.SaveChangesAsync();
        }
    }
}
