using System.Linq.Expressions;
using Microsoft.EntityFrameworkCore;
using VideoHub.Common.Data;
using VideoHub.Common.Entities;

namespace VideoHub.Common.BaseRepository.BaseQueryGenericRepository;

public class QueryGenericRepository<TQuery>(BaseDbContext context)
    : IQueryGenericRepository<TQuery> where TQuery : BaseEntity
{
    public async Task<TQuery?> GetByIdAsync(int id)
    {
        return await context.Set<TQuery>().Where(x=>!x.IsDeleted).FirstOrDefaultAsync(x=>x.Id==id);
    }

    public async Task<IEnumerable<TQuery>> GetAllAsync()
    {
        return await context.Set<TQuery>().Where(x=>!x.IsDeleted).ToListAsync();
    }

    public async Task<IEnumerable<TQuery>> FindAsync(Expression<Func<TQuery, bool>> expression)
    {
        return await context.Set<TQuery>().Where(expression).Where(x=>!x.IsDeleted).ToListAsync();
    }
}