
using MH.Domain.Model;
using MH.Domain.ViewModel;


namespace MH.Application.IService;
//todo: clarification
//why are we returning view models here? 
//an api should not be concerned with the UI of an integration

public interface IMedicalHistoryService
{
    Task<List<MedicalHistoryViewModel>> GetAll();
    Task<MedicalHistoryViewModel> GetById(int id);
    Task<List<MedicalHistoryViewModel>> GetByPatientId(int patientId);
    Task Add(MedicalHistoryModel medicalHistory);
    Task Update(MedicalHistoryModel medicalHistory);
    Task Delete(int id); 
}