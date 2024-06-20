using MinimalSetGame.Api.Entities;
using MinimalSetGame.Api.Repositories.Interfaces;

namespace MinimalSetGame.Api.Repositories.Implementations;

public class PlayerRepository : IPlayerRepository
{
    public Task<Player> GetPlayer(Guid playerId) => throw new NotImplementedException();
}
