using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace VideoHub.Moduls.User;

public class UserConfiguration : IEntityTypeConfiguration<VideoHub.Moduls.User.User>
{
    public void Configure(EntityTypeBuilder<VideoHub.Moduls.User.User> builder)
    {
        builder.HasAlternateKey(x => x.Email);
    }
}