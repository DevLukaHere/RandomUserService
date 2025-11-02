using Microsoft.Extensions.Options;
using RandomUserService.Api.Background;
using RandomUserService.Core.Services;
using RandomUserService.Infrastructure;

var builder = WebApplication.CreateBuilder(args);

builder.Services.AddInfrastructure(builder.Configuration.GetConnectionString("DefaultConnection"));
builder.Services.AddScoped<UserService>();

builder.Services.AddControllers();
builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen();

builder.Services.Configure<SchedulerSettings>(builder.Configuration.GetSection("Scheduler"));

builder.Services.AddSingleton<UserFetchScheduler>(sp =>
{
    var settings = sp.GetRequiredService<IOptions<SchedulerSettings>>().Value;
    return new UserFetchScheduler(sp, settings);
});

var app = builder.Build();
if (app.Environment.IsDevelopment())
{
    app.UseSwagger();
    app.UseSwaggerUI();
}

app.UseHttpsRedirection();
app.UseAuthorization();
app.MapControllers();
app.Run();