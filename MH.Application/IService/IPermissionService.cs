using MH.Domain.Dto;

namespace MH.Application.IService;

public interface IPermissionService
{
    Task<List<Permission>> GetAllPermission();
}