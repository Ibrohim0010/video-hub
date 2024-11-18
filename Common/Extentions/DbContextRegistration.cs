using System.Reflection;
using Microsoft.EntityFrameworkCore;
using VideoHub.Common.Data;

namespace VideoHub.Common.Extentions;

public static class DbContextRegistration
{
    public static WebApplicationBuilder AddDbContext(this WebApplicationBuilder builder)
    {

        builder.Services.AddDbContext<BaseDbContext>(x =>
            x.UseNpgsql(builder.Configuration.GetConnectionString("Default"))
                .LogTo(Console.WriteLine));

        builder.Services.AddDbContext<AppCommandDbContext>(x =>
            x.UseNpgsql(builder.Configuration.GetConnectionString("Default"))
                .LogTo(Console.WriteLine));

        builder.Services.AddDbContext<AppQueryDbContext>(x =>
        {
            x.UseNpgsql(builder.Configuration.GetConnectionString("Default"))
                .UseQueryTrackingBehavior(QueryTrackingBehavior.TrackAll)
                .LogTo(Console.WriteLine);
        });
        return builder;
    }
}