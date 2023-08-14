
namespace MH.Domain.Dto;

public class Otp
{
    public int? Id { get; set; }
    public int Code { get; set; }
    public string MobileNo { get; set; }

    public DateTime DateCreated { get; set; }
}