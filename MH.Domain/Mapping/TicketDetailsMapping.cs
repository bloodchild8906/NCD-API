using AutoMapper;
using MH.Domain.DBModel;
using MH.Domain.Dto;
using MH.Domain.Model;

namespace MH.Domain.Mapping;

public class TicketDetailsMapping : Profile
{
    public TicketDetailsMapping()
    {
        CreateMap<TicketDetails, TicketDetailsModel>().ReverseMap();
        CreateMap<TicketDetails, TicketDetail>().ReverseMap();
    }
}