using VideoHub.Common.BaseRepository.BaseCommandGenericRepository;
using VideoHub.Common.Data;

namespace VideoHub.Moduls.Video.Repository.CommandRepository;

public class VideoCommandRepository(AppCommandDbContext context)
    :CommandGenericRepository<Video>(context),IVideoCommandRepository;