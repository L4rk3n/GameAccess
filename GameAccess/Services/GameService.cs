using GameAccess.Models;
using Microsoft.JSInterop;
using System.Net.Http.Headers;
using System.Net.Http.Json;

namespace GameAccess.Services 
{
    public class GameService : IGameService
    {
        private readonly HttpClient _httpClient;
        private readonly IJSRuntime JS;

        public GameService(HttpClient client, IJSRuntime js)
        {
            _httpClient = client;
            JS = js;
        }

        public async Task<Game?> Get(int id)
        {

            string token = await JS.InvokeAsync<string>("localStorage.getItem", "token");

            _httpClient.DefaultRequestHeaders.Authorization = new AuthenticationHeaderValue("Bearer", token);

            return await _httpClient.GetFromJsonAsync<Game>($"Game/{id}");

        }

        public async Task<IEnumerable<Game>?> GetAll()
        {

            string token = await JS.InvokeAsync<string>("localStorage.getItem", "token");

            _httpClient.DefaultRequestHeaders.Authorization = new AuthenticationHeaderValue("Bearer", token);

            return await _httpClient.GetFromJsonAsync<IEnumerable<Game>>($"Game/all");
            
        }

        public async Task Set(Game game)
        {

            string token = await JS.InvokeAsync<string>("localStorage.getItem", "token");

            _httpClient.DefaultRequestHeaders.Authorization = new AuthenticationHeaderValue("Bearer", token);

            _httpClient.PostAsJsonAsync($"Game/ajout",game);

        }

        public async Task Update(UpdateGame game,int id )
        {

            string token = await JS.InvokeAsync<string>("localStorage.getItem", "token");

            _httpClient.DefaultRequestHeaders.Authorization = new AuthenticationHeaderValue("Bearer", token);

            await _httpClient.PutAsJsonAsync($"Game/Update/{id}", game);

        }

        public async Task Delete( int id)
        {

            string token = await JS.InvokeAsync<string>("localStorage.getItem", "token");

            _httpClient.DefaultRequestHeaders.Authorization = new AuthenticationHeaderValue("Bearer", token);

            _httpClient.DeleteAsync($"Game/Delete/{id}");

        }


    }
}
