using SetGame.Domain.Common.Enums;

namespace MinimalSetGame.Entities;

public class Card(
    Guid cardId,
    Guid gameId,
    Color color,
    Fill fill,
    Number number,
    Shape shape)
{
    public Guid Id { get; private set; } = cardId;
    public Guid GameId { get; private set; } = gameId;
    public Color Color { get; private set; } = color;
    public Shape Shape { get; private set; } = shape;
    public Fill Fill { get; private set; } = fill;
    public Number Number { get; private set; } = number;
    public bool IsDrawn { get; private set; } = false;

    /// <summary>
    /// Set IsDrawn to true. This card has been drawn and cannot be drawn again.
    /// </summary>
    public void Draw()
    {
        IsDrawn = true;
    }
}
