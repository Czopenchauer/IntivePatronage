using API.Models;
using AutoMapper;
using Database.Entities;

namespace API.Profiles
{
    public class AddressProfile : Profile
    {
        public AddressProfile()
        {
            CreateMap<Address, AddressDto>().ReverseMap();
        }

    }
}
