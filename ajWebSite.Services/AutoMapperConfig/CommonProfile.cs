using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using AutoMapper;
using ajWebSite.Common.DTOs.Common;
using ajWebSite.Common.DTOs.Security;
using ajWebSite.Domain.Common;
using ajWebSite.Domain.Security;

namespace ajWebSite.Services.AutoMapperConfig
{
    public class CommonProfile : Profile
    {
        public CommonProfile()
        {


            var allOfTypes = AppDomain.CurrentDomain.GetAssemblies().SelectMany(p => p.GetTypes());
            var TypeNames = allOfTypes.Where(p => p.Name.ToLower().EndsWith("dto"));
            foreach (Type dtoItem in TypeNames)
            {
                var domainTypeName = dtoItem.Name.Substring(0, dtoItem.Name.Length - 3);
                var domainType = allOfTypes.FirstOrDefault(p => p.Name == domainTypeName);
                if (domainType != null)
                {
                    CreateMap(dtoItem, domainType).ReverseMap();
                }
            }
            CreateMap<PersonDTO, Person>().ReverseMap();
            CreateMap<PersonDetailDTO, PersonDetail>().ReverseMap();
            CreateMap<PersonDocDTO, PersonDoc>().ReverseMap();
            CreateMap<LookupDTO, Lookup>().ReverseMap();
            CreateMap<TextMessageDTO, TextMessage>().ReverseMap();
            CreateMap<FileBinaryDTO, FileBinary>().ReverseMap();
            CreateMap<newsAndItemDTO, newsAndItem>().ReverseMap().ForMember(d=>d.groupTitle,m=>m.MapFrom(s=>s.group.title));
            CreateMap<GroupDTO, Group>().ReverseMap();
            CreateMap<commentDTO, comment>().ReverseMap();
            CreateMap<voteDTO, vote>().ReverseMap();
            CreateMap<configDTO, config>().ReverseMap(); 

            CreateMap<ParkingDTO, Parking>().ReverseMap()
                .ForMember(d => d.TypeDesc, m => m.MapFrom(s => s.Type.Value));
        }
    }
}
