using VideoHub.Common.Entities;
using VideoHub.Moduls.Video.Constants;

namespace VideoHub.Moduls.Video;

public class Video:BaseEntity
{
    public string Title { get; set; } = VideoNames.Default;
    public bool IsPaid { get; set; } 
    public string Description { get; set; } = null!;

}