using MH.Domain.Model;
using MH.Domain.ViewModel;


namespace MH.Application.IService;
//todo: clarification
//why are we returning view models here? 
//an api should not be concerned with the UI of an integration

public interface IOtpService
{
    Task<OtpViewModel> GetById(int id);
    Task<OtpViewModel> GetByMobileNo(string mobileNo);
    Task Add(OtpModel otp);
}