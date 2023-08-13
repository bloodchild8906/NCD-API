using AutoMapper;
using MH.Application.IService;
using MH.Domain.DBModel;
using MH.Domain.IRepository;
using MH.Domain.Model;
using MH.Domain.UnitOfWork;
using MH.Domain.ViewModel;


namespace MH.Application.Service;

public class IssueService : IIssueService
{
    private readonly IIssueRepository _issueRepository;
    private readonly IMapper _mapper;
    private readonly IUnitOfWork _unitOfWork;

    public IssueService(IIssueRepository issueRepository, IMapper mapper, IUnitOfWork unitOfWork)
    {
        _issueRepository = issueRepository;
        _mapper = mapper;
        _unitOfWork = unitOfWork;
    }
    public async Task Add(IssueModel issue)
    {
        var data = _mapper.Map<Issue>(issue);
        await _unitOfWork.IssueRepository.Insert(data);
        await _unitOfWork.CommitAsync();
    }

    public async Task<List<IssueViewModel>> GetAll()
    {
        var data = await _unitOfWork.IssueRepository.GetAll(issue => !issue.IsDeleted);
        var result = _mapper.Map<List<IssueViewModel>>(data);
        return result.OrderByDescending(issueViewModel=> issueViewModel.DateCreated).ToList();
    }

    public async Task<IssueViewModel> GetById(int id)
    {
        var data = await _unitOfWork.IssueRepository.FindBy(issue => !issue.IsDeleted && issue.Id == id);
        var result = _mapper.Map<IssueViewModel>(data);
        return result;
    }

    public async Task Update(IssueModel issue)
    {
        var existingData = await _unitOfWork
            .IssueRepository
            .FindBy(issueFilter => issueFilter.Id == issue.Id && !issueFilter.IsDeleted);
        existingData.Name = issue.Name;
                
        await _unitOfWork.IssueRepository.Update(existingData);
        await _unitOfWork.CommitAsync();
    }

    public async Task Delete(int id)
    {
        var existingData = await _unitOfWork.IssueRepository.FindBy(issue => issue.Id == id && !issue.IsDeleted);
        existingData.IsDeleted = true;
        await _unitOfWork.IssueRepository.Update(existingData);
        await _unitOfWork.CommitAsync();
    }  
}