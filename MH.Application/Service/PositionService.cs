using AutoMapper;
using MH.Application.IService;
using MH.Domain.IRepository;
using MH.Domain.Model;
using MH.Domain.UnitOfWork;
using Position = MH.Domain.Dto.Position;


namespace MH.Application.Service;

public class PositionService : IPositionService
{
    private readonly IPositionRepository _positionRepository;
    private readonly IMapper _mapper;
    private readonly IUnitOfWork _unitOfWork;

    public PositionService(IPositionRepository positionRepository, IMapper mapper, IUnitOfWork unitOfWork)
    {
        _positionRepository = positionRepository;
        _mapper = mapper;
        _unitOfWork = unitOfWork;
    }

    public async Task Add(PositionModel position)
    {
        var data = _mapper.Map<Domain.DBModel.Position>(position);
        await _unitOfWork.PositionRepository.Insert(data);
        await _unitOfWork.CommitAsync();
    }

    public async Task<List<Position>> GetAll()
    {
        var data = await _unitOfWork
            .PositionRepository
            .GetAll(position => !position.IsDeleted);
        var result = _mapper.Map<List<Position>>(data);
        return result.OrderByDescending(x => x.DateCreated).ToList();
    }

    public async Task<Position> GetById(int id)
    {
        var data = await _unitOfWork
            .PositionRepository
            .FindBy(position => !position.IsDeleted && position.Id == id);
        var result = _mapper.Map<Position>(data);
        return result;
    }

    public async Task Update(PositionModel position)
    {
        var existingData = await _unitOfWork
            .PositionRepository
            .FindBy(x => x.Id == position.Id && !x.IsDeleted);
        existingData.Name = position.Name;
        existingData.Description = position.Description;

        await _unitOfWork.PositionRepository.Update(existingData);
        await _unitOfWork.CommitAsync();
    }

    public async Task Delete(int id)
    {
        var existingData = await _unitOfWork
            .PositionRepository
            .FindBy(position => position.Id == id && !position.IsDeleted);
        existingData.IsDeleted = true;
        await _unitOfWork.PositionRepository.Update(existingData);
        await _unitOfWork.CommitAsync();
    }
}