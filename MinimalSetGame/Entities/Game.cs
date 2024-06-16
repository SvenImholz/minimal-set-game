using SetGame.Domain.Common.Enums;

namespace MinimalSetGame.Entities;

public class Game
{
    public Guid Id { get; set; }
    public List<Card> Deck { get; set; }
    public List<Set> Sets { get; set; } = [];
    public Guid PlayerId { get; set; }
    public GameState State { get; set; }
    public DateTime CreatedAt { get; set; }
    public DateTime? FinishedAt { get; set; }

    private Game()
    {}

    public Game(Guid playerId)
    {
        PlayerId = playerId;
        State = GameState.Started;
        CreatedAt = DateTime.UtcNow;
        Deck = CreateDeck();
    }

    /// <summary>
    /// Create a deck of cards with all possible
    /// combinations of color, fill, number, and shape.
    /// </summary>
    List<Card> CreateDeck()
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
                        Deck.Add(
                        new Card(
                        Id,
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
