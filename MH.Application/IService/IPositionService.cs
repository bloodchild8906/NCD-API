using MH.Domain.Dto;
using MH.Domain.Model;

namespace MH.Application.IService;

public interface IPositionService
{
    Task<List<Position>> GetAll();
    Task<Position> GetById(int id);
    Task Add(PositionModel position);
    Task Update(PositionModel position);
    Task Delete(int id);
}