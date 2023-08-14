using MH.Domain.Dto;
using MH.Domain.Model;


namespace MH.Application.IService;

public interface IUserProfileService
{
    Task<List<UserProfile>> GetAll();
    Task<UserProfile> GetById(int id);
    Task<UserProfile> GetByUserId(int id);
    Task Add(UserProfileModel userProfile);
    Task Update(UserProfileModel userProfile);
    Task Delete(int id); 
}