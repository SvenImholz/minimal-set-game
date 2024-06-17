using MinimalSetGame.Data;
using MinimalSetGame.Entities;
using SetGame.Domain.Common.Enums;

namespace MinimalSetGame.Services;

public class CreateGameService
{
    readonly DataContext _context;

    public CreateGameService(DataContext context)
    {
        _context = context;
    }

    public async Task<Game> CreateGameAndCards(Guid playerId)
    {
        var game = new Game(playerId);
        _context.Games.Add(game);

        // Save the game to the database so that an ID is generated
        await _context.SaveChangesAsync();

        var cards = CreateDeck(game.Id);
        _context.Cards.AddRange(cards);

        // Save the cards to the database
        await _context.SaveChangesAsync();

        return game;
    }

    /// <summary>
    /// Create a deck of cards with all possible
    /// combinations of color, fill, number, and shape.
    /// </summary>
    static List<Card> CreateDeck(Guid gameId)
    {
        var deck = new List<Card>();
        foreach (Color color in Enum.GetValues(typeof(Color)))
        {
            foreach (Fill fill in Enum.GetValues(typeof(Fill)))
            {
                foreach (Number number in Enum.GetValues(typeof(Number)))
                {
                    foreach (Shape shape in Enum.GetValues(typeof(Shape)))
                    {
                        deck.Add(
                        new Card(
                        gameId,
                        color,
                        fill,
                        number,
                        shape));
                    }
                }
            }
        }

        return deck;
    }
}
