using System.Collections.Generic;
using System.Net.Http;
using System.Text.Json;
using System.Threading.Tasks;
using RazorWebApplication.Models;

namespace RazorWebApplication.Services
{
    public class AdvertsService : IAdvertsService
    {
        private HttpClient HttpClient { get; }
        
        public AdvertsService(HttpClient httpClient)
        {
            HttpClient = httpClient;
        }

        public async Task<IEnumerable<Adverts>> GetAdverts()
        {
            using var response = await this.HttpClient.GetAsync("adverts");

            response.EnsureSuccessStatusCode();
            
            var content = await response.Content.ReadAsStringAsync();
            
            return JsonSerializer.Deserialize<IEnumerable<Adverts>>(content, new JsonSerializerOptions { PropertyNameCaseInsensitive = true });
        }
    }
}