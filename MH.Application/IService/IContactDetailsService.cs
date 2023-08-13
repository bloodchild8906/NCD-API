using MH.Domain.Model;
using MH.Domain.ViewModel;


namespace MH.Application.IService;
//todo: clarification
//why are we returning view models here? 
//an api should not be concerned with the UI of an integration

public interface IContactDetailsService
{
    Task<List<ContactDetailsViewModel>> GetAll();
    Task<ContactDetailsViewModel> GetByUserId(int userId);
    Task Add(ContactDetailsModel contactDetails);
    Task Update(ContactDetailsModel contactDetails);
    Task Delete(int id); 
}