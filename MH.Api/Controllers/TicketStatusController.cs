using MH.Application.IService;
using MH.Domain.Dto;
using MH.Domain.IEntity;
using MH.Domain.Model;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Swashbuckle.AspNetCore.Annotations;

namespace MH.Api.Controllers;

[Authorize]
public class TicketStatusController : BaseController
{
    private readonly ICurrentUser _currentUser;
    private readonly ITicketStatusService _ticketStatusService;

    public TicketStatusController(ITicketStatusService ticketStatusService, ICurrentUser currentUser)
    {
        _ticketStatusService = ticketStatusService;
        _currentUser = currentUser;
    }

    [HttpPost]
    [Route("Add")]
    public async Task<ActionResult> Add([FromBody] TicketStatusModel model)
    {
        await _ticketStatusService.Add(model);
        return Ok();
    }

    [HttpGet]
    [Route("GetAll")]
    [SwaggerResponse(StatusCodes.Status200OK, "Return TicketStatus data", typeof(List<TicketStatus>))]
    public async Task<ActionResult> GetAll()
    {
        var result = await _ticketStatusService.GetAll();
        return Ok(result);
    }

    //[HttpGet]
    //[Route("GetById")]
    //[SwaggerResponse(StatusCodes.Status200OK, "Return TicketStatus data", typeof(TicketStatus))]
    //public async Task<ActionResult> GetById([FromQuery] int id)
    //{
    //    var result = await _ticketStatusService.GetById(id);
    //    return Ok(result);
    //}

    //[HttpPatch]
    //[Route("Update")]
    //public async Task<ActionResult> Update([FromBody] TicketStatusModel ticketStatus)
    //{
    //    await _ticketStatusService.Update(ticketStatus);
    //    return Ok();
    //}

    //[HttpDelete]
    //[Route("Delete")]
    //public async Task<ActionResult> Delete([FromQuery] int id)
    //{
    //    await _ticketStatusService.Delete(id);
    //    return Ok();
    //}
}