using API.Models;
using AutoMapper;
using IntivePatronage.Entities;
using IntivePatronage.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace API.Profiles
{
    public class UserProfile : Profile
    {
        public UserProfile()
        {
            CreateMap<User, UserDto>()
                .ForMember(x => x.Address, y => y.MapFrom(z => z.Address)).ReverseMap();
        }

    }
}
