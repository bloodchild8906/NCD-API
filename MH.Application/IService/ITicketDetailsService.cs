using MH.Domain.Model;
using MH.Domain.ViewModel;


namespace MH.Application.IService;
//todo: clarification
//why are we returning view models here? 
//an api should not be concerned with the UI of an integration

    public interface ITicketDetailsService
    {
        Task<List<TicketDetailsViewModel>> GetAll();
        Task<TicketDetailsViewModel> GetById(int id);
        Task Add(TicketDetailsModel ticketDetails);
        Task Update(TicketDetailsModel ticketDetails);
        Task Delete(int id); 
    }

