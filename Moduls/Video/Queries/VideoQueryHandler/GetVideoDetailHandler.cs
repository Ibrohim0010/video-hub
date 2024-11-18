using MediatR;
using Microsoft.EntityFrameworkCore;
using VideoHub.Common.Data;
using VideoHub.Common.Result;

namespace VideoHub.Moduls.Video.Queries.VideoQueryHandler;

public class GetVideoDetailHandler(AppQueryDbContext context)
    : IRequestHandler<GetVideoDetailViewModelRequest, Result<GetVideoDetailViewModel>>
{
    public async Task<Result<GetVideoDetailViewModel>> Handle(GetVideoDetailViewModelRequest request, CancellationToken cancellationToken)
    {
        Video? result = await context.Videos.FirstOrDefaultAsync(x => x.Id == request.Id, cancellationToken);

        return result is null
            ? Result<GetVideoDetailViewModel>.Failure(Error.NotFound())
            : Result<GetVideoDetailViewModel>.Success(result.ToReadDetailInfo());
    }
}