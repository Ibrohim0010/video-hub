using Microsoft.EntityFrameworkCore;
using VideoHub.Common.Extentions;
using VideoHub.Moduls.Payment;
using VideoHub.Moduls.User;
using VideoHub.Moduls.Video;

namespace VideoHub.Common.Data;

public class BaseDbContext:DbContext
{
    public DbSet<User> Users { get; set; }
    public DbSet<Payment> Payments { get; set; }
    public DbSet<Video> Videos { get; set; }
    
    public BaseDbContext(DbContextOptions<BaseDbContext> options) : base(options)
    {
    }
    protected override void OnModelCreating(ModelBuilder modelBuilder)
    {
        modelBuilder.ApplyConfigurationsFromAssembly(typeof(Program).Assembly);
        modelBuilder.FilterSoftDeletedProperties();
        base.OnModelCreating(modelBuilder);
    }
}