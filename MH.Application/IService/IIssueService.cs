using MH.Domain.Dto;
using MH.Domain.Model;


namespace MH.Application.IService;

public interface IIssueService
{
    Task<List<Issue>> GetAll();
    Task<Issue> GetById(int id);
    Task Add(IssueModel issue);
    Task Update(IssueModel issue);
    Task Delete(int id); 
}