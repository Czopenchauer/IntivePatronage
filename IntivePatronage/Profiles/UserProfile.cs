using Application.Models;
using AutoMapper;
using Database.Entities;

namespace API.Profiles
{
    public class UserProfile : Profile
    {
        public UserProfile()
        {
            CreateMap<User, UserDto>()
                .ForMember(x => x.Address, y => y.MapFrom(z => z.Address));

            CreateMap<CreateUserDto, User>()
                .ForMember(x => x.Address, y => y.MapFrom(z => z.Address));

            CreateMap<UpdateUserDto, User>()
                .ForMember(x => x.Address, options => options.Condition(src => src.Address != null))
                .ForMember(x => x.Address, y => y.MapFrom(z => z.Address));
        }
    }
}
