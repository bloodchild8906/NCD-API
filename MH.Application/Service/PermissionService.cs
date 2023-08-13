using AutoMapper;
using MH.Application.IService;
using MH.Domain.DBModel;
using MH.Domain.IRepository;
using MH.Domain.ViewModel;

namespace MH.Application.Service;

public class PermissionService : IPermissionService
{
    private readonly IRepository<Permission, int> _permissionRepository;
    private readonly IMapper _mapper;
    public PermissionService(IRepository<Permission, int> permissionRepository, IMapper mapper)
    {
        _permissionRepository = permissionRepository;
        _mapper = mapper;
    }
    public async Task<List<PermissionViewModel>> GetAllPermission()
    {
        var permissions = await _permissionRepository.GetAll();
        var data = _mapper.Map<List<PermissionViewModel>>(permissions);
        return data;
    }
}