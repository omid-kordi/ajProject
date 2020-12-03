using AutoMapper;
using ajWebSite.Common.DTOs.ajWebSite;
using ajWebSite.Common.Helpers;
using ajWebSite.Domain.ajWebSite;
using System;
using System.Collections.Generic;
using System.Text;

namespace ajWebSite.Services.AutoMapperConfig
{
    public class ajWebSiteProfile : Profile
    {
        public ajWebSiteProfile()
        {
            CreateMap<ticketDTO, ticket>().ReverseMap()
                   .ForMember(p=>p.RecieverName,o=>o.MapFrom(s=>(s.Reciever.Username)??""))
                   .ForMember(p=>p.senderName,o=>o.MapFrom(s=>(s.Sender.Username)??""));

            CreateMap<salonDTO, salon>().ReverseMap()
                    .ForMember(p=>p.salonStateTitle,o=>o.MapFrom(s=>s.state.ToDescription()));

        }
    }
}
