using MediatR;
using VideoHub.Common.Result;
using VideoHub.Moduls.Video.FileService;
using VideoHub.Moduls.Video.Repository.CommandRepository;

namespace VideoHub.Moduls.Video.Commands.VideoCommandHandler;

public class CreateVideoHandler(IFileService fileService,IVideoCommandRepository videoCommandRepository):IRequestHandler<CreateVideoRequest,BaseResult>
{
    public async Task<BaseResult> Handle(CreateVideoRequest request, CancellationToken cancellationToken)
    {
        bool existTitle =
            (await videoCommandRepository
                .FindAsync(x => x.Title.ToLower() == request.VideoBaseInfo.Title
                    .ToLower())).Any();
        if (existTitle) 
            return BaseResult.Failure(Error.AlreadyExist());
        int res = await videoCommandRepository.AddAsync(request.ToVideo(fileService));

        return res is 0
            ? BaseResult.Failure(Error.InternalServerError("Video not saved !!!"))
            : BaseResult.Success();
    }
}