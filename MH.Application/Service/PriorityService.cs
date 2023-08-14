using AutoMapper;
using MH.Application.IService;
using MH.Domain.Dto;
using MH.Domain.IRepository;
using MH.Domain.Model;
using MH.Domain.UnitOfWork;

namespace MH.Application.Service;

public class PriorityService : IPriorityService
{
    private readonly IMapper _mapper;
    private readonly IPriorityRepository _priorityRepository;
    private readonly IUnitOfWork _unitOfWork;

    public PriorityService(IPriorityRepository priorityRepository, IMapper mapper, IUnitOfWork unitOfWork)
    {
        _priorityRepository = priorityRepository;
        _mapper = mapper;
        _unitOfWork = unitOfWork;
    }

    public async Task Add(PriorityModel priority)
    {
        var data = _mapper.Map<Domain.DBModel.Priority>(priority);
        await _unitOfWork.PriorityRepository.Insert(data);
        await _unitOfWork.CommitAsync();
    }

    public async Task<List<Priority>> GetAll()
    {
        var data = await _unitOfWork.PriorityRepository.GetAll(priority => !priority.IsDeleted);
        var result = _mapper.Map<List<Priority>>(data);
        return result.OrderByDescending(priorityViewModel => priorityViewModel.DateCreated).ToList();
    }

    public async Task<Priority> GetById(int id)
    {
        var data = await _unitOfWork.PriorityRepository.FindBy(priority => !priority.IsDeleted && priority.Id == id);
        var result = _mapper.Map<Priority>(data);
        return result;
    }

    public async Task Update(PriorityModel priority)
    {
        var existingData = await _unitOfWork
            .PriorityRepository
            .FindBy(priorityFilter => priorityFilter.Id == priority.Id && !priorityFilter.IsDeleted);
        existingData.Name = priority.Name;
        await _unitOfWork.PriorityRepository.Update(existingData);
        await _unitOfWork.CommitAsync();
    }

    public async Task Delete(int id)
    {
        var existingData = await _unitOfWork.PriorityRepository.FindBy(x => x.Id == id && !x.IsDeleted);
        existingData.IsDeleted = true;
        await _unitOfWork.PriorityRepository.Update(existingData);
        await _unitOfWork.CommitAsync();
    }
}