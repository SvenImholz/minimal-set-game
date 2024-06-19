using MinimalSetGame.Entities;
using MinimalSetGame.Repositories.Interfaces;

namespace MinimalSetGame.Repositories.Implementations;

public class PlayerRepository : IPlayerRepository
{
    public Task<Player> GetPlayer(Guid playerId) => throw new NotImplementedException();
}
