namespace MinimalSetGame.Client.Entities;

public class Set
{
    public Guid Id { get; private set; }
    public Guid GameId { get; private set; }
    public List<Card> Cards { get; }
}
