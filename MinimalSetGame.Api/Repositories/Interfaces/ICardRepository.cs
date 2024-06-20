using MinimalSetGame.Api.Entities;

namespace MinimalSetGame.Api.Repositories.Interfaces;

public interface ICardRepository
{
    Task<List<Card>> GetCards(Guid gameId);
    Task<List<Card>> DrawCards(Guid gameId, int count);
}
