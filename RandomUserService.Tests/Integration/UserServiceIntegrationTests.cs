using Microsoft.Data.Sqlite;
using Microsoft.EntityFrameworkCore;
using RandomUserService.Core.Interfaces;
using RandomUserService.Core.Services;
using RandomUserService.Infrastructure.Data;

namespace RandomUserService.Tests.Integration
{
    [TestFixture]
    public class UserServiceIntegrationTests
    {
        private SqliteConnection _connection = null!;
        private DbContextOptions<AppDbContext> _dbOptions = null!;
        private AppDbContext _context = null!;
        private IUserRepository _repository = null!;
        private IRandomUserApiClient _apiClient = null!;
        private UserService _service = null!;

        [SetUp]
        public void Setup()
        {
            _connection = new SqliteConnection("Filename=:memory:");
            _connection.Open();

            _dbOptions = new DbContextOptionsBuilder<AppDbContext>()
                .UseSqlite(_connection)
                .Options;

            _context = new AppDbContext(_dbOptions);
            _context.Database.EnsureCreated();

            _repository = new UserRepository(_context);

            _apiClient = new FakeRandomUserApiClient();

            _service = new UserService(_repository, _apiClient);
        }

        [TearDown]
        public void TearDown()
        {
            _context.Dispose();
            _connection.Dispose();
        }

        [Test]
        public async Task FetchAndSaveUser_ShouldPersistToDatabase()
        {
            var user = await _service.FetchAndSaveUserAsync();
            var saved = await _context.Users.FirstAsync();

            Assert.That(saved.Email, Is.EqualTo(user.Email));
        }
    }
}
