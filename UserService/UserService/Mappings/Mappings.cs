using AutoMapper;
using UserService.Dtos;
using UserService.Models;

namespace UserService.Mappings
{
    public class Mappings : Profile
    {
        public Mappings()
        {
            CreateMap<User, UserDto>().ForMember(dest => dest.Id, opt => opt.MapFrom(src => src.UserId));
            CreateMap<UserDto, User>().ForMember(dest => dest.UserId, opt => opt.MapFrom(src => src.Id));
        }
    }
}
