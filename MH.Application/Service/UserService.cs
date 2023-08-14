using AutoMapper;
using MH.Application.Exception;
using MH.Application.IService;
using MH.Domain.Constant;
using MH.Domain.DBModel;
using MH.Domain.Dto;
using MH.Domain.IEntity;
using MH.Domain.IRepository;
using MH.Domain.Model;
using MH.Domain.UnitOfWork;
using Microsoft.AspNetCore.Identity;
using UserRole = MH.Domain.DBModel.UserRole;

namespace MH.Application.Service;

public class UserService : IUserService
{
    private readonly ICurrentUser _currentUser;
    private readonly UserManager<ApplicationUser> _userManager;
    private readonly IUserRepository _userRepository;

    public UserService(IUserRepository userRepository, IMapper mapper, UserManager<ApplicationUser> userManager,
        ICurrentUser currentUser, IUnitOfWork unitOfWork)
    {
        _userManager = userManager;
        _userRepository = userRepository;
        _currentUser = currentUser;
    }

    public async Task<User> GetUserById(int id)
    {
        var user = await _userRepository.GetUserById(id);

        if (user == null) throw new RecordNotFound("User id not found");

        var data = new User
        {
            Id = user.Id,
            FirstName = user.UserProfile.FirstName,
            LastName = user.UserProfile.LastName,
            Email = user.Email ?? string.Empty,
            PhoneNumber = user.PhoneNumber ?? string.Empty,

            PositionName = user.Position?.Name ?? string.Empty,
            PositionDesc = user.Position?.Description ?? string.Empty,

            ContactName = user.UserProfile.ContactDetails.Name,
            ContactDataTypeId = user.UserProfile.ContactDetails.ContactDataTypeId,
            ContactDataTypeName = user.UserProfile.ContactDetails.ContactDataType.Name,
            ContactTypeId = user.UserProfile.ContactDetails.ContactTypeId,
            ContactTypeName = user.UserProfile.ContactDetails.ContactType.Name,
            ContactEntityId = user.UserProfile.ContactDetails.ContactEntityId,
            ContactEntityName = user.UserProfile.ContactDetails.ContactEntity.Name,
            ContactData = user.UserProfile.ContactDetails.Data,

            UserRoles = user.UserRoles.Select(userRole => userRole.Role.Name).ToList()
        };
        return data;
    }

    public async Task<ApplicationUser> GetUserByMobileNo(string mobileNo)
    {
        return await _userRepository.GetUserByMobileNo(mobileNo);
    }

    public async Task<bool> IsAdmin(int userId)
    {
        var user = await _userManager.FindByIdAsync(userId.ToString());
        if (user == null) return false;
        var isAdmin = (await _userManager.GetRolesAsync(user)).FirstOrDefault(x => x == RoleConst.Admin);
        return isAdmin != null;
    }

    public async Task<bool> CanViewOrEdit(int userId)
    {
        if (await _userManager.FindByIdAsync(_currentUser.User.Id.ToString()) is not { } user) return false;
        var isAdmin = (await _userManager.GetRolesAsync(user)).FirstOrDefault(role => role == RoleConst.Admin);
        return isAdmin != null || userId == _currentUser.User.Id;
    }

    public async Task UpdateUser(UserUpdateModel user)
    {
        var exist = await _userRepository.GetUserById(user.Id);
        if (exist != null)
        {
            exist.PhoneNumber = user.PhoneNumber;
            exist.PositionId = user.PositionId;
            exist.UserProfile.FirstName = user.FirstName;
            exist.UserProfile.LastName = user.LastName;
            exist.UserProfile.IdNumber = user.IdNumber;
            exist.UserProfile.Notes = user.Notes;
            await _userRepository.UpdateUser(exist);

            if (await IsAdmin(_currentUser.User.Id))
            {
                foreach (var existUserRole in exist.UserRoles)
                    if (user.Roles != null && user.Roles.All(x => x != existUserRole.RoleId))
                        await _userRepository.DeleteUserRole(existUserRole);

                if (user.Roles != null)
                    foreach (var updateRole in user.Roles.Where(updateRole =>
                                 exist.UserRoles.All(x => x.RoleId != updateRole)))
                        await _userRepository.AddUserRole(new UserRole { UserId = user.Id, RoleId = updateRole });
            }
        }
    }

    public async Task Delete(int id)
    {
        var exist = await _userRepository.GetUserById(id);
        if (exist != null)
        {
            exist.Status = 0;
            exist.UserProfile.IsDeleted = true;
            await _userManager.UpdateAsync(exist);
        }
    }
}