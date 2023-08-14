using AutoMapper;
using MH.Domain.DBModel;
using MH.Domain.Model;

namespace MH.Domain.Mapping;

public class PriorityMapping : Profile
{
    public PriorityMapping()
    {
        CreateMap<Priority, PriorityModel>().ReverseMap();
        CreateMap<Priority, Dto.Priority>().ReverseMap();
    }
}