using Microsoft.Extensions.Options;
using RandomUserService.Api.Background;
using RandomUserService.Core.Interfaces;

namespace RandomUserService.Api
{
    public static class DependencyInjection
    {
        public static IServiceCollection AddApi(this IServiceCollection services, IConfiguration configuration)
        {
            services.Configure<SchedulerSettings>(configuration.GetSection("Scheduler"));
            services.AddHttpClient();
            services.AddSingleton<IScheduler>(sp =>
            {
                var settings = sp.GetRequiredService<IOptions<SchedulerSettings>>().Value;
                var scopeFactory = sp.GetRequiredService<IServiceScopeFactory>();

                return new Scheduler(settings, scopeFactory);
            });

            return services;
        }
    }
}