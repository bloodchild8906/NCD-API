using MH.Domain.DBModel;
using MH.Domain.Dto;
using MH.Domain.Model;

namespace MH.Application.IService;

public interface IUserService
{
    Task<User> GetUserById(int id);
    Task<ApplicationUser> GetUserByMobileNo(string mobileNo);
    Task UpdateUser(UserUpdateModel user);
    Task Delete(int id);
    Task<bool> IsAdmin(int userId);
    Task<bool> CanViewOrEdit(int userId);
}