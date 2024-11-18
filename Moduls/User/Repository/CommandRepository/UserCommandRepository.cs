using VideoHub.Common.BaseRepository.BaseCommandGenericRepository;
using VideoHub.Common.Data;

namespace VideoHub.Moduls.User.Repository.CommandRepository;

public class UserCommandRepository(BaseDbContext context)
    :CommandGenericRepository<User>(context),IUserCommandRepository;