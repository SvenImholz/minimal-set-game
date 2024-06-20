using MinimalSetGame.Api.Data;
using MinimalSetGame.Api.Entities;
using MinimalSetGame.Api.Repositories.Interfaces;

namespace MinimalSetGame.Api.Repositories.Implementations;

public class CardRepository : ICardRepository
{
    DataContext _context;

    public CardRepository(DataContext context) { _context = context; }

    public Task<List<Card>> GetCards(Guid gameId) => throw new NotImplementedException();
    public Task<List<Card>> DrawCards(Guid gameId, int count) =>
        throw new NotImplementedException();
}
