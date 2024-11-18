using VideoHub.Common.BaseRepository.BaseQueryGenericRepository;
using VideoHub.Common.Data;

namespace VideoHub.Moduls.Video.Repository.QueryRepository;

public class VideoQueryRepository(AppQueryDbContext context)
    :QueryGenericRepository<Video>(context),IVideoQueryRepository;