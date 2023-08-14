using MH.Application.IService;
using MH.Domain.IEntity;
using Microsoft.AspNetCore.Authorization;

namespace MH.Api.Controllers;

[Authorize]
public class OtpController : BaseController
{
    private readonly ICurrentUser _currentUser;
    private readonly IOtpService _otpService;

    public OtpController(IOtpService otpService, ICurrentUser currentUser)
    {
        _otpService = otpService;
        _currentUser = currentUser;
    }

    //[HttpPost]
    //[Route("Add")]
    //public async Task<ActionResult> Add([FromBody] OtpModel model)
    //{
    //    await _otpService.Add(model);
    //    return Ok();
    //}

    //[HttpGet]
    //[Route("GetAll")]
    //[SwaggerResponse(StatusCodes.Status200OK, "Return Otp data", typeof(List<Otp>))]
    //public async Task<ActionResult> GetAll()
    //{
    //    var result = await _otpService.GetAll();
    //    return Ok(result);
    //}

    //[HttpGet]
    //[Route("GetById")]
    //[SwaggerResponse(StatusCodes.Status200OK, "Return Otp data", typeof(Otp))]
    //public async Task<ActionResult> GetById([FromQuery] int id)
    //{
    //    var result = await _otpService.GetById(id);
    //    return Ok(result);
    //}

    //[HttpPatch]
    //[Route("Update")]
    //public async Task<ActionResult> Update([FromBody] OtpModel otp)
    //{
    //    await _otpService.Update(otp);
    //    return Ok();
    //}

    //[HttpDelete]
    //[Route("Delete")]
    //public async Task<ActionResult> Delete([FromQuery] int id)
    //{
    //    await _otpService.Delete(id);
    //    return Ok();
    //}
}