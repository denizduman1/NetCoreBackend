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
        private readonly IOperationClaimRepository _operationClaimRepository;
        private readonly IMapper _mapper;
        private Messages messages = Messages.Instance();

        public OperationClaimManager(IOperationClaimRepository operationClaimRepository, IMapper mapper)
        {
            _operationClaimRepository = operationClaimRepository;
            _mapper = mapper;
        }

        public IResult Add(OperationClaimAddDto operationClaimAddDto)
        {
            var operationClaim = _mapper.Map<OperationClaim>(operationClaimAddDto);
            _operationClaimRepository.Add(operationClaim);
            return new Result(ResultStatus.Success, messages.SuccessAddData);
        }

        public IResult Delete(int id)
        {
            var operationClaim = _operationClaimRepository.Get(o => o.ID == id);
            if (operationClaim != null)
            {
                _operationClaimRepository.Remove(operationClaim);
                return new Result(ResultStatus.Success, messages.SuccessRemoveData);
            }
            return new Result(ResultStatus.Error, messages.SuccessRemoveData);
        }

        public IDataResult<OperationClaimListDto> GetAll()
        {
            var operationClaimList = _operationClaimRepository.GetAll();

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
                }, ResultStatus.Success, messages.SuccessGetAllData);
            }
            return new DataResult<OperationClaimListDto>(new OperationClaimListDto { }, ResultStatus.Error, messages.ErrorData);
        }

        public IDataResult<OperationClaimDto> GetById(int id)
        {
            var operationClaim = _operationClaimRepository.Get(o => o.ID == id);
            if (operationClaim != null)
            {
                var operationClaimDto = _mapper.Map<OperationClaimDto>(operationClaim);
                return new DataResult<OperationClaimDto>(operationClaimDto, ResultStatus.Success, messages.SuccessGetData);
            }
            return new DataResult<OperationClaimDto>(new OperationClaimDto { }, ResultStatus.Error, messages.ErrorData);
        }

        public IResult Update(OperationClaimUpdateDto operationClaimUpdateDto)
        {
            var oldoperationClaim = _operationClaimRepository.Get(o => o.ID == operationClaimUpdateDto.ID);
            if (oldoperationClaim != null)
            {
                var operationClaim = _mapper.Map<OperationClaim>(operationClaimUpdateDto);
                _operationClaimRepository.Update(operationClaim);
                return new Result(ResultStatus.Success, messages.SuccessUpdateData);
            }
            return new Result(ResultStatus.Error, messages.ErrorUpdateData);
        }
    }
}
