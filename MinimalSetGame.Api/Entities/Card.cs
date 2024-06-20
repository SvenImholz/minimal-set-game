using MinimalSetGame.Api.Enums;

namespace MinimalSetGame.Api.Entities;

public class Card
{

    Card() {}
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
    public Guid Id { get; }
    public Guid GameId { get; private set; }
    public Color Color { get; private set; }
    public Shape Shape { get; private set; }
    public Fill Fill { get; private set; }
    public Number Number { get; private set; }
    public bool IsDrawn { get; private set; }
    /// <summary>
    ///     Set IsDrawn to true. This card has been drawn and cannot be drawn again.
    /// </summary>
    public void Draw() { IsDrawn = true; }
}
