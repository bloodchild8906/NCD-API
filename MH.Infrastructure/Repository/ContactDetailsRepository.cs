using MH.Domain.DBModel;
using MH.Domain.IRepository;
using MH.Infrastructure.DBContext;

namespace MH.Infrastructure.Repository;

public class ContactDetailsRepository : Repository<ContactDetails, int>, IContactDetailsRepository
{
    private readonly ApplicationDbContext _context;

    public ContactDetailsRepository(ApplicationDbContext context) : base(context)
    {
        _context = context;
    }
}