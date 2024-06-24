using MinimalSetGame.Client.Entities;

namespace MinimalSetGame.Client.HttpRepositories.Interfaces;

public interface IGamesHttpRepository
{
    Task<List<Game>> GetGames();
    Task<Game?> GetGameById(Guid gameId);
    Task<List<Game>> GetGamesByPlayerId(Guid playerId);
}
