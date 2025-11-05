using RandomUserService.Core.Entities;
using RandomUserService.Core.Interfaces;
using System.Net.Http.Json;
using RandomUserService.Infrastructure.External.Models;
using RandomUserService.Infrastructure.Mappings;

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
            var randomUser = response?.Results.FirstOrDefault();
            if (randomUser == null)
            {
                throw new Exception("No user returned");
            }

            return randomUser.ToDomain();
        }
    }
}