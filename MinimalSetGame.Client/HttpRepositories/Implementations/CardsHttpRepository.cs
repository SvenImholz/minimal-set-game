using System.Net.Http.Json;
using MinimalSetGame.Client.HttpRepositories.Interfaces;
using MinimalSetGame.Contracts;


namespace MinimalSetGame.Client.HttpRepositories.Implementations;

public class CardsHttpRepository(HttpClient httpClient) : ICardsHttpRepository
{

    public async Task<List<CardResponse>> DrawCards(Guid gameId, int count)
    {
        try
        {
            var response = await httpClient.GetAsync
                ($"/api/games/{gameId}/cards/Draw/{count}");

            response.EnsureSuccessStatusCode();

            var result = await response.Content.ReadFromJsonAsync<List<CardResponse>>();

            return result ?? [];
        }
        catch (Exception e)
        {
            Console.WriteLine(e);

            throw;
        }

    }
}
