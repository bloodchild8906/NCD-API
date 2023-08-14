using MH.Application.IService;
using MH.Domain.Dto;
using MH.Domain.IEntity;
using MH.Domain.Model;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Swashbuckle.AspNetCore.Annotations;

namespace MH.Api.Controllers;

[Authorize]
public class UserProfileController : BaseController
{
    private readonly ICurrentUser _currentUser;
    private readonly IUserProfileService _userProfileService;

    public UserProfileController(IUserProfileService userProfileService, ICurrentUser currentUser)
    {
        _userProfileService = userProfileService;
        _currentUser = currentUser;
    }

    [HttpPost]
    [Route("Add")]
    [ApiExplorerSettings(IgnoreApi = true)]
    public async Task<ActionResult> Add([FromForm] UserProfileModel model)
    {
        model.UserId = _currentUser.User.Id;
        await _userProfileService.Add(model);
        return Ok();
    }

    [HttpGet]
    [Route("GetAll")]
    [SwaggerResponse(StatusCodes.Status200OK, "Return Role data", typeof(List<UserProfile>))]
    public async Task<ActionResult> GetAll()
    {
        var result = await _userProfileService.GetAll();
        return Ok(result);
    }

    [HttpGet]
    [Route("GetById")]
    [SwaggerResponse(StatusCodes.Status200OK, "", typeof(UserProfile))]
    public async Task<ActionResult> GetById([FromQuery] int id)
    {
        var result = await _userProfileService.GetById(id);
        return Ok(result);
    }

    [HttpGet]
    [Route("GetByUserId")]
    [SwaggerResponse(StatusCodes.Status200OK, "", typeof(UserProfile))]
    public async Task<ActionResult> GetByUserId()
    {
        var result = await _userProfileService.GetByUserId(_currentUser.User.Id);
        return Ok(result);
    }

    [HttpPatch]
    [Route("Update")]
    public async Task<ActionResult> Update([FromForm] UserProfileModel userProfile)
    {
        await _userProfileService.Update(userProfile);
        return Ok();
    }

    [HttpDelete]
    [Route("Delete")]
    [ApiExplorerSettings(IgnoreApi = true)]
    public async Task<ActionResult> Delete([FromQuery] int id)
    {
        await _userProfileService.Delete(id);
        return Ok();
    }
}