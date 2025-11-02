using RandomUserService.Core.Entities;
using RandomUserService.Core.Interfaces;
using System.Net.Http.Json;
using RandomUserService.Infrastructure.External.Models;

namespace RandomUserService.Infrastructure.External
{
    internal class RandomUserApiClient : IRandomUserApiClient
    {
        private const string Url = "https://randomuser.me/api/";
        private readonly HttpClient _httpClient;

        public RandomUserApiClient(HttpClient httpClient)
        {
            _httpClient = httpClient;
        }

        public async Task<User> GetRandomUserAsync()
        {
            var response = await _httpClient.GetFromJsonAsync<RandomUserResponse>(Url);
            var apiUser = response?.Results?.FirstOrDefault();
            if (apiUser == null)
            {
                throw new Exception("No user returned");
            }

            return new User
            {
                Title = apiUser.Name.Title,
                FirstName = apiUser.Name.First,
                LastName = apiUser.Name.Last,
                Gender = apiUser.Gender,
                Email = apiUser.Email,
                ExternalId = apiUser.Login.Uuid,
                Timestamp = DateTime.UtcNow
            };
        }
    }
}