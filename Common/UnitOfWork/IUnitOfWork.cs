using VideoHub.Moduls.User.Repository.CommandRepository;
using VideoHub.Moduls.User.Repository.QueryRepository;

namespace VideoHub.Common.UnitOfWork;

public interface IUnitOfWork
{
    IUserQueryRepository UserQueryRepository { get; }
    IUserCommandRepository UserCommandRepository { get; }
}