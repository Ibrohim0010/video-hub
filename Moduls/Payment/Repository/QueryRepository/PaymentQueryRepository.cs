using VideoHub.Common.BaseRepository.BaseQueryGenericRepository;
using VideoHub.Common.Data;

namespace VideoHub.Moduls.Payment.Repository.QueryRepository;

public class PaymentQueryRepository(AppQueryDbContext context)
    :QueryGenericRepository<Payment>(context),IPaymentQueryRepository;