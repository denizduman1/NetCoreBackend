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
using System.Linq.Expressions;
using System.Text;
using System.Threading.Tasks;

namespace Core.Business.Concrete
{
    public class UserOperationClaimManager : IUserOperationClaimService
    {
        private readonly IUserOperationClaimRepository _userOperationClaimRepository;
        private readonly IOperationClaimRepository _operationClaimRepository;
        private readonly IMapper _mapper;
        private Messages messages = Messages.Instance();

        public UserOperationClaimManager(IUserOperationClaimRepository userOperationClaimRepository, IMapper mapper, IOperationClaimRepository operationClaimRepository)
        {
            _userOperationClaimRepository = userOperationClaimRepository;
            _mapper = mapper;
            _operationClaimRepository = operationClaimRepository;
        }

        public IResult Add(UserOperationClaimAddDto userOperationClaimAddDto)
        {
            var userOperationClaim = _mapper.Map<UserOperationClaim>(userOperationClaimAddDto);
            _userOperationClaimRepository.Add(userOperationClaim);
            return new Result(ResultStatus.Success, messages.SuccessAddData);
        }

        public IResult Delete(int id)
        {
            var userOperationClaim = _userOperationClaimRepository.Get(o => o.ID == id);
            if (userOperationClaim != null)
            {
                _userOperationClaimRepository.Remove(userOperationClaim);
                return new Result(ResultStatus.Success, messages.SuccessRemoveData);
            }
            return new Result(ResultStatus.Error, messages.SuccessRemoveData);
        }

        public IDataResult<UserOperationClaimListDto> GetAll()
        {
            var userOperationClaimList = _userOperationClaimRepository.GetAll(null, u => u.User, u => u.OperationClaim);

            if (userOperationClaimList.Count > 0)
            {   
                var userOperationClaimDtos = new List<UserOperationClaimDto>();

                foreach (var opc in userOperationClaimList)
                {
                    var userOperationClaimDto = _mapper.Map<UserOperationClaimDto>(opc);
                    userOperationClaimDtos.Add(userOperationClaimDto);
                }

                return new DataResult<UserOperationClaimListDto>(new UserOperationClaimListDto
                {
                    UserOperationClaimDtos = userOperationClaimDtos
                }, ResultStatus.Success, messages.SuccessGetAllData);
            }
            return new DataResult<UserOperationClaimListDto>(new UserOperationClaimListDto { }, ResultStatus.Error, messages.ErrorData);
        }

        public IDataResult<UserOperationClaimDto> GetById(int id)
        {
            var userOperationClaim = _userOperationClaimRepository.Get(o => o.ID == id);
            if (userOperationClaim != null)
            {
                var userOperationClaimDto = _mapper.Map<UserOperationClaimDto>(userOperationClaim);
                return new DataResult<UserOperationClaimDto>(userOperationClaimDto, ResultStatus.Success, messages.SuccessGetData);
            }
            return new DataResult<UserOperationClaimDto>(new UserOperationClaimDto { }, ResultStatus.Error, messages.ErrorData);
        }

        public IResult Update(UserOperationClaimUpdateDto userOperationClaimUpdateDto)
        {
            var oldUserOperationClaim = _userOperationClaimRepository.Get(o => o.ID == userOperationClaimUpdateDto.ID);
            if (oldUserOperationClaim != null)
            {
                var operationClaim = _mapper.Map<OperationClaim>(userOperationClaimUpdateDto);
               _operationClaimRepository.Update(operationClaim);
                return new Result(ResultStatus.Success, messages.SuccessUpdateData);
            }
            return new Result(ResultStatus.Error, messages.ErrorUpdateData);
        }
    }
}
