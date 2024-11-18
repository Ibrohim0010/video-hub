using MediatR;
using VideoHub.Common.Responses;
using VideoHub.Common.Result;

namespace VideoHub.Moduls.Video.Queries;

public readonly record struct GetVideoViewModel(
    int Id,
    VideoBaseInfo VideoBaseInfo);

public record GetVideoViewModelRequest(VideoFilter? Filter) : IRequest<Result<PagedResponse<IEnumerable<GetVideoViewModel>>>>;

public readonly record struct GetVideoDetailViewModel(
    int Id,
    VideoBaseInfo VideoBaseInfo);
    
public record GetVideoDetailViewModelRequest(int Id) : IRequest<Result<GetVideoDetailViewModel>>;