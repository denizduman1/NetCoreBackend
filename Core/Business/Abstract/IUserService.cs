using Core.Entity.Concrete;
using Core.Entity.Concrete.DTOs;
using Core.Utilities.Results.Abstract;

namespace Core.Business.Abstract
{
    public interface IUserService
    {
        public IDataResult<OperationClaimListDto> GetClaimsByUserId(int userId);
        public IResult Add(User user);
        public IDataResult<User> GetByMail(string mail);
    }
}
