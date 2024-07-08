using Microsoft.EntityFrameworkCore;
using MinimalSetGame.Api.Data;
using MinimalSetGame.Api.Entities;
using MinimalSetGame.Api.Repositories.Interfaces;
using MinimalSetGame.Contracts;

namespace MinimalSetGame.Api.Repositories.Implementations;

public class SetsRepository : ISetsRepository
{
    readonly DataContext _dataContext;

    public SetsRepository(DataContext dataContext) { _dataContext = dataContext; }

    public Task<Set?> GetSet(Guid setId) => throw new NotImplementedException();

    public async Task<List<Set>?> GetSets(Guid gameId)
    {
        var game = await _dataContext.Games.Include(game => game.Sets)
            .FirstOrDefaultAsync(g => g.Id == gameId);

        return game?.Sets.ToList();
    }

    /// <summary>
    ///     Tries to add a set to the game.
    /// </summary>
    /// <param name="setRequest">The data to create a set</param>
    /// <returns>null or Task.CompletedTask</returns>
    public async Task<Set?> TryAdd(CreateSetRequest setRequest)
    {
        Set newSet;

        // Get the cards to add to the set but only if they are drawn
        var cardsToAdd = _dataContext.Cards
            .Where(
            card => setRequest.Cards.Any(
            cardResponse => cardResponse ==
                            card
                                .Id &&
                            card.IsDrawn))
            .ToList();

        // Check if the cards are drawn or already in a set.
        if (cardsToAdd.Count != 3)
            return null;

        // Try to create a new set, if it's not a set it will throw an ArgumentException
        try
        {
            newSet = new Set(setRequest.GameId, cardsToAdd);

        }
        catch (ArgumentException)
        {
            return null;
        }

        var game = await _dataContext.Games.FindAsync(setRequest.GameId);

        if (game is null)
            return null;

        // Get all sets that contain any of the cards to add
        var setsWithCards = _dataContext.Sets
            .Where(set => set.Cards.Any(card => cardsToAdd.Contains(card)))
            .ToList();

        // If any of the cards to add is already in a set, return null
        if (setsWithCards.Count != 0)
            return null;

        _dataContext.Sets.Add(newSet);
        await _dataContext.SaveChangesAsync();

        return newSet;
    }
}
