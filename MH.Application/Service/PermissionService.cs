using AutoMapper;
using MH.Application.IService;
using MH.Domain.IRepository;
using Permission = MH.Domain.Dto.Permission;

namespace MH.Application.Service;

public class PermissionService : IPermissionService
{
    private readonly IRepository<Domain.DBModel.Permission, int> _permissionRepository;
    private readonly IMapper _mapper;
    public PermissionService(IRepository<Domain.DBModel.Permission, int> permissionRepository, IMapper mapper)
    {
        _permissionRepository = permissionRepository;
        _mapper = mapper;
    }
    public async Task<List<Permission>> GetAllPermission()
    {
        var permissions = await _permissionRepository.GetAll();
        var data = _mapper.Map<List<Permission>>(permissions);
        return data;
    }
}