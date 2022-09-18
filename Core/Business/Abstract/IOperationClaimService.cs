using Core.DataAccess.Abstract;
using Core.Entity.Concrete;
using Core.Entity.Concrete.DTOs;
using Core.Utilities.Results.Abstract;
using System.Linq.Expressions;

namespace Core.Business.Abstract
{
    public interface IOperationClaimService
    {
        Task<IDataResult<OperationClaimListDto>> GetAllAsync();
        Task<IDataResult<OperationClaimDto>> GetByIdAsync(int id);
        Task<IResult> AddAsync(OperationClaimAddDto operationClaimAddDto);
        Task<IResult> UpdateAsync(OperationClaimUpdateDto operationClaimUpdateDto);
        Task<IResult> DeleteAsync(int id);
    }
}
