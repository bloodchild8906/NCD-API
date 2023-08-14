using AutoMapper;
using MH.Domain.Model;
using Issue = MH.Domain.Dto.Issue;


namespace MH.Domain.Mapping;

public class IssueMapping : Profile
{
    public IssueMapping()
    {
        CreateMap<DBModel.Issue,IssueModel>().ReverseMap();
        CreateMap<DBModel.Issue,Issue>().ReverseMap();
    }
}