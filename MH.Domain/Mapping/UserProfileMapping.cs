using AutoMapper;
using MH.Domain.Model;
using UserProfile = MH.Domain.Dto.UserProfile;


namespace MH.Domain.Mapping;

public class UserProfileMapping : Profile
{
    public UserProfileMapping()
    {
        CreateMap<DBModel.UserProfile,UserProfileModel>().ReverseMap();
        CreateMap<DBModel.UserProfile, UserProfile>().ReverseMap();
    }
}