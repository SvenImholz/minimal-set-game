using MinimalSetGame.Contracts;
using MinimalSetGame.Data;
using MinimalSetGame.Entities;
using MinimalSetGame.Repositories.Interfaces;

namespace MinimalSetGame.Repositories.Implementations;

public class SetsRepository : ISetsRepository
{
    readonly DataContext _dataContext;

    public SetsRepository(DataContext dataContext) { _dataContext = dataContext; }

    public Task<Set?> GetSet(Guid setId) { throw new NotImplementedException(); }

    public Task<IEnumerable<Set>> GetSets(Guid gameId)
    {
        var sets = _dataContext.Games.Find(gameId)
            ?.Sets.Select(
            set => new SetResponse(
            set.Id,
            set.GameId,
            set.Cards.Select(card => card.Id).ToList())) ?? [];

        return Task.FromResult(sets);
    }
    public Task TryAdd(CreateSetRequest set) => throw new NotImplementedException();
}
