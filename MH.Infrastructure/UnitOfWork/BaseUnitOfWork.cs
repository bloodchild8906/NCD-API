using MH.Infrastructure.DBContext;

namespace MH.Infrastructure.UnitOfWork;

public class BaseUnitOfWork
{
    private readonly ApplicationDbContext _dbContext;
    public BaseUnitOfWork(ApplicationDbContext dbContext) 
    {
        _dbContext = dbContext;
    }

    public void ClearChangeTracker()
    {
        _dbContext.ChangeTracker.Clear();
    }

    public void Commit()
        => _dbContext.SaveChanges();


    public async Task CommitAsync()
        => await _dbContext.SaveChangesAsync();


    public void Rollback()
        => _dbContext.Dispose();


    public async Task RollbackAsync()
        => await _dbContext.DisposeAsync();
}