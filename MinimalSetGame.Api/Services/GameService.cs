using MinimalSetGame.Api.Data;
using MinimalSetGame.Api.Entities;
using MinimalSetGame.Api.Enums;
using MinimalSetGame.Contracts;

namespace MinimalSetGame.Api.Services;

public class GameService
{
    readonly DataContext _context;

    public GameService(DataContext context) { _context = context; }

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
    ///     Create a deck of cards with all possible
    ///     combinations of color, fill, number, and shape.
    /// </summary>
    static List<Card> CreateDeck(Guid gameId)
    {
        var deck = new List<Card>();
        foreach (Color color in Enum.GetValues(typeof(Color)))
        foreach (Fill fill in Enum.GetValues(typeof(Fill)))
        foreach (Number number in Enum.GetValues(typeof(Number)))
        foreach (Shape shape in Enum.GetValues(typeof(Shape)))
            deck.Add(
            new Card(
            gameId,
            color,
            fill,
            number,
            shape));

        return deck;
    }

    /// <summary>
    /// Get a Set hint for a game.
    /// </summary>
    /// <param name="game"></param>
    /// <returns></returns>
    public static HintResponse? GetHint(Game game)
    {
        var openCards = game?.Deck.Where(
            card => card.IsDrawn &&
                    !game.Sets.Any(
                    set =>
                        set.Cards.Contains(card)))
            .ToList();

        if (openCards is null || openCards.Count < 3)
            return null;

        var combinations = GetCombinations(openCards, 3);

        return (from combination in combinations
            where Set.IsSet(combination)
            select new HintResponse(
            combination.Select(
                card => new CardResponse(
                Id: card.Id,
                Number: (int)card.Number,
                Color: (int)card.Color,
                Shape: (int)card.Shape,
                Fill: (int)card.Fill,
                card.IsDrawn))
                .ToList())).FirstOrDefault();

    }


    /// <summary>
    /// Recursively get all combinations with a given length of a list of cards.
    /// </summary>
    /// <param name="list">The list of cards you want to get the combinations from</param>
    /// <param name="length">The length of the combination</param>
    /// <returns>A IEnumerable with a Lists of cards for each possible combination</returns>
    static IEnumerable<List<Card>> GetCombinations(List<Card> list, int length)
    {
        for (var i = 0; i < list.Count; i++)
        {
            if (length == 1)
            {
                yield return new List<Card> { list[i] };
            }
            else
            {
                foreach (var next in GetCombinations(
                         list.Skip(i + 1).ToList(),
                         length - 1))
                {
                    yield return new List<Card> { list[i] }.Concat(next).ToList();
                }
            }
        }
    }
}
