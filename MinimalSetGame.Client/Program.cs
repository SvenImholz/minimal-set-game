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
builder.Services.AddCascadingAuthenticationState();

// register the cookie handler
builder.Services.AddTransient<CookieHandler>();

// set up authorization
builder.Services.AddAuthorizationCore();

// register the custom state provider
builder.Services
    .AddScoped<AuthenticationStateProvider, CookieAuthenticationStateProvider>();

// register the account management interface
builder.Services.AddScoped(
sp => (IAccountManagement)sp.GetRequiredService<AuthenticationStateProvider>());



// configure client for auth interactions
builder.Services.AddScoped(
sp =>
{
    var cookieHandler = sp.GetRequiredService<CookieHandler>();
    var httpClient = new HttpClient(cookieHandler)
        { BaseAddress = new Uri("https://localhost:7269") };

    return httpClient;
});

//builder.Services.AddScoped(sp => sp.GetService<IHttpClientFactory>()?.CreateClient("GamesAPI"));

// register repositories
builder.Services.AddScoped<IGamesHttpRepository, GamesHttpRepository>();
builder.Services.AddScoped<ISetHttpRepository, SetHttpRepository>();


await builder.Build().RunAsync();
