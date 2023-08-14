using MH.Application.IService;
using MH.Domain.Dto;
using MH.Domain.IEntity;
using MH.Domain.Model;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Swashbuckle.AspNetCore.Annotations;

namespace MH.Api.Controllers;

[Authorize]
public class PriorityController : BaseController
{
    private readonly ICurrentUser _currentUser;
    private readonly IPriorityService _priorityService;

    public PriorityController(IPriorityService priorityService, ICurrentUser currentUser)
    {
        _priorityService = priorityService;
        _currentUser = currentUser;
    }

    [HttpPost]
    [Route("Add")]
    public async Task<ActionResult> Add([FromBody] PriorityModel model)
    {
        await _priorityService.Add(model);
        return Ok();
    }

    [HttpGet]
    [Route("GetAll")]
    [SwaggerResponse(StatusCodes.Status200OK, "Return Priority data", typeof(List<Priority>))]
    public async Task<ActionResult> GetAll()
    {
        var result = await _priorityService.GetAll();
        return Ok(result);
    }

    [HttpGet]
    [Route("GetById")]
    [SwaggerResponse(StatusCodes.Status200OK, "Return Priority data", typeof(Priority))]
    public async Task<ActionResult> GetById([FromQuery] int id)
    {
        var result = await _priorityService.GetById(id);
        return Ok(result);
    }

    [HttpPatch]
    [Route("Update")]
    public async Task<ActionResult> Update([FromBody] PriorityModel priority)
    {
        await _priorityService.Update(priority);
        return Ok();
    }

    [HttpDelete]
    [Route("Delete")]
    public async Task<ActionResult> Delete([FromQuery] int id)
    {
        await _priorityService.Delete(id);
        return Ok();
    }
}