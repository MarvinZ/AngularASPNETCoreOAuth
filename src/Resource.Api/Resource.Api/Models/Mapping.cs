using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using AutoMapper;

namespace Resource.Api.Models
{
    public class Mapping : Profile
    {
        public Mapping()
        {
            CreateMap<Group, GroupDTO>() // means you want to map from x to y
                 .ForMember(dest =>
            dest.CreateDatetime,
            opt => opt.MapFrom(src => src.DeactivateDatetime)); //just an example
        }
    }

}