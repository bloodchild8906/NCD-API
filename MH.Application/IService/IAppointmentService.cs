using MH.Domain.Dto;
using MH.Domain.Model;


namespace MH.Application.IService;

public interface IAppointmentService
{
    Task<List<Appointment>> GetAll();
    Task<Appointment> GetById(int id);
    Task<List<Appointment>> GetByPatientId(int patientId);
    Task Add(AppointmentModel appointment);
    Task Update(AppointmentModel appointment);
    Task Delete(int id); 
}