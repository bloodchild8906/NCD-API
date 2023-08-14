
namespace MH.Domain.Dto;

public class UserProfile
{
    public int? Id { get; set; }
    public int UserId { get; set; }
    public string FirstName { get; set; }   
    public string LastName { get; set; }
    public byte[]? Photo { get; set; }
    public string? Notes { get; set; }
    public DateTime DateCreated { get; set; }
}