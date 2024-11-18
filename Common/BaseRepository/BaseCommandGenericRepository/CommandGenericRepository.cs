using System.Linq.Expressions;
using Microsoft.EntityFrameworkCore;
using VideoHub.Common.Data;
using VideoHub.Common.Entities;

namespace VideoHub.Common.BaseRepository.BaseCommandGenericRepository;

public class CommandGenericRepository<TCommand>(BaseDbContext context)
    :ICommandGenericRepository<TCommand> where TCommand : BaseEntity
{
    public async Task<int> AddAsync(TCommand command)
    {
        await context.Set<TCommand>().AddAsync(command);
        return await context.SaveChangesAsync();
    }

    public async Task<int> UpdateAsync(TCommand command)
    {
        context.Set<TCommand>().Update(command);
        return await context.SaveChangesAsync();
    }

    public async Task<int> RemoveAsync(TCommand command)
    {
        context.Set<TCommand>().Remove(command);
        return await context.SaveChangesAsync();
    }

    public async Task<IEnumerable<TCommand>> FindAsync(Expression<Func<TCommand, bool>> expression)
    {
        return await context.Set<TCommand>().Where(expression).Where(x=>!x.IsDeleted).ToListAsync();
    }
}