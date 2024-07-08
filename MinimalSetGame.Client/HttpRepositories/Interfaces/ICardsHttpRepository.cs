using MinimalSetGame.Contracts;

namespace MinimalSetGame.Client.HttpRepositories.Interfaces;

public interface ICardsHttpRepository
{
    Task<List<CardResponse>> DrawCards(Guid gameId, int count);
}
