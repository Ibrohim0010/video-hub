using Microsoft.EntityFrameworkCore;
using VideoHub.Common.Data;
using VideoHub.Common.Result;

namespace VideoHub.Moduls.Payment.Queries.PaymentQueryHandler;

public class GetPaymentDetailHandler(AppQueryDbContext context)
{
    public async Task<Result<GetPaymentDetailViewModel>> Handle(GetPaymentDetailViewModelRequest request, CancellationToken cancellationToken)
    {
        Payment? result = await context.Payments.FirstOrDefaultAsync(x => x.Id == request.Id, cancellationToken);

        return result is null
            ? Result<GetPaymentDetailViewModel>.Failure(Error.NotFound())
            : Result<GetPaymentDetailViewModel>.Success(result.ToReadDetailInfo());
    }
}