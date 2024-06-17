using SetGame.Domain.Common.Enums;

namespace MinimalSetGame.Entities;

public class Set
{
    public Guid Id { get; private set; }
    public Guid GameId { get; private set; }
    public List<Card> Cards { get; }

    private Set() { }


    /// <summary>
    /// Create a set of cards.
    /// </summary>
    /// <param name="gameId">The Game the set belongs to</param>
    /// <param name="possibleSet">A list of cards that is possibly a set</param>
    /// <exception cref="ArgumentException">If it's not a set it returns an ArgumentException</exception>
    public Set(
        Guid gameId,
        List<Card> possibleSet)
    {
        if (!IsSet(possibleSet))
            throw new ArgumentException("Cards do not form a set.");

        GameId = gameId;
        Cards = possibleSet;
    }

    /// <summary>
    /// Check if a list of cards is a set.
    /// </summary>
    /// <param name="possibleSet">The list of cards</param>
    /// <returns>True if it's a set.<br/>Otherwise False</returns>
    static bool IsSet(List<Card> possibleSet)
    {
        if (possibleSet.Count != 3)
            return false;

        var colors = new HashSet<Color>();
        var shapes = new HashSet<Shape>();
        var fills = new HashSet<Fill>();
        var numbers = new HashSet<Number>();

        foreach (var card in possibleSet)
        {
            colors.Add(card.Color);
            shapes.Add(card.Shape);
            fills.Add(card.Fill);
            numbers.Add(card.Number);
        }

        // If a property count is 1 or 3 it's a set.
        return colors.Count != 2 &&
               shapes.Count != 2 &&
               fills.Count != 2 &&
               numbers.Count != 2;
    }
}