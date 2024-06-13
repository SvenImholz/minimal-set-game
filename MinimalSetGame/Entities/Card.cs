using SetGame.Domain.Common.Enums;

namespace MinimalSetGame.Entities;

public class Card
{
    public Guid Id { get; private set; }
    public Guid Guid { get; private set; }
    public Color Color { get; private set; }
    public Shape Shape { get; private set; }
    public Fill Fill { get; private set; }
    public Number Number { get; private set; }
    public bool IsDrawn { get; private set; }
}
