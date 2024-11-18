using MediatR;
using VideoHub.Common.Responses;
using VideoHub.Common.Result;

namespace VideoHub.Moduls.User.Queries;

public readonly record struct GetUserViewModel(
    int Id,
    UserBaseInfo UserBaseInfo);

public record GetUserViewModelRequest(UserFilter? Filter) : IRequest<Result<PagedResponse<IEnumerable<GetUserViewModel>>>>;

public readonly record struct GetUserDetailViewModel(
    int Id,
    UserBaseInfo UserBaseInfo);
    
public record GetUserDetailViewModelRequest(int Id) : IRequest<Result<GetUserDetailViewModel>>;