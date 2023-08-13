using MH.Domain.Model;
using MH.Domain.ViewModel;


namespace MH.Application.IService;
//todo: clarification
//why are we returning view models here? 
//an api should not be concerned with the UI of an integration

public interface IIssueService
{
    Task<List<IssueViewModel>> GetAll();
    Task<IssueViewModel> GetById(int id);
    Task Add(IssueModel issue);
    Task Update(IssueModel issue);
    Task Delete(int id); 
}