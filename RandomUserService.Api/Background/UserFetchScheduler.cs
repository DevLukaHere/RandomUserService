using RandomUserService.Core.Services;

namespace RandomUserService.Api.Background
{
    public class UserFetchScheduler
    {
        private readonly IServiceProvider _serviceProvider;
        private readonly int _intervalSeconds;
        private Timer? _timer;
        private bool _isRunning;

        public UserFetchScheduler(IServiceProvider serviceProvider, SchedulerSettings settings)
        {
            _serviceProvider = serviceProvider;
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
                using var scope = _serviceProvider.CreateScope();
                var userService = scope.ServiceProvider.GetRequiredService<UserService>();
                await userService.FetchAndSaveUserAsync();
            }
            catch (Exception ex)
            {
                Console.WriteLine($"Error fetching user: {ex.Message}");
            }
        }
    }
}
