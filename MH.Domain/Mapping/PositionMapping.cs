using AutoMapper;
using MH.Domain.Model;
using Position = MH.Domain.Dto.Position;


namespace MH.Domain.Mapping;

public class PositionMapping : Profile
{
    public PositionMapping()
    {
        CreateMap<DBModel.Position,PositionModel>().ReverseMap();
        CreateMap<DBModel.Position,Position>().ReverseMap();
    }
}