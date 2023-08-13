using MH.Domain.Model;
using MH.Domain.ViewModel;


namespace MH.Application.IService;

//todo: clarification
//why are we returning view models here? 
//an api should not be concerned with the UI of an integration
public interface IAppointmentService
{
    Task<List<AppointmentViewModel>> GetAll();
    Task<AppointmentViewModel> GetById(int id);
    Task<List<AppointmentViewModel>> GetByPatientId(int patientId);
    Task Add(AppointmentModel appointment);
    Task Update(AppointmentModel appointment);
    Task Delete(int id); 
}