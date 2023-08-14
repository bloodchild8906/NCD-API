using MH.Application.IService;
using MH.Domain.Dto;
using MH.Domain.IEntity;
using MH.Domain.Model;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Swashbuckle.AspNetCore.Annotations;

namespace MH.Api.Controllers;

[Authorize]
public class PatientController : BaseController
{
    private readonly ICurrentUser _currentUser;
    private readonly IPatientService _patientService;

    public PatientController(IPatientService patientService, ICurrentUser currentUser)
    {
        _patientService = patientService;
        _currentUser = currentUser;
    }

    [HttpPost]
    [Route("Add")]
    public async Task<ActionResult> Add([FromBody] PatientModel model)
    {
        await _patientService.Add(model);
        return Ok();
    }

    [HttpGet]
    [Route("GetAll")]
    [SwaggerResponse(StatusCodes.Status200OK, "Return Patient data", typeof(List<Patient>))]
    public async Task<ActionResult> GetAll()
    {
        var result = await _patientService.GetAll();
        return Ok(result);
    }

    [HttpGet]
    [Route("GetById")]
    [SwaggerResponse(StatusCodes.Status200OK, "Return Patient data", typeof(Patient))]
    public async Task<ActionResult> GetById([FromQuery] int id)
    {
        var result = await _patientService.GetById(id);
        return Ok(result);
    }

    [HttpPatch]
    [Route("Update")]
    public async Task<ActionResult> Update([FromBody] PatientModel patient)
    {
        await _patientService.Update(patient);
        return Ok();
    }

    [HttpDelete]
    [Route("Delete")]
    public async Task<ActionResult> Delete([FromQuery] int id)
    {
        await _patientService.Delete(id);
        return Ok();
    }
}