using VideoHub.Moduls.Video.Commands;
using VideoHub.Moduls.Video.Constants;
using VideoHub.Moduls.Video.FileService;
using VideoHub.Moduls.Video.Queries;

namespace VideoHub.Moduls.Video;

public static class VideoMappingExtension
{
    public static GetVideoViewModel ToReadInfo(this VideoHub.Moduls.Video.Video video)
    {
        return new()
        {
            Id = video.Id,
            VideoBaseInfo = new()
            {
                Title = video.Title,
                IsPaid = video.IsPaid,
                Description = video.Description
            }
        };
    }
    
    public static GetVideoDetailViewModel ToReadDetailInfo(this VideoHub.Moduls.Video.Video video)
    {
        return new()
        {
            Id = video.Id,
            VideoBaseInfo = new()
            {
                Title = video.Title,
                IsPaid = video.IsPaid,
                Description = video.Description
            }
        };
    }

    public static VideoHub.Moduls.Video.Video ToVideo(this CreateVideoRequest request,IFileService fileService)
    {
        return new()
        {
            Title = fileService.CreateFile(request.VideoBaseInfo.File!,MediaFolders.Videos),
            IsPaid = request.VideoBaseInfo.IsPaid,
            Description = request.VideoBaseInfo.Description
        };
    }

    public static VideoHub.Moduls.Video.Video ToUpdatedVideo(this VideoHub.Moduls.Video.Video video, UpdateVideoRequest request,IFileService fileService)
    {
       
        video.UpdatedAt = DateTime.UtcNow;
        video.Title = fileService.CreateFile(request.VideoBaseInfo.File!, MediaFolders.Videos);
        video.IsPaid = request.VideoBaseInfo.IsPaid;
        video.Description = request.VideoBaseInfo.Description;
        return video;
    }

    public static VideoHub.Moduls.Video.Video ToDeletedVideo(this VideoHub.Moduls.Video.Video video)
    {
        video.IsDeleted = true;
        video.DeletedAt = DateTime.UtcNow;
        video.UpdatedAt = DateTime.UtcNow;
        return video;
    }
}