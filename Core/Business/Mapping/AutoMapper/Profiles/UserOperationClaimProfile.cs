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
    public class UserOperationClaimProfile : Profile
    {
        public UserOperationClaimProfile()
        {
            CreateMap<UserOperationClaim, UserOperationClaimDto>();
            CreateMap<UserOperationClaimAddDto, UserOperationClaim>().
                ForMember(dest => dest.CreatedDate, opt => opt.MapFrom(x => DateTime.Now))
               .ForMember(dest => dest.ModifiedDate, opt => opt.MapFrom(x => DateTime.Now))
               .ForMember(dest => dest.Deleted, opt => opt.MapFrom(x => false));

            CreateMap<UserOperationClaimUpdateDto, UserOperationClaim>()
               .ForMember(dest => dest.ModifiedDate, opt => opt.MapFrom(x => DateTime.Now))
               .ForMember(dest => dest.Deleted, opt => opt.MapFrom(x => false));
        }
    }
}
