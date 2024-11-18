using MediatR;
using Microsoft.EntityFrameworkCore;
using VideoHub.Common.Data;
using VideoHub.Common.Responses;
using VideoHub.Common.Result;

namespace VideoHub.Moduls.User.Queries.UserQueryHandler;

public class GetUsersHandler(AppQueryDbContext context) : IRequestHandler<GetUserViewModelRequest, Result<PagedResponse<IEnumerable<GetUserViewModel>>>>
{
    public async Task<Result<PagedResponse<IEnumerable<GetUserViewModel>>>> Handle(GetUserViewModelRequest request, CancellationToken cancellationToken)
    {
        IQueryable<User> users = context.Users;

        if (request.Filter!.FullName != null)
            users = users.Where(x => x.FullName.ToLower()
                .Contains(request.Filter.FullName.ToLower()));
        if (request.Filter!.Age != null)
            users = users.Where(x => x.Age==request.Filter.Age);
        if (request.Filter!.Email != null)
            users = users.Where(x => x.Email.ToLower()
                .Contains(request.Filter.Email.ToLower()));

        int count = await users.CountAsync(cancellationToken);

        IQueryable<GetUserViewModel> result = users
            .Skip((request.Filter.PageNumber - 1) * request.Filter.PageSize)
            .Take(request.Filter.PageSize).Select(x => x.ToReadInfo());


        PagedResponse<IEnumerable<GetUserViewModel>> response = PagedResponse<IEnumerable<GetUserViewModel>>
            .Create(request.Filter.PageNumber, request.Filter.PageSize, count, result);

        return Result<PagedResponse<IEnumerable<GetUserViewModel>>>.Success(response);
    }
}