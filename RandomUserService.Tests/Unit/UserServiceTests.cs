using Moq;
using RandomUserService.Core.Entities;
using RandomUserService.Core.Interfaces;
using RandomUserService.Core.Services;

namespace RandomUserService.Tests.Unit
{
    [TestFixture]
    public class UserServiceTests
    {
        private Mock<IUserRepository> _userRepositoryMock = null!;
        private Mock<IRandomUserApiClient> _apiClientMock = null!;
        private UserService _userService = null!;

        [SetUp]
        public void SetUp()
        {
            _userRepositoryMock = new Mock<IUserRepository>();
            _apiClientMock = new Mock<IRandomUserApiClient>();
            _userService = new UserService(_userRepositoryMock.Object, _apiClientMock.Object);
        }

        [Test]
        public async Task GetAllUsersAsync_ShouldReturnUsers()
        {
            //Arrange
            var users = new List<User>
            {
                new() { Id = 1, FirstName = "Łukasz", LastName = "Sobieski" }
            };
            _userRepositoryMock.Setup(r => r.GetAllAsync()).ReturnsAsync(users);

            //Act
            var result = await _userService.GetAllUsersAsync();

            //Assert
            Assert.That(result, Is.EqualTo(users));
        }

        [Test]
        public void GetUserByIdAsync_WhenNotFound_ShouldThrowException()
        {
            // Arrange
            _userRepositoryMock.Setup(r => r.GetByIdAsync(13)).ReturnsAsync((User?)null);

            // Act & Assert
            var ex = Assert.ThrowsAsync<Exception>(() => _userService.GetUserByIdAsync(13));

            //Assert
            Assert.That(ex!.Message, Is.EqualTo("User with ID 13 not found"));
        }

        [Test]
        public async Task FetchAndSaveUserAsync_ShouldSaveUserAndReturnIt()
        {
            // Arrange
            var apiUser = new User
            {
                Title = "Mr",
                FirstName = "Łukasz",
                LastName = "Sobieski",
                Email = "Łukasz.Sobieski@example.com",
                Gender = "male",
                ExternalId = "123"
            };
            _apiClientMock.Setup(a => a.GetRandomUserAsync()).ReturnsAsync(apiUser);

            User? savedUser = null;
            _userRepositoryMock.Setup(r => r.AddAsync(It.IsAny<User>()))
                .Callback<User>(u => savedUser = u)
                .Returns(Task.CompletedTask);

            // Act
            var result = await _userService.FetchAndSaveUserAsync();

            // Assert
            Assert.That(result.FirstName, Is.EqualTo("Łukasz"));
            Assert.That(savedUser, Is.Not.Null);
            _userRepositoryMock.Verify(r => r.AddAsync(It.IsAny<User>()), Times.Once);
        }
    }
}
