using MediatR;
using VideoHub.Common.Result;

namespace VideoHub.Moduls.User.Commands;

public readonly record struct CreateUserRequest(
    UserBaseInfo UserBaseInfo):IRequest<BaseResult>;
    
public readonly record struct UpdateUserRequest(
    int Id,
    UserBaseInfo UserBaseInfo):IRequest<BaseResult>;    
  
public readonly record struct DeleteUserRequest(int Id):IRequest<BaseResult>;