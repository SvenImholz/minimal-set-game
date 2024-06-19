using MinimalSetGame.Contracts;
using MinimalSetGame.Entities;

namespace MinimalSetGame.Repositories.Interfaces;

public interface ISetsRepository
{
    public Task<Set?> GetSet(Guid setId);
    public Task<List<Set>> GetSets(Guid gameId);
    public Task TryAdd(CreateSetRequest set);
}
