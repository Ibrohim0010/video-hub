using VideoHub.Common.Data;
using VideoHub.Moduls.User.Repository.CommandRepository;
using VideoHub.Moduls.User.Repository.QueryRepository;

namespace VideoHub.Common.UnitOfWork;

public class UnitOfWork:IUnitOfWork
{
    private readonly BaseDbContext _context;

    public UnitOfWork(BaseDbContext context)
    {
        _context= context;
        UserQueryRepository = new UserQueryRepository(_context);
        UserCommandRepository = new UserCommandRepository(_context);
        
    }
    public IUserQueryRepository UserQueryRepository { get; }
    public IUserCommandRepository UserCommandRepository { get; }
    public async Task CompleteAsync()
    {
        await _context.SaveChangesAsync();
    }
}