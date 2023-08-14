
using MH.Domain.Dto;
using MH.Domain.Model;


namespace MH.Application.IService;

public interface IMedicalHistoryService
{
    Task<List<MedicalHistory>> GetAll();
    Task<MedicalHistory> GetById(int id);
    Task<List<MedicalHistory>> GetByPatientId(int patientId);
    Task Add(MedicalHistoryModel medicalHistory);
    Task Update(MedicalHistoryModel medicalHistory);
    Task Delete(int id); 
}