using System.Reflection;
using VideoHub.Common.BaseRepository.BaseCommandGenericRepository;
using VideoHub.Common.BaseRepository.BaseQueryGenericRepository;
using VideoHub.Common.Extentions;
using VideoHub.Moduls.Payment.Repository.CommandRepository;
using VideoHub.Moduls.Payment.Repository.QueryRepository;
using VideoHub.Moduls.User.Repository.CommandRepository;
using VideoHub.Moduls.User.Repository.QueryRepository;
using VideoHub.Moduls.Video.FileService;
using VideoHub.Moduls.Video.Repository.CommandRepository;
using VideoHub.Moduls.Video.Repository.QueryRepository;

var builder = WebApplication.CreateBuilder(args);

builder.Services.AddControllers();
builder.Services.AddEndpointsApiExplorer();
builder.Services.AddProblemDetails();
builder.Services.AddSwaggerGen();
builder.AddDbContext();
builder.Services.AddMediatR(cfg => 
    cfg.RegisterServicesFromAssembly(Assembly.GetExecutingAssembly()));
builder.Services.AddScoped(typeof(ICommandGenericRepository<>), typeof(CommandGenericRepository<>));
builder.Services.AddScoped<IPaymentCommandRepository, PaymentCommandRepository>();
builder.Services.AddScoped<IUserCommandRepository, UserCommandRepository>();
builder.Services.AddScoped<IVideoCommandRepository, VideoCommandRepository>();
builder.Services.AddScoped(typeof(IQueryGenericRepository<>), typeof(QueryGenericRepository<>));
builder.Services.AddScoped<IPaymentQueryRepository, PaymentQueryRepository>();
builder.Services.AddScoped<IUserQueryRepository, UserQueryRepository>();
builder.Services.AddScoped<IVideoQueryRepository, VideoQueryRepository>();
builder.Services.AddSingleton<IFileService, FileService>();


var app = builder.Build();

app.UseSwagger();
app.UseSwaggerUI();
app.UseStaticFiles();
app.UseDefaultFiles();

app.UseExceptionHandler("/error");
app.MapControllers();

app.Run();