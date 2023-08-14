using MH.Domain.IRepository;

namespace MH.Domain.UnitOfWork;

public interface IUnitOfWork
{
    void ClearChangeTracker();
    void Commit();
    void Rollback();
    Task CommitAsync();
    Task RollbackAsync();

    #region Repositories

    IPositionRepository PositionRepository { get; }
    IIssueRepository IssueRepository { get; }
    ITicketDetailsRepository TicketDetailsRepository { get; }
    IPriorityRepository PriorityRepository { get; }
    ITicketStatusRepository TicketStatusRepository { get; }
    IOtpRepository OtpRepository { get; }
    IAppointmentRepository AppointmentRepository { get; }
    IMedicalHistoryRepository MedicalHistoryRepository { get; }
    IPatientRepository PatientRepository { get; }
    IContactDetailsRepository ContactDetailsRepository { get; }
    IUserProfileRepository UserProfileRepository { get; }

    #endregion
}