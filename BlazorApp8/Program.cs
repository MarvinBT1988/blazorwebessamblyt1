using BlazorApp8;
using BlazorApp8.Data;
using Microsoft.AspNetCore.Components.Web;
using Microsoft.AspNetCore.Components.WebAssembly.Hosting;

var builder = WebAssemblyHostBuilder.CreateDefault(args);
builder.RootComponents.Add<App>("#app");
builder.RootComponents.Add<HeadOutlet>("head::after");

builder.Services.AddScoped(sp => new HttpClient { BaseAddress = new Uri(builder.HostEnvironment.BaseAddress) });
builder.Services.AddHttpClient("RickAndMortyApi", client =>
{
    client.BaseAddress = new Uri("https://rickandmortyapi.com/api/");
});
builder.Services.AddScoped<RickAndMortyService>();
await builder.Build().RunAsync();
