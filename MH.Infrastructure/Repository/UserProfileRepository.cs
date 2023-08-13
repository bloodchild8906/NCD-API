using MH.Domain.DBModel;
using MH.Domain.IRepository;
using MH.Infrastructure.DBContext;

namespace MH.Infrastructure.Repository;

public class UserProfileRepository : Repository<UserProfile, int>, IUserProfileRepository
{
    private readonly ApplicationDbContext _context;

    public UserProfileRepository(ApplicationDbContext context) : base(context)
    {
        _context = context;
    }
}