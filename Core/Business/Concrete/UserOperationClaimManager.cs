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
        private readonly IUnitOfWorkBase _unitOfWorkBase;
        private readonly IMapper _mapper;
        private Messages messages = Messages.Instance();

        public UserOperationClaimManager(IUnitOfWorkBase unitOfWorkBase, IMapper mapper)
        {
            _unitOfWorkBase = unitOfWorkBase;
            _mapper = mapper;
        }

        public async Task<IResult> AddAsync(UserOperationClaimAddDto userOperationClaimAddDto)
        {
            var userOperationClaim = _mapper.Map<UserOperationClaim>(userOperationClaimAddDto);
            await _unitOfWorkBase.UserOperationClaimRepository.AddAsync(userOperationClaim);
            await _unitOfWorkBase.SaveAsync();
            return new Result(ResultStatus.Success, messages.SuccessAddData);
        }

        public async Task<IResult> DeleteAsync(int id)
        {
            var userOperationClaim = await _unitOfWorkBase.UserOperationClaimRepository.GetAsync(o => o.ID == id);
            if (userOperationClaim != null)
            {
                await _unitOfWorkBase.UserOperationClaimRepository.RemoveAsync(userOperationClaim);
                await _unitOfWorkBase.SaveAsync();
                return new Result(ResultStatus.Success, messages.SuccessRemoveData);
            }
            return new Result(ResultStatus.Error, messages.SuccessRemoveData);
        }

        public async Task<IDataResult<UserOperationClaimListDto>> GetAllAsync()
        {
            var userOperationClaimList = await _unitOfWorkBase.UserOperationClaimRepository.GetAllAsync(null, u => u.User, u => u.OperationClaim);

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

        public async Task<IDataResult<UserOperationClaimDto>> GetByIdAsync(int id)
        {
            var userOperationClaim = await _unitOfWorkBase.UserOperationClaimRepository.GetAsync(o => o.ID == id);
            if (userOperationClaim != null)
            {
                var userOperationClaimDto = _mapper.Map<UserOperationClaimDto>(userOperationClaim);
                return new DataResult<UserOperationClaimDto>(userOperationClaimDto, ResultStatus.Success, messages.SuccessGetData);
            }
            return new DataResult<UserOperationClaimDto>(new UserOperationClaimDto { }, ResultStatus.Error, messages.ErrorData);
        }

        public async Task<IResult> UpdateAsync(UserOperationClaimUpdateDto userOperationClaimUpdateDto)
        {
            var oldUserOperationClaim = await _unitOfWorkBase.UserOperationClaimRepository.GetAsync(o => o.ID == userOperationClaimUpdateDto.ID);
            if (oldUserOperationClaim != null)
            {
                var operationClaim = _mapper.Map<OperationClaim>(userOperationClaimUpdateDto);
                await _unitOfWorkBase.OperationClaimRepository.UpdateAsync(operationClaim);
                await _unitOfWorkBase.SaveAsync();
                return new Result(ResultStatus.Success, messages.SuccessUpdateData);
            }
            return new Result(ResultStatus.Error, messages.ErrorUpdateData);
        }
    }
}
