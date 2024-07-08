using System.Net.Http.Json;
using MinimalSetGame.Client.HttpRepositories.Interfaces;
using MinimalSetGame.Contracts;

namespace MinimalSetGame.Client.HttpRepositories.Implementations;

public class SetHttpRepository : ISetHttpRepository
{
    readonly HttpClient _httpClient;

    public SetHttpRepository(HttpClient httpClient) { _httpClient = httpClient; }

    public async Task<List<SetResponse>> GetSets(Guid gameId)
    {
        var response =
            await _httpClient.GetFromJsonAsync<List<SetResponse>>(
            $"/api/games/{gameId}/sets") ??
            [];

        return response;
    }

    public async Task<SetResponse?> TryCreateSet(Guid gameId, CreateSetRequest setRequest)
    {
        var response = await _httpClient.PostAsJsonAsync(
        $"/api/games/{gameId}/sets",
        setRequest);

        return await response.Content.ReadFromJsonAsync<SetResponse>();
    }
}
