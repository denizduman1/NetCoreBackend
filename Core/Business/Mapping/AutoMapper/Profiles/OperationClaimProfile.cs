using AutoMapper;
using Core.Entity.Concrete;
using Core.Entity.Concrete.DTOs;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Core.Business.Mapping.AutoMapper.Profiles
{
    //AutoMapper 11.0.1
    public class OperationClaimProfile : Profile
    {
        public OperationClaimProfile()
        {
            CreateMap<OperationClaim, OperationClaimDto>();
            
            CreateMap<OperationClaimAddDto, OperationClaim>().
                ForMember(dest => dest.CreatedDate, opt => opt.MapFrom(x => DateTime.Now))
               .ForMember(dest => dest.ModifiedDate, opt => opt.MapFrom(x => DateTime.Now))
               .ForMember(dest => dest.Deleted, opt => opt.MapFrom(x => false));
            
            CreateMap<OperationClaimUpdateDto, OperationClaim>()
               .ForMember(dest => dest.ModifiedDate, opt => opt.MapFrom(x => DateTime.Now))
               .ForMember(dest => dest.Deleted, opt => opt.MapFrom(x => false));
        }
    }
}
