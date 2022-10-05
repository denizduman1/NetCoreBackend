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
        public IDataResult<User> RegisterUser(UserAddDto userAddDto);
        public IDataResult<User> LoginUser(UserLoginDto userLoginDto);
        public IResult UserExist(string email);
        public IDataResult<AccessToken> CreateAccessToken(User user);
    }
}
