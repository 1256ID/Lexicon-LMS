using AutoMapper;
using Domain.Models.Entities;
using LMS.Shared.DTOs.AuthDtos;
using LMS.Shared.DTOs.User;

namespace LMS.Infractructure.Data;

public class MapperProfile : Profile
{
    public MapperProfile()
    {

        // Entity --> DTO

        CreateMap<ApplicationUser, UserDto>();

        // DTO --> Entity 

        CreateMap<UserRegistrationDto, ApplicationUser>()
            .ForMember(d => d.PasswordHash, o => o.Ignore())
            .ForMember(d => d.UserName, o => o.Ignore());
       
        CreateMap<UpdateUserDto, ApplicationUser>()
            .ForAllMembers(options => options.Condition((src, dest, srcMember) => src != null));

    }
}
