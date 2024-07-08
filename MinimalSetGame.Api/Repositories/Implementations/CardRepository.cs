using Microsoft.EntityFrameworkCore;
using MinimalSetGame.Api.Data;
using MinimalSetGame.Api.Entities;
using MinimalSetGame.Api.Repositories.Interfaces;

namespace MinimalSetGame.Api.Repositories.Implementations;

public class CardRepository(DataContext context) : ICardRepository
{

    public Task<List<Card>> GetCards(Guid gameId) => throw new NotImplementedException();
    public async Task<List<Card>> DrawCards(Guid gameId, int count)
    {
        var game = await context.Games.Include(game => game.Deck).FirstOrDefaultAsync(g => g.Id == gameId);

        if (game == null) return [];

        var cardsToDraw = game.Deck.FindAll(c => c.IsDrawn == false).Take(count).ToList();

        foreach (var card in cardsToDraw)
        {
            card.Draw();
        }

        await context.SaveChangesAsync();

        return cardsToDraw;
    }
}
