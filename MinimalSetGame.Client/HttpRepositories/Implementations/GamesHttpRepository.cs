using System.Net.Http.Json;
using System.Text.Json;
using MinimalSetGame.Client.Entities;
using MinimalSetGame.Client.HttpRepositories.Interfaces;
using MinimalSetGame.Contracts;

namespace MinimalSetGame.Client.HttpRepositories.Implementations;

public class GamesHttpRepository : IGamesHttpRepository
{
    readonly HttpClient _httpClient;

    public GamesHttpRepository(
        HttpClient httpClient)
    {
        _httpClient = httpClient;
    }

    public async Task<List<GameResponse>> GetGames()
    {
        var response = await _httpClient.GetFromJsonAsync<List<GameResponse>>("/api/games") ?? [];
        return response;
    }

    public Task<GameResponse?> GetGameById(Guid gameId) => throw new NotImplementedException();
    public Task<List<GameResponse>> GetGamesByPlayerId(Guid playerId) =>
        throw new NotImplementedException();
}
