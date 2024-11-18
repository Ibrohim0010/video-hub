using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace VideoHub.Moduls.Video;

public class VideoConfiguration : IEntityTypeConfiguration<VideoHub.Moduls.Video.Video>
{
    public void Configure(EntityTypeBuilder<VideoHub.Moduls.Video.Video> builder)
    {
        builder.HasAlternateKey(x => x.Title);
    }
}