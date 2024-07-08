using MinimalSetGame.Contracts;

namespace MinimalSetGame.Client.HttpRepositories.Interfaces;

public interface ISetHttpRepository
{
    Task<List<SetResponse>> GetSets(Guid gameId);
    Task<SetResponse?> TryCreateSet(Guid gameId, CreateSetRequest setRequest);
}
