using System.Reflection;
using Microsoft.OpenApi.Models;
using MinimalSetGame.Api.Data;
using MinimalSetGame.Api.Entities;
using MinimalSetGame.Api.Repositories.Implementations;
using MinimalSetGame.Api.Repositories.Interfaces;
using MinimalSetGame.Api.Services;
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
    options.AddSecurityDefinition(
    "oauth2",
    new OpenApiSecurityScheme
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
builder.Services.AddScoped<ISetsRepository, SetsRepository>();
builder.Services.AddScoped<IPlayerRepository, PlayerRepository>();
builder.Services.AddScoped<CreateGameService>();
builder.Services.AddCors(
options =>
{
    options.AddDefaultPolicy(
    builder =>
    {
        builder.AllowAnyOrigin()
            .AllowAnyHeader()
            .AllowAnyMethod();
    });
});

var app = builder.Build();

// Configure the HTTP request pipeline.
if (app.Environment.IsDevelopment())
{
    app.UseSwagger();
    app.UseSwaggerUI();
}
app.UseCors();

app.MapIdentityApi<Player>();

app.UseHttpsRedirection();

app.UseAuthorization();

app.MapControllers();

app.MapGet("api/hello-world", () => "Hello, World!");

app.Run();
