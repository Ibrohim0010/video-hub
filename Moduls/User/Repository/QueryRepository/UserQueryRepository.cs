using VideoHub.Common.BaseRepository.BaseQueryGenericRepository;
using VideoHub.Common.Data;

namespace VideoHub.Moduls.User.Repository.QueryRepository;

public class UserQueryRepository(BaseDbContext context)
    :QueryGenericRepository<User>(context),IUserQueryRepository;