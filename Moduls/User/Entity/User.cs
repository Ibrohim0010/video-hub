using VideoHub.Common.Entities;

namespace VideoHub.Moduls.User;

public class User:BaseEntity
{
    public string FullName { get; set; } = null!;
    public int Age { get; set; }
    public string Email { get; set; } = null!;
    public ICollection<VideoHub.Moduls.Payment.Payment> Payments { get; set; } = [];
}