using RandomUserService.Core.Entities;
using RandomUserService.Core.Interfaces;

namespace RandomUserService.Core.Services
{
    internal class UserService : IUserService
    {
        private readonly IUserRepository _userRepository;
        private readonly IRandomUserApiClient _apiClient;

        public UserService(IUserRepository userRepository, IRandomUserApiClient apiClient)
        {
            _userRepository = userRepository;
            _apiClient = apiClient;
        }

        public async Task<IEnumerable<User>> GetAllUsersAsync()
        {
            return await _userRepository.GetAllAsync();
        }

        public async Task<User?> GetUserByIdAsync(int id)
        {
            var user = await _userRepository.GetByIdAsync(id);
            if (user == null)
            {
                throw new Exception($"User with ID {id} not found");
            }

            return user;
        }

        public async Task<User> FetchAndSaveUserAsync()
        {
            var randomUser = await _apiClient.GetRandomUserAsync();
            if (randomUser == null)
            {
                throw new Exception("No user returned from API");
            }

            var user = new User
            {
                Title = randomUser.Title,
                FirstName = randomUser.FirstName,
                LastName = randomUser.LastName,
                Gender = randomUser.Gender,
                Email = randomUser.Email,
                ExternalId = randomUser.ExternalId,
                Timestamp = DateTime.UtcNow
            };

            await _userRepository.AddAsync(user);

            return user;
        }
    }
}
