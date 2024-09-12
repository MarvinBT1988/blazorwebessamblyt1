using System.Net.Http.Json;

namespace BlazorApp8.Data
{
    public class RickAndMortyService
    {
        private readonly HttpClient _httpClient;

        public RickAndMortyService(IHttpClientFactory httpClientFactory)
        {
            _httpClient = httpClientFactory.CreateClient("RickAndMortyApi");
        }

        public async Task<List<Character>> GetCharactersAsync()
        {
            var response = await _httpClient.GetAsync("character");
            response.EnsureSuccessStatusCode();
            var data = await response.Content.ReadFromJsonAsync<CharacterResponse>();
            return data.Results;
        }
    }
    public class CharacterResponse
    {
        public List<Character> Results { get; set; }
    }

    public class Character
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public string Status { get; set; }
        public string Image { get; set; }
        public DateTime Air_date { get; set; }
        // Otras propiedades según sea necesario
    }
}
