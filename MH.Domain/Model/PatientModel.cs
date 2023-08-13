
namespace MH.Domain.Model;

public class PatientModel
{
    public int? Id { get; set; }

    public string PatientNumber { get; set; }
    public string Name { get; set; }
    public string Surname { get; set; }
    public string Gender { get; set; }
    public string PhoneNumber { get; set; }
    public double Age { get; set; }

    public bool? Gesttational { get; set; }
    public DateTime? DateOfBirth { get; set; }
    public string? Province { get; set; }
    public string? District { get; set; }
    public string? Institution { get; set; }

}