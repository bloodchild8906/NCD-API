using AutoMapper;
using MH.Application.IService;
using MH.Domain.DBModel;
using MH.Domain.IRepository;
using MH.Domain.Model;
using MH.Domain.UnitOfWork;
using MH.Domain.ViewModel;


namespace MH.Application.Service;

public class PatientService : IPatientService
{
    private readonly IPatientRepository _patientRepository;
    private readonly IMapper _mapper;
    private readonly IUnitOfWork _unitOfWork;

    public PatientService(IPatientRepository patientRepository, IMapper mapper, IUnitOfWork unitOfWork)
    {
        _patientRepository = patientRepository;
        _mapper = mapper;
        _unitOfWork = unitOfWork;
    }
    public async Task Add(PatientModel patient)
    {
        var data = _mapper.Map<Patient>(patient);
        await _unitOfWork.PatientRepository.Insert(data);
        await _unitOfWork.CommitAsync();
    }

    public async Task<List<PatientViewModel>> GetAll()
    {
        var data = await _unitOfWork.PatientRepository.GetAll(x => !x.IsDeleted);
        var result = _mapper.Map<List<PatientViewModel>>(data);
        return result.OrderByDescending(x=> x.Id).ToList();
    }

    public async Task<PatientViewModel> GetById(int id)
    {
        var data = await _unitOfWork.PatientRepository.FindBy(x => !x.IsDeleted && x.Id == id);
        var result = _mapper.Map<PatientViewModel>(data);
        return result;
    }

    public async Task Update(PatientModel patient)
    {
        var entity = await _unitOfWork.PatientRepository.FindBy(x => x.Id == patient.Id && !x.IsDeleted);
        entity.PatientNumber = patient.PatientNumber;

        entity.Name = patient.Name;
        entity.Surname = patient.Surname;
        entity.Gender = patient.Gender;
        entity.PhoneNumber = patient.PhoneNumber;
        entity.Age = patient.Age;

        entity.Gesttational = patient.Gesttational;
        entity.DateOfBirth = patient.DateOfBirth;
        entity.Province = patient.Province;
        entity.District = patient.District;
        entity.Institution = patient.Institution;


        await _unitOfWork.PatientRepository.Update(entity);
        await _unitOfWork.CommitAsync();
    }

    public async Task Delete(int id)
    {
        var entity = await _unitOfWork
            .PatientRepository
            .FindBy(patient => patient.Id == id && !patient.IsDeleted);
        entity.IsDeleted = true;
        await _unitOfWork.PatientRepository.Update(entity);
        await _unitOfWork.CommitAsync();
    }  
}