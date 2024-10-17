using GameAccess.Pages.Auth;
using GameAccess.Services;
using Microsoft.AspNetCore.Components.Authorization;
using Microsoft.AspNetCore.Components.Web;
using Microsoft.AspNetCore.Components.WebAssembly.Hosting;

namespace GameAccess
{
    public class Program
    {
        public static async Task Main(string[] args)
        {
            var builder = WebAssemblyHostBuilder.CreateDefault(args);
            builder.RootComponents.Add<App>("#app");
            builder.RootComponents.Add<HeadOutlet>("head::after");

            builder.Services.AddScoped(sp => new HttpClient { BaseAddress = new Uri("https://localhost:7050/api/") });
            builder.Services.AddScoped < AuthenticationStateProvider, MyStateProvider>();
            builder.Services.AddScoped<IGameService, GameService>();

            await builder.Build().RunAsync();
        }
    }
}
