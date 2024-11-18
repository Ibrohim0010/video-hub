using VideoHub.Common.Filter;

namespace VideoHub.Moduls.Payment;

public record PaymentFilter(
    decimal? Price,
    DateTimeOffset? PaymentDate,
    string? PaymentMethod,
    int? UserId, 
    int? VideoId):BaseFilter;