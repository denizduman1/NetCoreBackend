using Core.Entity.Concrete;
using Core.Entity.Concrete.DTOs;
using Core.Utilities.Results.Abstract;
using Core.Utilities.Security.JWT;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Core.Business.Abstract
{
    public interface IAuthService
    {
        public Task<IDataResult<User>> RegisterUser(UserAddDto userAddDto); 
        public Task<IDataResult<User>> LoginUser(UserLoginDto userLoginDto);
        public Task<IResult> UserExist(string email);
        public Task<IDataResult<AccessToken>> CreateAccessToken(User user);
    }
}
