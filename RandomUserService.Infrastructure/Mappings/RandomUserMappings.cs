using RandomUserService.Core.Entities;
using RandomUserService.Infrastructure.External.Models;

namespace RandomUserService.Infrastructure.Mappings
{
    internal static class RandomUserMappings
    {
        public static User ToDomain(this RandomUser result)
        {
            return new User
            {
                Title = result.Name.Title,
                FirstName = result.Name.First,
                LastName = result.Name.Last,
                Gender = result.Gender,
                Email = result.Email,
                ExternalId = result.Login.Uuid,
                Timestamp = DateTime.UtcNow
            };
        }
    }
}
