using AutoMapper;
using MH.Domain.Model;
using Patient = MH.Domain.Dto.Patient;


namespace MH.Domain.Mapping;

public class PatientMapping : Profile
{
    public PatientMapping()
    {
        CreateMap<PatientModel,DBModel.Patient>();
        CreateMap<DBModel.Patient, Patient>();
    }
}