using AutoMapper;
using BLL.DTOs.Users;
using DAL.Entities;

namespace BLL.Mapping.Users;

public class UserProfile : Profile
{
    public UserProfile()
    {
        CreateMap<User, UserDto>();
        CreateMap<User, UserDetailsDto>();

        CreateMap<UserRegisterDto, User>()
            .ForMember(dest => dest.UserName,
                opt => opt.MapFrom(src => src.Email));
    }
}