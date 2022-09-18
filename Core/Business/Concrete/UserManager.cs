using AutoMapper;
using Core.Business.Abstract;
using Core.DataAccess.Abstract;
using Core.Entity.Concrete;
using Core.Entity.Concrete.DTOs;
using Core.Utilities.Results.Abstract;
using Core.Utilities.Results.ComplexTypes;
using Core.Utilities.Results.Concrete;
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
        private readonly IUnitOfWorkBase _unitOfWorkBase;
        private readonly IMapper _mapper;

        public UserManager(IUnitOfWorkBase unitOfWorkBase ,IMapper mapper)
        {
            _unitOfWorkBase = unitOfWorkBase;
            _mapper = mapper;
        }

        public async Task<IDataResult<OperationClaimListDto>> GetClaimsByUserIdAsync(int userId)
        {
            User? user = await _unitOfWorkBase.UserRepository.GetAsync(u => u.ID == userId, u => u.UserOperationClaims, u => u.UserOperationClaims);
            OperationClaimListDto operationClaimListDto = new OperationClaimListDto();
            if (user != null && user.UserOperationClaims.Count > 0)
            {
                foreach (var uoc in user.UserOperationClaims)
                {
                    UserOperationClaim? userOperationClaim = await _unitOfWorkBase.UserOperationClaimRepository.GetAsync(u => u.ID == uoc.ID, u => u.OperationClaim);
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
                return new DataResult<OperationClaimListDto>(operationClaimListDto, ResultStatus.Error, "Kullanıcı var fakat yetkisi yok.");
            }
            return new DataResult<OperationClaimListDto>(operationClaimListDto, ResultStatus.Error, "Kullanıcı veya yetkisi bulunamadı.");
        }
    }
}
