using RandomUserService.Core.Entities;

namespace RandomUserService.Api.DTO.Mappings
{
    internal static class UserDtoMappings
    {
        public static UserDto ToDto(this User user)
        {
            return new UserDto
            {
                Id = user.Id,
                Title = user.Title,
                FirstName = user.FirstName,
                LastName = user.LastName,
                Gender = user.Gender,
                Email = user.Email,
                ExternalId = user.ExternalId,
                Timestamp = user.Timestamp
            };
        }
    }
}
