using MinimalSetGame.Api.Entities;

namespace MinimalSetGame.Api.Repositories.Interfaces;

public interface IPlayerRepository
{
    Task<Player> GetPlayer(Guid playerId);
}
