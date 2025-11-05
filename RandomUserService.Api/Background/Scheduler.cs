using RandomUserService.Core.Interfaces;
using RandomUserService.Core.Services;

namespace RandomUserService.Api.Background
{
    internal class Scheduler : IScheduler
    {
        private readonly IServiceScopeFactory _scopeFactory;
        private readonly int _intervalSeconds;
        private Timer? _timer;
        private bool _isRunning;

        public Scheduler(SchedulerSettings settings, IServiceScopeFactory scopeFactory)
        {
            _scopeFactory = scopeFactory;
            _intervalSeconds = settings.IntervalSeconds;
        }

        public string Status => _isRunning ? "Running" : "Paused";

        public void Start()
        {
            if (_isRunning)
            {
                return;
            }

            _timer = new Timer(async _ => await FetchUserAsync(), null, 0, _intervalSeconds * 1000);
            _isRunning = true;
        }

        public void Pause()
        {
            _timer?.Change(Timeout.Infinite, Timeout.Infinite);
            _isRunning = false;
        }

        public void Resume()
        {
            if (_isRunning)
            {
                return;
            }

            _timer?.Change(0, _intervalSeconds * 1000);
            _isRunning = true;
        }

        private async Task FetchUserAsync()
        {
            try
            {
                using var scope = _scopeFactory.CreateScope();
                var userService = scope.ServiceProvider.GetRequiredService<IUserService>();
                await userService.FetchAndSaveUserAsync();
            }
            catch (Exception ex)
            {
                Console.WriteLine($"Error fetching user: {ex.Message}");
            }
        }
    }
}
