using MH.Domain.Dto;
using MH.Domain.Model;

namespace MH.Application.IService;

public interface IPatientService
{
    Task<List<Patient>> GetAll();
    Task<Patient> GetById(int id);
    Task Add(PatientModel patient);
    Task Update(PatientModel patient);
    Task Delete(int id);
}