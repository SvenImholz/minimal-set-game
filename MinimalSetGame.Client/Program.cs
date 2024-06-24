using BlazorWasmAuth.Identity;
using Microsoft.AspNetCore.Components.Authorization;
using Microsoft.AspNetCore.Components.Web;
using Microsoft.AspNetCore.Components.WebAssembly.Hosting;
using MinimalSetGame.Client.Components;
using MinimalSetGame.Client.HttpRepositories.Implementations;
using MinimalSetGame.Client.HttpRepositories.Interfaces;
using MinimalSetGame.Client.Identity;


var builder = WebAssemblyHostBuilder.CreateDefault(args);
builder.RootComponents.Add<App>("#app");
builder.RootComponents.Add<HeadOutlet>("head::after");

builder.Services.AddScoped(
    sp => new HttpClient { BaseAddress = new Uri("https://localhost:7269/") });


// register the cookie handler
// builder.Services.AddTransient<CookieHandler>();

// set up authorization
// builder.Services.AddAuthorizationCore();

// register the custom state provider
// builder.Services
    // .AddScoped<AuthenticationStateProvider, CookieAuthenticationStateProvider>();

// register repositories
builder.Services.AddScoped<IGamesHttpRepository, GamesHttpRepository>();


await builder.Build().RunAsync();
