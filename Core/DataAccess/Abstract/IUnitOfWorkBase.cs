

namespace Core.DataAccess.Abstract
{
    public interface IUnitOfWorkBase : IAsyncDisposable
    {
        public IUserRepository UserRepository { get; }
        public IUserOperationClaimRepository UserOperationClaimRepository { get; }
        public IOperationClaimRepository OperationClaimRepository { get; }
        Task<int> SaveAsync();
    }
}
