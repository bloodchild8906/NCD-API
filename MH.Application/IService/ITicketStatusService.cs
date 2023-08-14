using MH.Domain.Dto;
using MH.Domain.Model;

namespace MH.Application.IService;

public interface ITicketStatusService
{
    Task<List<TicketStatus>> GetAll();
    Task<TicketStatus> GetById(int id);
    Task Add(TicketStatusModel ticketStatus);
    Task Update(TicketStatusModel ticketStatus);
    Task Delete(int id);
}