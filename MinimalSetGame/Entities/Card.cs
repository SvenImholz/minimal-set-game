using SetGame.Domain.Common.Enums;

namespace MinimalSetGame.Entities;

public class Card
{
    public Guid Id { get; private set; }
    public Guid GameId { get; private set; }
    public Color Color { get; private set; }
    public Shape Shape { get; private set; }
    public Fill Fill { get; private set; }
    public Number Number { get; private set; }
    public bool IsDrawn { get; private set; } = false;

    private Card() {}
    public Card(
        Guid gameId,
        Color color,
        Fill fill,
        Number number,
        Shape shape)
    {
        GameId = gameId;
        Color = color;
        Fill = fill;
        Number = number;
        Shape = shape;
    }
    /// <summary>
    /// Set IsDrawn to true. This card has been drawn and cannot be drawn again.
    /// </summary>
    public void Draw() { IsDrawn = true; }

}
