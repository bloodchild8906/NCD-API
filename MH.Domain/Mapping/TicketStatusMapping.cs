using AutoMapper;
using MH.Domain.DBModel;
using MH.Domain.Model;

namespace MH.Domain.Mapping;

public class TicketStatusMapping : Profile
{
    public TicketStatusMapping()
    {
        CreateMap<TicketStatus, TicketStatusModel>().ReverseMap();
        CreateMap<TicketStatus, Dto.TicketStatus>().ReverseMap();
    }
}