using MH.Domain.Model;
using MH.Domain.ViewModel;


namespace MH.Application.IService;
//todo: clarification
//why are we returning view models here? 
//an api should not be concerned with the UI of an integration

public interface IPositionService
{
    Task<List<PositionViewModel>> GetAll();
    Task<PositionViewModel> GetById(int id);
    Task Add(PositionModel position);
    Task Update(PositionModel position);
    Task Delete(int id); 
}