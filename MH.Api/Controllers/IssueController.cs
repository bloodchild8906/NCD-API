using MH.Application.IService;
using MH.Domain.Dto;
using MH.Domain.IEntity;
using MH.Domain.Model;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Swashbuckle.AspNetCore.Annotations;

namespace MH.Api.Controllers;

[Authorize]
public class IssueController : BaseController
{
    private readonly ICurrentUser _currentUser;
    private readonly IIssueService _issueService;

    public IssueController(IIssueService issueService, ICurrentUser currentUser)
    {
        _issueService = issueService;
        _currentUser = currentUser;
    }

    [HttpPost]
    [Route("Add")]
    public async Task<ActionResult> Add([FromBody] IssueModel model)
    {
        await _issueService.Add(model);
        return Ok();
    }

    [HttpGet]
    [Route("GetAll")]
    [SwaggerResponse(StatusCodes.Status200OK, "Return Issue data", typeof(List<Issue>))]
    public async Task<ActionResult> GetAll()
    {
        var result = await _issueService.GetAll();
        return Ok(result);
    }

    [HttpGet]
    [Route("GetById")]
    [SwaggerResponse(StatusCodes.Status200OK, "Return Issue data", typeof(Issue))]
    public async Task<ActionResult> GetById([FromQuery] int id)
    {
        var result = await _issueService.GetById(id);
        return Ok(result);
    }

    [HttpPatch]
    [Route("Update")]
    public async Task<ActionResult> Update([FromBody] IssueModel issue)
    {
        await _issueService.Update(issue);
        return Ok();
    }

    [HttpDelete]
    [Route("Delete")]
    public async Task<ActionResult> Delete([FromQuery] int id)
    {
        await _issueService.Delete(id);
        return Ok();
    }
}