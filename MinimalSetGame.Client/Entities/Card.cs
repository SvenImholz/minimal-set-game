using MinimalSetGame.Client.Entities.Enums;

namespace MinimalSetGame.Client.Entities;

public class Card
{
    public Guid Id { get; private set; }
    public Guid GameId { get; private set; }
    public Color Color { get; private set; }
    public Shape Shape { get; private set; }
    public Fill Fill { get; private set; }
    public Number Number { get; private set; }
    public bool IsDrawn { get; private set; }

    public Card(
        Guid id,
        Guid gameId,
        Color color,
        Shape shape,
        Fill fill,
        Number number,
        bool isDrawn)
    {
        Id = id;
        GameId = gameId;
        Color = color;
        Shape = shape;
        Fill = fill;
        Number = number;
        IsDrawn = isDrawn;
    }
}
