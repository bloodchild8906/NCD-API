using MH.Domain.Dto;
using MH.Domain.Model;

namespace MH.Application.IService;

public interface IPriorityService
{
    Task<List<Priority>> GetAll();
    Task<Priority> GetById(int id);
    Task Add(PriorityModel priority);
    Task Update(PriorityModel priority);
    Task Delete(int id);
}