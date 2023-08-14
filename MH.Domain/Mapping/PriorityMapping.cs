using AutoMapper;
using MH.Domain.Model;
using Priority = MH.Domain.Dto.Priority;


namespace MH.Domain.Mapping;

public class PriorityMapping : Profile
{
    public PriorityMapping()
    {
        CreateMap<DBModel.Priority,PriorityModel>().ReverseMap();
        CreateMap<DBModel.Priority,Priority>().ReverseMap();
    }
}