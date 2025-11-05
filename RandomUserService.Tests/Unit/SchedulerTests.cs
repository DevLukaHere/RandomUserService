using Microsoft.Extensions.DependencyInjection;
using Moq;
using RandomUserService.Api.Background;
using RandomUserService.Core.Services;

namespace RandomUserService.Tests.Unit
{
    [TestFixture]
    public class SchedulerTests
    {
        private Mock<IServiceScopeFactory> _scopeFactoryMock = null!;
        private Mock<IServiceScope> _scopeMock = null!;
        private Mock<IServiceProvider> _serviceProviderMock = null!;
        private Mock<IUserService> _userServiceMock = null!;
        private SchedulerSettings _settings = null!;
        private Scheduler _scheduler = null!;

        [SetUp]
        public void Setup()
        {
            _userServiceMock = new Mock<IUserService>();
            _serviceProviderMock = new Mock<IServiceProvider>();
            _scopeMock = new Mock<IServiceScope>();
            _scopeFactoryMock = new Mock<IServiceScopeFactory>();

            _settings = new SchedulerSettings { IntervalSeconds = 1 };

            _scopeFactoryMock
                .Setup(f => f.CreateScope())
                .Returns(_scopeMock.Object);

            _scopeMock
                .SetupGet(s => s.ServiceProvider)
                .Returns(_serviceProviderMock.Object);

            _serviceProviderMock
                .Setup(sp => sp.GetService(typeof(IUserService)))
                .Returns(_userServiceMock.Object);

            _scheduler = new Scheduler(_settings, _scopeFactoryMock.Object);
        }

        [TearDown]
        public void TearDown()
        {
            _scheduler.Pause();
        }

        [Test]
        public void Start_ShouldSetStatusToRunning()
        {
            _scheduler.Start();

            Assert.That(_scheduler.Status, Is.EqualTo("Running"));
        }

        [Test]
        public void Pause_ShouldSetStatusToPaused()
        {
            _scheduler.Start();
            _scheduler.Pause();

            Assert.That(_scheduler.Status, Is.EqualTo("Paused"));
        }

        [Test]
        public void Resume_ShouldSetStatusToRunning()
        {
            _scheduler.Start();
            _scheduler.Pause();
            _scheduler.Resume();

            Assert.That(_scheduler.Status, Is.EqualTo("Running"));
        }

        [Test]
        public async Task Start_ShouldCallUserServicePeriodically()
        {
            _scheduler.Start();

            await Task.Delay(2000);

            _userServiceMock.Verify(s => s.FetchAndSaveUserAsync(), Times.AtLeastOnce);
        }

        [Test]
        public void Start_WhenAlreadyRunning_ShouldNotThrow()
        {
            _scheduler.Start();

            Assert.DoesNotThrow(() => _scheduler.Start());
        }

        [Test]
        public void Resume_WhenAlreadyRunning_ShouldNotThrow()
        {
            _scheduler.Start();

            Assert.DoesNotThrow(() => _scheduler.Resume());
        }
    }
}
