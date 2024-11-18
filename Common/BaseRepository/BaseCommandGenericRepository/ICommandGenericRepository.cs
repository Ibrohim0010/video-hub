using System.Linq.Expressions;
using VideoHub.Common.Entities;

namespace VideoHub.Common.BaseRepository.BaseCommandGenericRepository;

public interface ICommandGenericRepository<TCommand> where TCommand : BaseEntity
{
    Task<int> AddAsync(TCommand command);
    Task<int> UpdateAsync(TCommand command);
    Task<int> RemoveAsync(TCommand command);
    Task<IEnumerable<TCommand>> FindAsync(Expression<Func<TCommand, bool>> expression);
}