using MH.Domain.Model;
using MH.Domain.ViewModel;


namespace MH.Application.IService;
//todo: clarification
//why are we returning view models here? 
//an api should not be concerned with the UI of an integration

public interface ITicketStatusService
{
    Task<List<TicketStatusViewModel>> GetAll();
    Task<TicketStatusViewModel> GetById(int id);
    Task Add(TicketStatusModel ticketStatus);
    Task Update(TicketStatusModel ticketStatus);
    Task Delete(int id); 
}