using MediatR;
using VideoHub.Common.Result;
using VideoHub.Moduls.Payment.Repository.CommandRepository;

namespace VideoHub.Moduls.Payment.Commands.PaymentCommandHandler;

public class DeletePaymentHandler(IPaymentCommandRepository paymentCommandRepository)
    :IRequestHandler<DeletePaymentRequest,BaseResult>
{
    public async Task<BaseResult> Handle(DeletePaymentRequest request, CancellationToken cancellationToken)
    {
        IEnumerable<Payment?> existingPayments = await paymentCommandRepository.FindAsync(x =>
            x.Id == request.Id);    
        Payment? existing = existingPayments.FirstOrDefault();
        if (existing is null) return BaseResult.Failure(Error.None());;

        int res = await paymentCommandRepository.UpdateAsync(existing.ToDeletedPayment());

        return res is 0
            ? BaseResult.Failure(Error.InternalServerError("Payment not deleted !!!"))
            : BaseResult.Success();
    }
}