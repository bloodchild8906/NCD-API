using AutoMapper;
using MH.Domain.Model;
using TicketStatus = MH.Domain.Dto.TicketStatus;


namespace MH.Domain.Mapping;

public class TicketStatusMapping : Profile
{
    public TicketStatusMapping()
    {
        CreateMap<DBModel.TicketStatus,TicketStatusModel>().ReverseMap();
        CreateMap<DBModel.TicketStatus,TicketStatus>().ReverseMap();
    }
}