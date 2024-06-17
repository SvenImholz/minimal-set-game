using MinimalSetGame.Contracts;

namespace MinimalSetGame.Repositories;

public interface ICardRepository
{
    Task<List<CardResponse>> GetCards(Guid gameId);
    Task<List<CardResponse>> DrawCards(Guid gameId, int count);
}
