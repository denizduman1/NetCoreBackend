using AutoMapper;
using Core.Business.Abstract;
using Core.DataAccess.Abstract;
using Core.Entity.Concrete;
using Core.Entity.Concrete.DTOs;
using Core.Utilities.Results.Abstract;
using Core.Utilities.Results.ComplexTypes;
using Core.Utilities.Results.Concrete;
using Core.Utilities.Results.Message;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Core.Business.Concrete
{
    //AutoMapper 11.0.1
    public class UserManager : IUserService
    {
        private readonly IUserRepository _userRepository;
        private readonly IUserOperationClaimRepository _userOperationClaimRepository;
        private readonly IMapper _mapper;
        private Messages messages = Messages.Instance();

        public UserManager(IUserRepository userRepository, IMapper mapper, IUserOperationClaimRepository userOperationClaimRepository)
        {
            _userRepository = userRepository;
            _mapper = mapper;
            _userOperationClaimRepository = userOperationClaimRepository;
        }

        public IResult Add(User user)
        {
            _userRepository.Add(user);
            return new Result(ResultStatus.Success,messages.SuccessAddData);
        }

        public IDataResult<User> GetByMail(string mail)
        {
            var user = _userRepository.Get(u => u.Email == mail);
            if(user != null)
                return new DataResult<User>(user, ResultStatus.Success);

            return new DataResult<User>(new User { }, ResultStatus.Error, messages.ErrorUserEmailNotFound);
        }

        public IDataResult<OperationClaimListDto> GetClaimsByUserId(int userId)
        {
            User? user =  _userRepository.Get(u => u.ID == userId, u => u.UserOperationClaims);
            OperationClaimListDto operationClaimListDto = new OperationClaimListDto();
            if (user != null && user.UserOperationClaims.Count > 0)
            {
                foreach (var uoc in user.UserOperationClaims)
                {
                    UserOperationClaim? userOperationClaim = _userOperationClaimRepository.Get(u => u.ID == uoc.ID, u => u.OperationClaim);
                    if (userOperationClaim != null && userOperationClaim.OperationClaim != null)
                    {
                        OperationClaim operationClaim = userOperationClaim.OperationClaim;
                        var operationClaimDto = _mapper.Map<OperationClaimDto>(operationClaim);
                        operationClaimListDto.OperationClaimDtos.Add(operationClaimDto);
                    }
                }
                if (operationClaimListDto.OperationClaimDtos.Count > 0)
                {
                    return new DataResult<OperationClaimListDto>(operationClaimListDto, ResultStatus.Success);
                }
                return new DataResult<OperationClaimListDto>(operationClaimListDto, ResultStatus.Error, messages.ErrorUserClaim);
            }
            return new DataResult<OperationClaimListDto>(operationClaimListDto, ResultStatus.Error, messages.ErrorUserOrUserClaim);
        }
    }
}
