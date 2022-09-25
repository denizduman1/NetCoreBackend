using Core.Entity.Concrete;
using Core.Entity.Concrete.DTOs;
using Core.Utilities.Results.Abstract;

namespace Core.Business.Abstract
{
    public interface IUserService
    {
        public Task<IDataResult<OperationClaimListDto>> GetClaimsByUserIdAsync(int userId);
        public Task<IResult> AddAsync(User user);
        public Task<IDataResult<User>> GetByMailAsync(string mail);
    }
}
