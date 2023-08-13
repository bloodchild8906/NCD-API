using MH.Domain.Model;
using MH.Domain.ViewModel;


namespace MH.Application.IService;
//todo: clarification
//why are we returning view models here? 
//an api should not be concerned with the UI of an integration

public interface IPatientService
{
    Task<List<PatientViewModel>> GetAll();
    Task<PatientViewModel> GetById(int id);
    Task Add(PatientModel patient);
    Task Update(PatientModel patient);
    Task Delete(int id); 
}