using Microsoft.EntityFrameworkCore;

namespace VideoHub.Common.Data;

public sealed class AppQueryDbContext(DbContextOptions<BaseDbContext> options) : BaseDbContext(options);