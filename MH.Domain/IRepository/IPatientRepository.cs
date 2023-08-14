using MH.Domain.DBModel;

namespace MH.Domain.IRepository;

public interface IPatientRepository : IRepository<Patient, int>
{
}