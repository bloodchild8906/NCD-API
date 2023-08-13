using MH.Domain.ViewModel;

namespace MH.Application.IService;
//todo: clarification
//why are we returning view models here? 
//an api should not be concerned with the UI of an integration

public interface IPermissionService
{
    Task<List<PermissionViewModel>> GetAllPermission();
}