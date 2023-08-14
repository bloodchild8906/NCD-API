using AutoMapper;
using MH.Domain.DBModel;
using MH.Domain.Dto;
using MH.Domain.Model;
using Role = MH.Domain.Dto.Role;
using UserRole = MH.Domain.Dto.UserRole;

namespace MH.Domain.Mapping;

public class ApplicationUserMapping : Profile
{
    public ApplicationUserMapping()
    {
        CreateMap<RegisterModel,ApplicationUser>()
            .ForMember(u => u.UserName, opt => opt.MapFrom(x => x.Email))
            .ForMember(u=>u.PasswordHash, opt=> opt.MapFrom(x=> x.Password))
            .ReverseMap();

        CreateMap<ApplicationUser, User>().ReverseMap();

        CreateMap<DBModel.UserRole, UserRole>().ReverseMap();
        CreateMap<DBModel.Role, Role>().ReverseMap();
    }
}