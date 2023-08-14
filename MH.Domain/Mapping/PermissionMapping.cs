using AutoMapper;
using MH.Domain.Dto;

namespace MH.Domain.Mapping;

public class PermissionMapping : Profile
{
    public PermissionMapping()
    {
        CreateMap<Permission, DBModel.Permission>()
            .ReverseMap();
    }
}