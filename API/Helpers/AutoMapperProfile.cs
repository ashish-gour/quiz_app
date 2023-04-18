using API.Dto;
using API.Entities;
using AutoMapper;

namespace API.Helpers
{
    public class AutoMapperProfile : Profile
    {
        public AutoMapperProfile()
        {
            CreateMap<UserDto,User>().ReverseMap();
            CreateMap<RegisterDto,User>().ReverseMap();
            CreateMap<LoginDto, User>().ReverseMap();
        }
    }
}