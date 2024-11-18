using VideoHub.Common.Entities;

namespace VideoHub.Moduls.Payment;

public class Payment:BaseEntity
{
    public decimal Price { get; set; } 
    public DateTimeOffset PaymentDate { get; set; } 
    public string PaymentMethod { get; set; } = null!;
    public int UserId { get; set; } 
    public int VideoId { get; set; } 
    
    public User.User User { get; set; } = null!;
    public Video.Video Video { get; set; } = null!;
}