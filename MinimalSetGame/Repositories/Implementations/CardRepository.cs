using MinimalSetGame.Data;
using MinimalSetGame.Entities;
using MinimalSetGame.Repositories.Interfaces;

namespace MinimalSetGame.Repositories.Implementations;

public class CardRepository : ICardRepository
{
    DataContext _context;

    public CardRepository(DataContext context) { _context = context; }

    public Task<List<Card>> GetCards(Guid gameId) => throw new NotImplementedException();
    public Task<List<Card>> DrawCards(Guid gameId, int count) => throw new NotImplementedException();
}
