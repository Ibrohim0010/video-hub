namespace VideoHub.Moduls.Payment;

public readonly record struct PaymentBaseInfo(
    decimal Price,
    DateTimeOffset PaymentDate,
    string PaymentMethod,
    int UserId, 
    int VideoId);