using AutoMapper;
using MH.Domain.DBModel;
using MH.Domain.Model;

namespace MH.Domain.Mapping;

public class AppointmentMapping : Profile
{
    public AppointmentMapping()
    {
        CreateMap<Appointment, AppointmentModel>().ReverseMap();
        CreateMap<Appointment, Dto.Appointment>()
            .ForMember(src => src.Name, dest => dest.MapFrom(x => x.Patient.Name))
            .ForMember(src => src.Surname, dest => dest.MapFrom(x => x.Patient.Surname))
            .ForMember(src => src.PhoneNumber, dest => dest.MapFrom(x => x.Patient.PhoneNumber))
            .ForMember(src => src.Gender, dest => dest.MapFrom(x => x.Patient.Gender))
            .ForMember(src => src.Age, dest => dest.MapFrom(x => x.Patient.Age))
            .ReverseMap();
    }
}