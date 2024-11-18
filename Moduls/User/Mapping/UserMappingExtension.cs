using VideoHub.Moduls.User.Commands;
using VideoHub.Moduls.User.Queries;

namespace VideoHub.Moduls.User;


public static class UserMappingExtension
{
    public static GetUserViewModel ToReadInfo(this User user)
    {
        return new()
        {
            Id = user.Id,
            UserBaseInfo = new()
            {
                FullName = user.FullName,
                Age = user.Age,
                Email = user.Email
            }
        };
    }
    
    public static GetUserDetailViewModel ToReadDetailInfo(this User user)
    {
        return new()
        {
            Id = user.Id,
            UserBaseInfo = new()
            {
                FullName = user.FullName,
                Age = user.Age,
                Email = user.Email
            }
        };
    }

    public static User ToUser(this CreateUserRequest request)
    {
        return new()
        {
            FullName = request.UserBaseInfo.FullName,
            Age = request.UserBaseInfo.Age,
            Email = request.UserBaseInfo.Email
        };
    }

    public static User ToUpdatedUser(this User user, UpdateUserRequest request)
    {
        user.UpdatedAt = DateTime.UtcNow;
        user.FullName = request.UserBaseInfo.FullName;
        user.Age = request.UserBaseInfo.Age;
        user.Email = request.UserBaseInfo.Email;
        return user;
    }

    public static User ToDeletedUser(this User user)
    {
        user.IsDeleted = true;
        user.DeletedAt = DateTime.UtcNow;
        user.UpdatedAt = DateTime.UtcNow;
        return user;
    }
}