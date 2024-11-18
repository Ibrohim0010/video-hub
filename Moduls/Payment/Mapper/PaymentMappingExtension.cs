using VideoHub.Moduls.Payment.Commands;
using VideoHub.Moduls.Payment.Queries;

namespace VideoHub.Moduls.Payment;

public static class PaymentMappingExtension
{
    public static GetPaymentViewModel ToReadInfo(this VideoHub.Moduls.Payment.Payment payment)
    {
        return new()
        {
            Id = payment.Id,
            PaymentBaseInfo = new()
            {
                Price = payment.Price,
                PaymentDate = payment.PaymentDate,
                PaymentMethod = payment.PaymentMethod,
                UserId = payment.UserId,
                VideoId = payment.VideoId
            }
        };
    }
    
    public static GetPaymentDetailViewModel ToReadDetailInfo(this VideoHub.Moduls.Payment.Payment payment)
    {
        return new()
        {
            Id = payment.Id,
            PaymentBaseInfo = new()
            {
                Price = payment.Price,
                PaymentDate = payment.PaymentDate,
                PaymentMethod = payment.PaymentMethod,
                UserId = payment.UserId,
                VideoId = payment.VideoId
            }
        };
    }

    public static VideoHub.Moduls.Payment.Payment ToPayment(this CreatePaymentRequest request)
    {
        return new()
        {
            Price = request.PaymentBaseInfo.Price,
            PaymentDate = request.PaymentBaseInfo.PaymentDate,
            PaymentMethod = request.PaymentBaseInfo.PaymentMethod,
            UserId = request.PaymentBaseInfo.UserId,
            VideoId = request.PaymentBaseInfo.VideoId
        };
    }

    public static VideoHub.Moduls.Payment.Payment ToUpdatedPayment(this VideoHub.Moduls.Payment.Payment payment, UpdatePaymentRequest request)
    {

        payment.UpdatedAt = DateTime.UtcNow;
        payment.Price = request.PaymentBaseInfo.Price;
        payment.PaymentDate = request.PaymentBaseInfo.PaymentDate;
        payment.PaymentMethod = request.PaymentBaseInfo.PaymentMethod;
        payment.UserId = request.PaymentBaseInfo.UserId;
        payment.VideoId = request.PaymentBaseInfo.VideoId;
        return payment;
    }

    public static VideoHub.Moduls.Payment.Payment ToDeletedPayment(this VideoHub.Moduls.Payment.Payment payment)
    {
        payment.IsDeleted = true;
        payment.DeletedAt = DateTime.UtcNow;
        payment.UpdatedAt = DateTime.UtcNow;
        return payment;
    }
}