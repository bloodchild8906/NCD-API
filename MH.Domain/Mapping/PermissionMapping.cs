using AutoMapper;
using Permission = MH.Domain.Dto.Permission;

namespace MH.Domain.Mapping;

public class PermissionMapping : Profile
{
    public PermissionMapping()
    {
        CreateMap<Permission, DBModel.Permission>()
            .ReverseMap();
    }
}