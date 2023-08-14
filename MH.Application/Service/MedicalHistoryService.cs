using AutoMapper;
using MH.Application.IService;
using MH.Domain.Dto;
using MH.Domain.IRepository;
using MH.Domain.Model;
using MH.Domain.UnitOfWork;

namespace MH.Application.Service;

public class MedicalHistoryService : IMedicalHistoryService
{
    private readonly IMapper _mapper;
    private readonly IMedicalHistoryRepository _medicalHistoryRepository;
    private readonly IUnitOfWork _unitOfWork;

    public MedicalHistoryService(IMedicalHistoryRepository medicalHistoryRepository, IMapper mapper,
        IUnitOfWork unitOfWork)
    {
        _medicalHistoryRepository = medicalHistoryRepository;
        _mapper = mapper;
        _unitOfWork = unitOfWork;
    }

    public async Task Add(MedicalHistoryModel medicalHistoryModel)
    {
        var medicalHistory = new Domain.DBModel.MedicalHistory
        {
            RecordedBy = medicalHistoryModel.RecordedBy,
            PatientId = medicalHistoryModel.PatientId,
            AtInstitution = medicalHistoryModel.AtInstitution,
            Glucose = medicalHistoryModel.Glucose,
            HBA1C = medicalHistoryModel.HBA1C,
            KeyTone = medicalHistoryModel.KeyTone,
            TotalColestorl = medicalHistoryModel.TotalColestorl,
            UricAcid = medicalHistoryModel.UricAcid,
            Lactate = medicalHistoryModel.Lactate,
            BloodPressue = medicalHistoryModel.BloodPressue,
            Recomendations = medicalHistoryModel.Recomendations,
            Remidies = medicalHistoryModel.Remidies,
            NextAppointmentDate = medicalHistoryModel.NextAppointmentDate,
            IsMedicated = medicalHistoryModel.IsMedicated
        };

        await _unitOfWork.MedicalHistoryRepository.Insert(medicalHistory);
        await _unitOfWork.CommitAsync();
    }

    public async Task<List<MedicalHistory>> GetAll()
    {
        var data = await _unitOfWork
            .MedicalHistoryRepository
            .GetAll(medicalHistory => !medicalHistory.IsDeleted,
                medicalHistory => medicalHistory.Patient);
        var result = _mapper.Map<List<MedicalHistory>>(data);
        return result.OrderByDescending(x => x.DateCreated).ToList();
    }

    public async Task<MedicalHistory> GetById(int id)
    {
        var data = await _unitOfWork.MedicalHistoryRepository.FindBy(
            medicalHistory => !medicalHistory.IsDeleted && medicalHistory.Id == id, y => y.Patient);
        var result = _mapper.Map<MedicalHistory>(data);
        return result;
    }

    public async Task<List<MedicalHistory>> GetByPatientId(int patientId)
    {
        var data = await _unitOfWork
            .MedicalHistoryRepository
            .GetAll(medicalHistory => !medicalHistory.IsDeleted && medicalHistory.PatientId == patientId,
                medicalHistory => medicalHistory.Patient);
        var result = _mapper.Map<List<MedicalHistory>>(data);
        return result;
    }

    public async Task Update(MedicalHistoryModel medicalHistoryModel)
    {
        var existingData =
            await _unitOfWork.MedicalHistoryRepository.FindBy(x => x.Id == medicalHistoryModel.Id && !x.IsDeleted);
        existingData.RecordedBy = medicalHistoryModel.RecordedBy;
        existingData.PatientId = medicalHistoryModel.PatientId;

        existingData.AtInstitution = medicalHistoryModel.AtInstitution;
        existingData.Glucose = medicalHistoryModel.Glucose;
        existingData.HBA1C = medicalHistoryModel.HBA1C;
        existingData.KeyTone = medicalHistoryModel.KeyTone;
        existingData.TotalColestorl = medicalHistoryModel.TotalColestorl;
        existingData.UricAcid = medicalHistoryModel.UricAcid;
        existingData.Lactate = medicalHistoryModel.Lactate;
        existingData.BloodPressue = medicalHistoryModel.BloodPressue;
        existingData.Recomendations = medicalHistoryModel.Recomendations;
        existingData.Remidies = medicalHistoryModel.Remidies;
        existingData.NextAppointmentDate = medicalHistoryModel.NextAppointmentDate;
        existingData.IsMedicated = medicalHistoryModel.IsMedicated;

        await _unitOfWork.MedicalHistoryRepository.Update(existingData);
        await _unitOfWork.CommitAsync();
    }

    public async Task Delete(int id)
    {
        var existingData = await _unitOfWork
            .MedicalHistoryRepository
            .FindBy(medicalHistory => medicalHistory.Id == id && !medicalHistory.IsDeleted);
        existingData.IsDeleted = true;
        await _unitOfWork.MedicalHistoryRepository.Update(existingData);
        await _unitOfWork.CommitAsync();
    }
}