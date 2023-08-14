using MH.Domain.Dto;
using MH.Domain.Model;

namespace MH.Application.IService;

public interface IContactDetailsService
{
    Task<List<ContactDetail>> GetAll();
    Task<ContactDetail> GetByUserId(int userId);
    Task Add(ContactDetailsModel contactDetails);
    Task Update(ContactDetailsModel contactDetails);
    Task Delete(int id);
}