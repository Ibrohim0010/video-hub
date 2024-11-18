using MediatR;
using VideoHub.Common.Result;
using VideoHub.Moduls.User.Repository.CommandRepository;

namespace VideoHub.Moduls.User.Commands.UserCommandHandler;

public class UpdateUserHandler(IUserCommandRepository userCommandRepository):IRequestHandler<UpdateUserRequest,BaseResult>
{
    public async Task<BaseResult> Handle(UpdateUserRequest request, CancellationToken cancellationToken)
    {
        IEnumerable<User?> existingUsers = await userCommandRepository.FindAsync(x=>
            x.Id==request.Id);
        User user = existingUsers.FirstOrDefault()!;
        if (user is null) return BaseResult.Failure(Error.None());

        int res = await userCommandRepository.UpdateAsync(user.ToUpdatedUser(request));

        return res is 0
            ? BaseResult.Failure(Error.InternalServerError("User not updated !!!"))
            : BaseResult.Success();
    }
}