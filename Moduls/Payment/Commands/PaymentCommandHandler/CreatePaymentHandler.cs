using MediatR;
using VideoHub.Common.Result;
using VideoHub.Moduls.Payment.Repository.CommandRepository;

namespace VideoHub.Moduls.Payment.Commands.PaymentCommandHandler;

public class CreatePaymentHandler(IPaymentCommandRepository paymentCommandRepository):IRequestHandler<CreatePaymentRequest,BaseResult>
{
    public async Task<BaseResult> Handle(CreatePaymentRequest request, CancellationToken cancellationToken)
    {
        if (request==null)
            return BaseResult.Failure(Error.None());
        int res = await paymentCommandRepository.AddAsync(request.ToPayment());

        return res is 0
            ? BaseResult.Failure(Error.InternalServerError("Payment not saved !!!"))
            : BaseResult.Success();
    }
}