using MH.Domain.Dto;
using MH.Domain.Model;


namespace MH.Application.IService;

    public interface ITicketDetailsService
    {
        Task<List<TicketDetail>> GetAll();
        Task<TicketDetail> GetById(int id);
        Task Add(TicketDetailsModel ticketDetails);
        Task Update(TicketDetailsModel ticketDetails);
        Task Delete(int id); 
    }

