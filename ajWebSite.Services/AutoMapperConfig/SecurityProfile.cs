using System;
using System.Collections.Generic;
using System.Text;
using AutoMapper;
using ajWebSite.Common.DTOs.Security;
using ajWebSite.Domain.Security;

namespace ajWebSite.Services.AutoMapperConfig
{
    public class SecurityProfile : Profile
    {
        public SecurityProfile()
        {
            CreateMap<UserDTO, User>().ReverseMap();
            CreateMap<User, UserInfoDTO>()
            .ForMember(d => d.Mobile, o => o.MapFrom(s => s.Person.Mobile))
            .ForMember(d => d.NationalCode, o => o.MapFrom(s => s.Person.NationalCode))
            .ForMember(d => d.PersonType, o => o.MapFrom(s => s.Person.PersonType))
            .ForMember(d => d.Name, o => o.MapFrom(s => s.Person.Name))
            .ForMember(d => d.LastName, o => o.MapFrom(s => s.Person.LastName))
            .ForMember(d => d.CompanyName, o => o.MapFrom(s => s.Company.Value));
        }
    }
}
