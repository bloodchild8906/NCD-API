
namespace MH.Domain.Configuration;

public class TwilioConfiguration
{
    public required  string Sid { get; set; }
    public required string Token { get; set; }
    public required string PhoneNumber { get; set; }
}