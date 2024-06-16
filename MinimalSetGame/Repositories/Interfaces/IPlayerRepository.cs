using MinimalSetGame.Entities;

namespace MinimalSetGame.Repositories.Interfaces;

public interface IPlayerRepository
{
    Task<Player> GetPlayer(Guid playerId);
}
