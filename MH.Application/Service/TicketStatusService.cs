using AutoMapper;
using MH.Application.IService;
using MH.Domain.DBModel;
using MH.Domain.IRepository;
using MH.Domain.Model;
using MH.Domain.UnitOfWork;
using MH.Domain.ViewModel;


namespace MH.Application.Service;

public class TicketStatusService : ITicketStatusService
{
    private readonly ITicketStatusRepository _ticketStatusRepository;
    private readonly IMapper _mapper;
    private readonly IUnitOfWork _unitOfWork;

    public TicketStatusService(ITicketStatusRepository ticketStatusRepository, IMapper mapper, IUnitOfWork unitOfWork)
    {
        _ticketStatusRepository = ticketStatusRepository;
        _mapper = mapper;
        _unitOfWork = unitOfWork;
    }
    public async Task Add(TicketStatusModel ticketStatus)
    {
        var data = _mapper.Map<TicketStatus>(ticketStatus);
        await _unitOfWork.TicketStatusRepository.Insert(data);
        await _unitOfWork.CommitAsync();
    }

    public async Task<List<TicketStatusViewModel>> GetAll()
    {
        var data = await _unitOfWork
            .TicketStatusRepository
            .GetAll(ticketStatus => !ticketStatus.IsDeleted);
        var result = _mapper.Map<List<TicketStatusViewModel>>(data);
        return result.OrderByDescending(x=> x.DateCreated).ToList();
    }

    public async Task<TicketStatusViewModel> GetById(int id)
    {
        var data = await _unitOfWork
            .TicketStatusRepository
            .FindBy(ticketStatus => !ticketStatus.IsDeleted && ticketStatus.Id == id);
        var result = _mapper.Map<TicketStatusViewModel>(data);
        return result;
    }

    public async Task Update(TicketStatusModel ticketStatus)
    {
        var existingData = await _unitOfWork.TicketStatusRepository.FindBy(status => status.Id == ticketStatus.Id && !status.IsDeleted);
        existingData.Name = ticketStatus.Name;
                
        await _unitOfWork.TicketStatusRepository.Update(existingData);
        await _unitOfWork.CommitAsync();
    }

    public async Task Delete(int id)
    {
        var existingData = await _unitOfWork.TicketStatusRepository.FindBy(ticketStatus => ticketStatus.Id == id && !ticketStatus.IsDeleted);
        existingData.IsDeleted = true;
        await _unitOfWork.TicketStatusRepository.Update(existingData);
        await _unitOfWork.CommitAsync();
    }  
}