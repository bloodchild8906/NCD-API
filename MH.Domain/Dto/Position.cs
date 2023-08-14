
namespace MH.Domain.Dto;

public class Position
{
    public int? Id { get; set; }
    public string Name { get; set; }
    public string? Description { get; set; }

    public DateTime DateCreated { get; set; }
}