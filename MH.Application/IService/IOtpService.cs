using MH.Domain.Dto;
using MH.Domain.Model;


namespace MH.Application.IService;

public interface IOtpService
{
    Task<Otp> GetById(int id);
    Task<Otp> GetByMobileNo(string mobileNo);
    Task Add(OtpModel otp);
}