using AutoMapper;
using Core.Business.Abstract;
using Core.DataAccess.Abstract;
using Core.Entity.Concrete;
using Core.Entity.Concrete.DTOs;
using Core.Utilities.Results.Abstract;
using Core.Utilities.Results.ComplexTypes;
using Core.Utilities.Results.Concrete;
using Core.Utilities.Results.Message;
using Core.Utilities.Security.Hashing;
using Core.Utilities.Security.JWT;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Core.Business.Concrete
{
    public class AuthManager : IAuthService
    {
        private readonly IUserService _userService;
        private readonly IMapper _mapper;
        private Messages messages = Messages.Instance();
        private ITokenHelper _tokenHelper;

        public AuthManager(IUserService userService, IMapper mapper, ITokenHelper tokenHelper)
        {
            _userService = userService;
            _mapper = mapper;
            _tokenHelper = tokenHelper;
        }

        public IDataResult<AccessToken> CreateAccessToken(User user)
        {
            var userClaims = _userService.GetClaimsByUserId(user.ID);
            var accessToken = _tokenHelper.CreateToken(user, userClaims.Data);
            return new DataResult<AccessToken>(accessToken, ResultStatus.Success, messages.AccessTokenCreated);
        }

        public IDataResult<User> LoginUser(UserLoginDto userLoginDto)
        {
            var userToCheck = _userService.GetByMail(userLoginDto.Email);
            if (userToCheck.ResultStatus == ResultStatus.Error)
                return new DataResult<User>(new User { }, ResultStatus.Error, userToCheck.Message);

            if (!HashingHelper.VerifyPasswordHash(userLoginDto.Password, userToCheck.Data.PasswordHash, userToCheck.Data.PasswordSalt))
                return new DataResult<User>(new User { }, ResultStatus.Error, messages.ErrorPassword);

            return new DataResult<User>(userToCheck.Data, ResultStatus.Success, messages.SuccessLogin);
        }

        public IDataResult<User> RegisterUser(UserAddDto userAddDto)
        {
            HashingHelper.CreatePasswordHash(userAddDto.Password, out byte[] passwordHash, out byte[] passwordSalt);

            User user = _mapper.Map<User>(userAddDto);
            user.PasswordHash = passwordHash;
            user.PasswordSalt = passwordSalt;

            _userService.Add(user);
            return new DataResult<User>(user, ResultStatus.Success, messages.SuccessRegister);
        }

        public IResult UserExist(string email)
        {
            var userToCheck = _userService.GetByMail(email);
            if (userToCheck.ResultStatus == ResultStatus.Success)
                return new Result(ResultStatus.Error, messages.ErrorEmailExistUser);

            return new Result(ResultStatus.Success, messages.SuccessUseEmail);
        }
    }
}
