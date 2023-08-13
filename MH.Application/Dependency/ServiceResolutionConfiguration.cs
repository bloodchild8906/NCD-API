using MH.Application.IService;
using MH.Application.Mail;
using MH.Application.Service;
using MH.Domain.IEntity;
using MH.Domain.UnitOfWork;
using MH.Infrastructure.UnitOfWork;
using Microsoft.Extensions.DependencyInjection;

namespace MH.Application.Dependency;

public static class ServiceResolutionConfiguration
{
    //todo: Replace this class and have a add service extension method for each service instead for example: services.AddIssueService()
    //todo: have unit tests for each service
    public static IServiceCollection AddServices(this IServiceCollection services)
    {
        services.AddScoped<IIssueService, IssueService>();
        services.AddScoped<ITicketDetailsService, TicketDetailsService>();
        services.AddScoped<IPriorityService, PriorityService>();
        services.AddScoped<ITicketStatusService, TicketStatusService>();
        services.AddScoped<IOtpService, OtpService>();
        services.AddScoped<IAppointmentService, AppointmentService>();
        services.AddScoped<IMedicalHistoryService, MedicalHistoryService>();
        services.AddScoped<IPatientService, PatientService>();
        services.AddScoped<IContactDetailsService, ContactDetailsService>();
        services.AddScoped<IPositionService, PositionService>();
        services.AddScoped<IUserProfileService, UserProfileService>();
        services.AddScoped<IUnitOfWork, UnitOfWork>();
        services.AddScoped<ICurrentUser, CurrentUser>();
        services.AddScoped<IUserService, UserService>();
        services.AddScoped<IPermissionService, PermissionService>();
        services.AddScoped<IMailHelper, MailHelper>();
        services.AddScoped<IRoleService, RoleService>();

        return services;
    }
}