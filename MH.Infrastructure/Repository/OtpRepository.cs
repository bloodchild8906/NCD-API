using MH.Domain.DBModel;
using MH.Domain.IRepository;
using MH.Infrastructure.DBContext;

namespace MH.Infrastructure.Repository;

public class OtpRepository : Repository<Otp, int>, IOtpRepository
{
    private readonly ApplicationDbContext _context;

    public OtpRepository(ApplicationDbContext context) : base(context)
    {
        _context = context;
    }
}