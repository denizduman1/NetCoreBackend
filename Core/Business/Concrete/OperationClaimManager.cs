using AutoMapper;
using Core.Business.Abstract;
using Core.DataAccess.Abstract;
using Core.Entity.Concrete;
using Core.Entity.Concrete.DTOs;
using Core.Utilities.Results.Abstract;
using Core.Utilities.Results.ComplexTypes;
using Core.Utilities.Results.Concrete;
using Core.Utilities.Results.Message;

namespace Core.Business.Concrete
{
    public class OperationClaimManager : IOperationClaimService
    {
        private readonly IUnitOfWorkBase _unitOfWorkBase;
        private readonly IMapper _mapper;

        public OperationClaimManager(IUnitOfWorkBase unitOfWorkBase, IMapper mapper)
        {
            _unitOfWorkBase = unitOfWorkBase;
            _mapper = mapper;
        }

        public async Task<IResult> AddAsync(OperationClaimAddDto operationClaimAddDto)
        {
            var operationClaim = _mapper.Map<OperationClaim>(operationClaimAddDto);
            await _unitOfWorkBase.OperationClaimRepository.AddAsync(operationClaim);
            await _unitOfWorkBase.SaveAsync();
            return new Result(ResultStatus.Success, Messages.SuccessAddData);
        }

        public async Task<IResult> DeleteAsync(int id)
        {
            var operationClaim = await _unitOfWorkBase.OperationClaimRepository.GetAsync(o => o.ID == id);
            if (operationClaim != null)
            {
                await _unitOfWorkBase.OperationClaimRepository.RemoveAsync(operationClaim);
                await _unitOfWorkBase.SaveAsync();
                return new Result(ResultStatus.Success, Messages.SuccessRemoveData);
            }
            return new Result(ResultStatus.Error, Messages.SuccessRemoveData);
        }

        public async Task<IDataResult<OperationClaimListDto>> GetAllAsync()
        {
            var operationClaimList = await _unitOfWorkBase.OperationClaimRepository.GetAllAsync();

            if (operationClaimList.Count > 0)
            {
                var operationClaimDtos = new List<OperationClaimDto>();
                
                foreach (var opc in operationClaimList)
                {
                    var operationClaimDto = _mapper.Map<OperationClaimDto>(opc);
                    operationClaimDtos.Add(operationClaimDto);
                }
                  
                return new DataResult<OperationClaimListDto>(new OperationClaimListDto
                {
                    OperationClaimDtos = operationClaimDtos
                }, ResultStatus.Success, Messages.SuccessGetAllData);
            }
            return new DataResult<OperationClaimListDto>(new OperationClaimListDto { }, ResultStatus.Error, Messages.ErrorData);
        }

        public async Task<IDataResult<OperationClaimDto>> GetByIdAsync(int id)
        {
            var operationClaim = await _unitOfWorkBase.OperationClaimRepository.GetAsync(o => o.ID == id);
            if (operationClaim != null)
            {
                var operationClaimDto = _mapper.Map<OperationClaimDto>(operationClaim);
                return new DataResult<OperationClaimDto>(operationClaimDto, ResultStatus.Success ,Messages.SuccessData);
            }
            return new DataResult<OperationClaimDto>(new OperationClaimDto { }, ResultStatus.Error, Messages.ErrorData );
        }

        public async Task<IResult> UpdateAsync(OperationClaimUpdateDto operationClaimUpdateDto)
        {
            var oldoperationClaim = await _unitOfWorkBase.OperationClaimRepository.GetAsync(o => o.ID == operationClaimUpdateDto.ID);
            if (oldoperationClaim != null)
            {
                var operationClaim = _mapper.Map<OperationClaim>(operationClaimUpdateDto); 
                await _unitOfWorkBase.OperationClaimRepository.UpdateAsync(operationClaim);
                await _unitOfWorkBase.SaveAsync();
                return new Result(ResultStatus.Success, Messages.SuccessUpdateData);
            }
            return new Result(ResultStatus.Error, Messages.ErrorUpdateData);
        }
    }
}
