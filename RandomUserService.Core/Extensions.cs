using Microsoft.Extensions.DependencyInjection;
using RandomUserService.Core.Services;

namespace RandomUserService.Core;

public static class Extensions
{
    public static IServiceCollection AddCore(this IServiceCollection services)
    {
        services.AddScoped<IUserService, UserService>();

        return services;
    }
}