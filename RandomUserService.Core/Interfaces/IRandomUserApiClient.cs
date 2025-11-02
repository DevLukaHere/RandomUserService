using RandomUserService.Core.Entities;

namespace RandomUserService.Core.Interfaces
{
    public interface IRandomUserApiClient
    {
        Task<User> GetRandomUserAsync();
    }
}