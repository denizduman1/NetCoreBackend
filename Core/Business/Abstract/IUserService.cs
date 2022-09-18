using Core.Entity.Concrete.DTOs;
using Core.Utilities.Results.Abstract;

namespace Core.Business.Abstract
{
    public interface IUserService
    {
        public Task<IDataResult<OperationClaimListDto>> GetClaimsByUserIdAsync(int userId);
    }
}
