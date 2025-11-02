using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.DependencyInjection;
using RandomUserService.Core.Interfaces;
using RandomUserService.Infrastructure.Data;
using RandomUserService.Infrastructure.External;

namespace RandomUserService.Infrastructure;

public static class Extensions
{
    public static IServiceCollection AddInfrastructure(this IServiceCollection services, string? connectionString)
    {
        services.AddDbContext<AppDbContext>(options => options.UseSqlite(connectionString));
        services.AddScoped<IUserRepository, UserRepository>();
        services.AddHttpClient<IRandomUserApiClient, RandomUserApiClient>();

        return services;
    }
}