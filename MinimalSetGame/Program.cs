using System.Reflection;
using Microsoft.OpenApi.Models;
using MinimalSetGame.Data;
using MinimalSetGame.Entities;
using MinimalSetGame.Repositories;
using MinimalSetGame.Repositories.Implementations;
using MinimalSetGame.Repositories.Interfaces;
using MinimalSetGame.Services;
using Swashbuckle.AspNetCore.Filters;

var builder = WebApplication.CreateBuilder(args);

// Configuration
builder.Configuration
    .AddJsonFile("appsettings.json")
    .AddJsonFile("appsettings.Development.json", true)
    .AddUserSecrets(Assembly.GetExecutingAssembly())
    .AddEnvironmentVariables();

builder.Services.AddControllers();
// Learn more about configuring Swagger/OpenAPI at https://aka.ms/aspnetcore/swashbuckle
builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen(
options =>
{
    options.AddSecurityDefinition("oauth2", new OpenApiSecurityScheme
    {
       In = ParameterLocation.Header,
       Name = "Authorization",
       Type = SecuritySchemeType.ApiKey
    });
    options.OperationFilter<SecurityRequirementsOperationFilter>();
});

builder.Services.AddDbContext<DataContext>();
builder.Services.AddAuthorization();
builder.Services.AddIdentityApiEndpoints<Player>()
    .AddEntityFrameworkStores<DataContext>();

builder.Services.AddScoped<IGameRepository, GameRepository>();
builder.Services.AddScoped<ICardRepository, CardRepository>();
builder.Services.AddScoped<CreateGameService>();

var app = builder.Build();

// Configure the HTTP request pipeline.
if (app.Environment.IsDevelopment())
{
    app.UseSwagger();
    app.UseSwaggerUI();
}

app.MapIdentityApi<Player>();

app.UseHttpsRedirection();

app.UseAuthorization();

app.MapControllers();

app.Run();
