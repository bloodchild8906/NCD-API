using AutoMapper;
using MH.Domain.DBModel;
using MH.Domain.Model;

namespace MH.Domain.Mapping;

public class UserProfileMapping : Profile
{
    public UserProfileMapping()
    {
        CreateMap<UserProfile, UserProfileModel>().ReverseMap();
        CreateMap<UserProfile, Dto.UserProfile>().ReverseMap();
    }
}