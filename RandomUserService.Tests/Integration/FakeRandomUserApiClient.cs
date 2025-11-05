using RandomUserService.Core.Entities;
using RandomUserService.Core.Interfaces;

namespace RandomUserService.Tests.Integration
{
    internal class FakeRandomUserApiClient : IRandomUserApiClient
    {
        public Task<User> GetRandomUserAsync()
        {
            return Task.FromResult(new User
            {
                Title = "Mr",
                FirstName = "Łukasz",
                LastName = "Sobieski",
                Email = "Łukasz.Sobieski@example.com",
                Gender = "male",
                ExternalId = "123"
            });
        }
    }
}