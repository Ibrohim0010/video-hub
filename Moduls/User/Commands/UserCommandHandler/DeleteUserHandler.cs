using MediatR;
using VideoHub.Common.Result;
using VideoHub.Moduls.User.Repository.CommandRepository;


namespace VideoHub.Moduls.User.Commands.UserCommandHandler;

public class DeleteUserHandler(IUserCommandRepository userCommandRepository)
    :IRequestHandler<DeleteUserRequest,BaseResult>
{
    public async Task<BaseResult> Handle(DeleteUserRequest request, CancellationToken cancellationToken)
    {
        IEnumerable<User?> existingUsers = await userCommandRepository.FindAsync(x =>
            x.Id == request.Id);    
        User? existing = existingUsers.FirstOrDefault();
        if (existing is null) return BaseResult.Failure(Error.None());;

        int res = await userCommandRepository.UpdateAsync(existing.ToDeletedUser());

        return res is 0
            ? BaseResult.Failure(Error.InternalServerError("User not deleted !!!"))
            : BaseResult.Success();
    }
}