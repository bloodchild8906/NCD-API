namespace MH.Infrastructure.External;

public interface ISmsService
{
    Task SendSms(string sendTo, string body);
}