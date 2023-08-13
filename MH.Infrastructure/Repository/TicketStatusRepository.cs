using MH.Domain.DBModel;
using MH.Domain.IRepository;
using MH.Infrastructure.DBContext;

namespace MH.Infrastructure.Repository;

public class TicketStatusRepository : Repository<TicketStatus, int>, ITicketStatusRepository
{
    private readonly ApplicationDbContext _context;

    public TicketStatusRepository(ApplicationDbContext context) : base(context)
    {
        _context = context;
    }
}