using MinimalSetGame.Api.Enums;

namespace MinimalSetGame.Api.Entities;

public class Card
{

    public Card() {}
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
    public Guid GameId { get; set; }
    public Color Color { get; set; }
    public Shape Shape { get; set; }
    public Fill Fill { get; set; }
    public Number Number { get; set; }
    public bool IsDrawn { get; set; }
    /// <summary>
    ///     Set IsDrawn to true. This card has been drawn and cannot be drawn again.
    /// </summary>
    public void Draw() { IsDrawn = true; }
}
