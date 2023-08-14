using AutoMapper;
using MH.Domain.DBModel;
using MH.Domain.Model;

namespace MH.Domain.Mapping;

public class IssueMapping : Profile
{
    public IssueMapping()
    {
        CreateMap<Issue, IssueModel>().ReverseMap();
        CreateMap<Issue, Dto.Issue>().ReverseMap();
    }
}