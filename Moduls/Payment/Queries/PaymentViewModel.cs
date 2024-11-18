using MediatR;
using VideoHub.Common.Responses;
using VideoHub.Common.Result;

namespace VideoHub.Moduls.Payment.Queries;

public readonly record struct GetPaymentViewModel(
    int Id,
    PaymentBaseInfo PaymentBaseInfo);

public record GetPaymentViewModelRequest(PaymentFilter? Filter) : IRequest<Result<PagedResponse<IEnumerable<GetPaymentViewModel>>>>;

public readonly record struct GetPaymentDetailViewModel(
    int Id,
    PaymentBaseInfo PaymentBaseInfo);
    
public record GetPaymentDetailViewModelRequest(int Id) : IRequest<Result<GetPaymentDetailViewModel>>;