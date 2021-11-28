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
                .ForPath(x => x.User.FirstName, y => y.MapFrom(z => z.FirstName))
                .ForPath(x => x.User.LastName, y => y.MapFrom(z => z.LastName))
                .ForPath(x => x.User.DateOfBirth, y => y.MapFrom(z => z.DateOfBirth))
                .ForPath(x => x.User.Gender, y => y.MapFrom(z => z.Gender))
                .ForPath(x => x.User.Weight, y => y.MapFrom(z => z.Weight))
                .ForMember(x => x.Address, y => y.MapFrom(z => z.Address));

            CreateMap<CreateUserDto, User>()
                .ForMember(x => x.FirstName, y => y.MapFrom(z => z.User.FirstName))
                .ForMember(x => x.LastName, y => y.MapFrom(z => z.User.LastName))
                .ForMember(x => x.DateOfBirth, y => y.MapFrom(z => z.User.DateOfBirth))
                .ForMember(x => x.Gender, y => y.MapFrom(z => z.User.Gender))
                .ForMember(x => x.Weight, y => y.MapFrom(z => z.User.Weight))
                .ForMember(x => x.Address, y => y.MapFrom(z => z.Address));

            CreateMap<UpdateUserDto, User>()
                .ForMember(x => x.FirstName, y => y.MapFrom(z => z.User.FirstName))
                .ForMember(x => x.LastName, y => y.MapFrom(z => z.User.LastName))
                .ForMember(x => x.DateOfBirth, y => y.MapFrom(z => z.User.DateOfBirth))
                .ForMember(x => x.Gender, y => y.MapFrom(z => z.User.Gender))
                .ForMember(x => x.Weight, y => y.MapFrom(z => z.User.Weight))
                .ForMember(x => x.Address, options => options.Condition(src => src.Address != null))
                .ForMember(x => x.Address, y => y.MapFrom(z => z.Address));
        }

    }
}
