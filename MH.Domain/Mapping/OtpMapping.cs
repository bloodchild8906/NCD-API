using AutoMapper;
using MH.Domain.DBModel;
using MH.Domain.Model;

namespace MH.Domain.Mapping;

public class OtpMapping : Profile
{
    public OtpMapping()
    {
        CreateMap<Otp, OtpModel>().ReverseMap();
        CreateMap<Otp, Dto.Otp>().ReverseMap();
    }
}