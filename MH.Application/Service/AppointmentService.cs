using AutoMapper;
using MH.Application.IService;
using MH.Domain.IRepository;
using MH.Domain.Model;
using MH.Domain.UnitOfWork;
using Appointment = MH.Domain.Dto.Appointment;


namespace MH.Application.Service;

public class AppointmentService : IAppointmentService
{
    private readonly IAppointmentRepository _appointmentRepository;
    private readonly IMapper _mapper;
    private readonly IUnitOfWork _unitOfWork;

    public AppointmentService(IAppointmentRepository appointmentRepository, IMapper mapper, IUnitOfWork unitOfWork)
    {
        _appointmentRepository = appointmentRepository;
        _mapper = mapper;
        _unitOfWork = unitOfWork;
    }
    public async Task Add(AppointmentModel appointment)
    {
        var data = _mapper.Map<Domain.DBModel.Appointment>(appointment);
        await _unitOfWork.AppointmentRepository.Insert(data);
        await _unitOfWork.CommitAsync();
    }

    public async Task<List<Appointment>> GetAll()
    {
        var data = await _unitOfWork
            .AppointmentRepository
                //WHY?? what is x and y?
                //name things what they are
            .GetAll(appointment=> !appointment.IsDeleted, appointment=> appointment.Patient);
        var result = _mapper.Map<List<Appointment>>(data);
        return result.OrderByDescending(appointmentViewModel=> appointmentViewModel.DateCreated).ToList();
    }

    public async Task<Appointment> GetById(int id)
    {
        var data = await _unitOfWork
            .AppointmentRepository
            .FindBy(appointment => !appointment.IsDeleted && appointment.Id == id, 
                appointment => appointment.Patient);
        var result = _mapper.Map<Appointment>(data);
        return result;
    }
    public async Task<List<Appointment>> GetByPatientId(int patientId)
    {
        var data = await _unitOfWork
            .AppointmentRepository
            .GetAll(appointment => !appointment.IsDeleted && appointment.PatientId == patientId, 
                appointment => appointment.Patient);
        var result = _mapper.Map<List<Appointment>>(data);
        return result;
    }

    public async Task Update(AppointmentModel appointment)
    {
        var existingData = await _unitOfWork
            .AppointmentRepository
            .FindBy(appointmentFilter => appointmentFilter.Id == appointment.Id && !appointmentFilter.IsDeleted);
        existingData.DateOfAppointment = appointment.DateOfAppointment;
        await _unitOfWork.AppointmentRepository.Update(existingData);
        await _unitOfWork.CommitAsync();
    }

    public async Task Delete(int id)
    {
        var existingData = await _unitOfWork
            .AppointmentRepository
            .FindBy(appointment => appointment.Id == id && !appointment.IsDeleted);
        existingData.IsDeleted = true;
        await _unitOfWork.AppointmentRepository.Update(existingData);
        await _unitOfWork.CommitAsync();
    }  
}