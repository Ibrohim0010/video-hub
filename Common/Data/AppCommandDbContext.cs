using Microsoft.EntityFrameworkCore;

namespace VideoHub.Common.Data;

public sealed class AppCommandDbContext(DbContextOptions<BaseDbContext> options) : BaseDbContext(options);