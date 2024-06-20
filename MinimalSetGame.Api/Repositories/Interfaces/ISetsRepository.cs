using MinimalSetGame.Api.Entities;
using MinimalSetGame.Contracts;

namespace MinimalSetGame.Api.Repositories.Interfaces;

public interface ISetsRepository
{
    public Task<Set?> GetSet(Guid setId);
    public Task<List<Set>?> GetSets(Guid gameId);
    public Task<Set?> TryAdd(CreateSetRequest setRequest);
}
