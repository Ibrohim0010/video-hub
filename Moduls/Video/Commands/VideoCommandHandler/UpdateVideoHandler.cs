using MediatR;
using VideoHub.Common.Result;
using VideoHub.Moduls.Video.Constants;
using VideoHub.Moduls.Video.FileService;
using VideoHub.Moduls.Video.Repository.CommandRepository;

namespace VideoHub.Moduls.Video.Commands.VideoCommandHandler;

public class UpdateVideoHandler(IFileService fileService,IVideoCommandRepository videoCommandRepository):IRequestHandler<UpdateVideoRequest,BaseResult>
{
    public async Task<BaseResult> Handle(UpdateVideoRequest request, CancellationToken cancellationToken)
    {
        bool isExistFile = request.VideoBaseInfo.File != null;
        
        IEnumerable<Video?> existingVideos = await videoCommandRepository.FindAsync(x=>
            x.Id==request.Id);
        Video video = existingVideos.FirstOrDefault()!;
        if (video is null) return BaseResult.Failure(Error.None());

        if (isExistFile)
        {
            fileService.DeleteFile(video.Title, MediaFolders.Videos);

            video.Title = fileService.CreateFile(request.VideoBaseInfo.File!, MediaFolders.Videos);
        }

        int res = await videoCommandRepository.UpdateAsync(video.ToUpdatedVideo(request,fileService));

        return res is 0
            ? BaseResult.Failure(Error.InternalServerError("Video not updated !!!"))
            : BaseResult.Success();
    }
}