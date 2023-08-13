using MH.Domain.DBModel;
using MH.Domain.IRepository;
using MH.Infrastructure.DBContext;

namespace MH.Infrastructure.Repository;

public class IssueRepository : Repository<Issue, int>, IIssueRepository
{
    private readonly ApplicationDbContext _context;

    public IssueRepository(ApplicationDbContext context) : base(context)
    {
        _context = context;
    }
}