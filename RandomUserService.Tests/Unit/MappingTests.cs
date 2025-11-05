using RandomUserService.Infrastructure.External.Models;
using RandomUserService.Infrastructure.Mappings;

namespace RandomUserService.Tests.Unit
{
    [TestFixture]
    public class RandomUserMappingsTests
    {
        [Test]
        public void ToDomain_ShouldMapAllFieldsCorrectly()
        {
            //Arrange
            var randomUser = new RandomUser
            {
                Gender = "male",
                Email = "Łukasz.Sobieski@example.com",
                Name = new Name
                {
                    Title = "Mr",
                    First = "Łukasz",
                    Last = "Sobieski"
                },
                Login = new Login
                {
                    Uuid = "6251c713-2221-4246-a510-8fc75a749473"
                }
            };

            //Act
            var user = randomUser.ToDomain();

            //Assert
            Assert.Multiple(() =>
            {
                Assert.That(user.Title, Is.EqualTo(randomUser.Name.Title));
                Assert.That(user.FirstName, Is.EqualTo(randomUser.Name.First));
                Assert.That(user.LastName, Is.EqualTo(randomUser.Name.Last));
                Assert.That(user.Gender, Is.EqualTo(randomUser.Gender));
                Assert.That(user.Email, Is.EqualTo(randomUser.Email));
                Assert.That(user.ExternalId, Is.EqualTo(randomUser.Login.Uuid));
            });
        }

        [Test]
        public void ToDomain_ShouldAssignTimestamp()
        {
            //Arrange
            var randomUser = new RandomUser
            {
                Gender = "female",
                Email = "Klaudia.Sobieska@example.com",
                Name = new Name
                {
                    Title = "Ms",
                    First = "Klaudia",
                    Last = "Sobieska"
                },
                Login = new Login
                {
                    Uuid = "f7c42bbf-1c67-49cd-a018-2abf91357a1a"
                }
            };

            //Act
            var user = randomUser.ToDomain();

            //Assert
            Assert.That(user.Timestamp, Is.Not.EqualTo(default(DateTime)));
            Assert.That(user.Timestamp, Is.LessThanOrEqualTo(DateTime.UtcNow));
        }
    }
}
