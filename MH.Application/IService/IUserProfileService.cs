using MH.Domain.Model;
using MH.Domain.ViewModel;


namespace MH.Application.IService;
//todo: clarification
//why are we returning view models here? 
//an api should not be concerned with the UI of an integration

public interface IUserProfileService
{
    Task<List<UserProfileViewModel>> GetAll();
    Task<UserProfileViewModel> GetById(int id);
    Task<UserProfileViewModel> GetByUserId(int id);
    Task Add(UserProfileModel userProfile);
    Task Update(UserProfileModel userProfile);
    Task Delete(int id); 
}