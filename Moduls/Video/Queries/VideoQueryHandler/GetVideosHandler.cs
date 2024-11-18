using MediatR;
using Microsoft.EntityFrameworkCore;
using VideoHub.Common.Data;
using VideoHub.Common.Responses;
using VideoHub.Common.Result;

namespace VideoHub.Moduls.Video.Queries.VideoQueryHandler;

public class GetVideosHandler(AppQueryDbContext context) : IRequestHandler<GetVideoViewModelRequest, Result<PagedResponse<IEnumerable<GetVideoViewModel>>>>
{
    public async Task<Result<PagedResponse<IEnumerable<GetVideoViewModel>>>> Handle(GetVideoViewModelRequest request, CancellationToken cancellationToken)
    {
        IQueryable<VideoHub.Moduls.Video.Video> videos = context.Videos;

        if (request.Filter!.Title != null)
            videos = videos.Where(x => x.Title.ToLower()
                .Contains(request.Filter.Title.ToLower()));
        if (request.Filter!.IsPaid != null)
            videos = videos.Where(x => x.IsPaid==request.Filter.IsPaid);
        if (request.Filter!.Description != null)
            videos = videos.Where(x => x.Description.ToLower()
                .Contains(request.Filter.Description.ToLower()));

        int count = await videos.CountAsync(cancellationToken);

        IQueryable<GetVideoViewModel> result = videos
            .Skip((request.Filter.PageNumber - 1) * request.Filter.PageSize)
            .Take(request.Filter.PageSize).Select(x => x.ToReadInfo());


        PagedResponse<IEnumerable<GetVideoViewModel>> response = PagedResponse<IEnumerable<GetVideoViewModel>>
            .Create(request.Filter.PageNumber, request.Filter.PageSize, count, result);

        return Result<PagedResponse<IEnumerable<GetVideoViewModel>>>.Success(response);
    }
}