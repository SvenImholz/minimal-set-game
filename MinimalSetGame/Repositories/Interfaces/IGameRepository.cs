using MinimalSetGame.Contracts;
using MinimalSetGame.Entities;

namespace MinimalSetGame.Repositories.Interfaces;

public interface IGameRepository
{
      public Task<Game?> GetGameById(Guid gameId);
      public Task<List<Game>> GetAllGamesFromPlayer(Guid playerId);
      public Task<Game> Add(Guid playerId);
      public Task Remove(Game game);
      public Task<Game> Update(Game game);

      public Task<List<Game>> GetAllGames();
}
