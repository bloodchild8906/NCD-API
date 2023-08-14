namespace MH.Domain.Dto;

public class TicketDetail
{
    public int? Id { get; set; }
    public int UserId { get; set; }
    public string Subject { get; set; }
    public int PriorityId { get; set; }
    public int StatusId { get; set; }
    public int IssueId { get; set; }
    public string Description { get; set; }

    public DateTime DateCreated { get; set; }
}