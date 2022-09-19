using Core.DataAccess.Abstract;
using Core.Entity.Concrete.DTOs;
using Core.Utilities.Results.Abstract;

namespace Core.Business.Abstract
{
    public interface IUserOperationClaimService
    {
        Task<IDataResult<UserOperationClaimListDto>> GetAllAsync();
        Task<IDataResult<UserOperationClaimDto>> GetByIdAsync(int id);
        Task<IResult> AddAsync(UserOperationClaimAddDto userOperationClaimAddDto);
        Task<IResult> UpdateAsync(UserOperationClaimUpdateDto userOperationClaimUpdateDto);
        Task<IResult> DeleteAsync(int id);
    }
}
