using AutoMapper;
using MH.Application.IService;
using MH.Domain.DBModel;
using MH.Domain.IRepository;

namespace MH.Application.Service;

public class PermissionService : IPermissionService
{
    private readonly IMapper _mapper;
    private readonly IRepository<Permission, int> _permissionRepository;

    public PermissionService(IRepository<Permission, int> permissionRepository, IMapper mapper)
    {
        _permissionRepository = permissionRepository;
        _mapper = mapper;
    }

    public async Task<List<Domain.Dto.Permission>> GetAllPermission()
    {
        var permissions = await _permissionRepository.GetAll();
        var data = _mapper.Map<List<Domain.Dto.Permission>>(permissions);
        return data;
    }
}