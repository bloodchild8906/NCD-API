using AutoMapper;
using MH.Domain.Model;
using Otp = MH.Domain.Dto.Otp;


namespace MH.Domain.Mapping;

public class OtpMapping : Profile
{
    public OtpMapping()
    {
        CreateMap<DBModel.Otp,OtpModel>().ReverseMap();
        CreateMap<DBModel.Otp,Otp>().ReverseMap();
    }
}