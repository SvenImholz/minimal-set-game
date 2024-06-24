using System.Net.Http.Json;
using System.Text.Json;
using MinimalSetGame.Client.Entities;
using MinimalSetGame.Client.HttpRepositories.Interfaces;

namespace MinimalSetGame.Client.HttpRepositories.Implementations;

public class GamesHttpRepository : IGamesHttpRepository
{
    readonly HttpClient _httpClient;

    public GamesHttpRepository(
        HttpClient httpClient)
    {
        _httpClient = httpClient;
    }

    public async Task<List<Game>> GetGames()
    {
        var response = await _httpClient.GetFromJsonAsync<List<Game>>("api/games") ?? [];
        return response;
    }

    public Task<Game?> GetGameById(Guid gameId) => throw new NotImplementedException();
    public Task<List<Game>> GetGamesByPlayerId(Guid playerId) =>
        throw new NotImplementedException();
}
