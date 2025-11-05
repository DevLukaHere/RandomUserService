using RandomUserService.Core.Entities;

namespace RandomUserService.Core.Services
{
    public interface IUserService
    {
        Task<IEnumerable<User>> GetAllUsersAsync();
        Task<User?> GetUserByIdAsync(int id);
        Task<User> FetchAndSaveUserAsync();
    }
}
