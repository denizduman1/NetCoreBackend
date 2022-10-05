using Core.DataAccess.Abstract;
using Core.Entity.Concrete;
using Core.Entity.Concrete.DTOs;
using Core.Utilities.Results.Abstract;
using System.Linq.Expressions;

namespace Core.Business.Abstract
{
    public interface IOperationClaimService
    {
        IDataResult<OperationClaimListDto> GetAll();
        IDataResult<OperationClaimDto> GetById(int id);
        IResult Add(OperationClaimAddDto operationClaimAddDto);
        IResult Update(OperationClaimUpdateDto operationClaimUpdateDto);
        IResult Delete(int id);
    }
}
