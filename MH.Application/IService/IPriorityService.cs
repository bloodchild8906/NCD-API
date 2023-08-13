using MH.Domain.Model;
using MH.Domain.ViewModel;


namespace MH.Application.IService;
//todo: clarification
//why are we returning view models here? 
//an api should not be concerned with the UI of an integration

public interface IPriorityService
{
    Task<List<PriorityViewModel>> GetAll();
    Task<PriorityViewModel> GetById(int id);
    Task Add(PriorityModel priority);
    Task Update(PriorityModel priority);
    Task Delete(int id);
}