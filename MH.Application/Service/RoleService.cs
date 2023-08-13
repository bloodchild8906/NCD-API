using MH.Application.IService;
using MH.Domain.DBModel;
using MH.Domain.IRepository;

namespace MH.Application.Service;

public class RoleService : IRoleService
{
    private readonly IRoleRepository _roleRepository;

    public RoleService(IRoleRepository roleRepository) => _roleRepository = roleRepository;
    public async Task<Role> GetById(int id) => await _roleRepository.GetById(id);
}