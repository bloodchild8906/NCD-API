using AutoMapper;
using MH.Domain.Model;
using MedicalHistory = MH.Domain.Dto.MedicalHistory;

namespace MH.Domain.Mapping;

public class MedicalHistoryMapping : Profile
{
    public MedicalHistoryMapping()
    {
        CreateMap<MedicalHistoryModel, DBModel.MedicalHistory>();
        CreateMap<DBModel.MedicalHistory, MedicalHistory>()
            .ForMember(src => src.Name, dest => dest.MapFrom(x => x.Patient.Name))
            .ForMember(src => src.Surname, dest => dest.MapFrom(x => x.Patient.Surname))
            .ForMember(src => src.PhoneNumber, dest => dest.MapFrom(x => x.Patient.PhoneNumber))
            .ForMember(src => src.Gender, dest => dest.MapFrom(x => x.Patient.Gender))
            .ForMember(src => src.Age, dest => dest.MapFrom(x => x.Patient.Age))
            .ForMember(src => src.Province, dest => dest.MapFrom(x => x.Patient.Province))
            .ReverseMap();
    }
}