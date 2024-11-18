using VideoHub.Common.BaseRepository.BaseCommandGenericRepository;
using VideoHub.Common.Data;

namespace VideoHub.Moduls.Payment.Repository.CommandRepository;

public class PaymentCommandRepository(AppCommandDbContext context)
    :CommandGenericRepository<VideoHub.Moduls.Payment.Payment>(context),IPaymentCommandRepository;