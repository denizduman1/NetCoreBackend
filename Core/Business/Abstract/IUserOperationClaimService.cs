using Core.DataAccess.Abstract;
using Core.Entity.Concrete.DTOs;
using Core.Utilities.Results.Abstract;

namespace Core.Business.Abstract
{
    public interface IUserOperationClaimService
    {
        IDataResult<UserOperationClaimListDto> GetAll();
        IDataResult<UserOperationClaimDto> GetById(int id);
        IResult Add(UserOperationClaimAddDto userOperationClaimAddDto);
        IResult Update(UserOperationClaimUpdateDto userOperationClaimUpdateDto);
        IResult Delete(int id);
    }
}
