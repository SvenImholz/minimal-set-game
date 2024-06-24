using MinimalSetGame.Client.Entities;
using MinimalSetGame.Contracts;

namespace MinimalSetGame.Client.HttpRepositories.Interfaces;

public interface IGamesHttpRepository
{
    Task<List<GameResponse>> GetGames();
    Task<GameResponse?> GetGameById(Guid gameId);
    Task<List<GameResponse>> GetGamesByPlayerId(Guid playerId);
}
