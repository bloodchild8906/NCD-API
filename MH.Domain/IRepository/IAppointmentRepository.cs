using MH.Domain.DBModel;

namespace MH.Domain.IRepository;

public interface IAppointmentRepository : IRepository<Appointment, int>
{
}