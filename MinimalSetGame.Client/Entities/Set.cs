namespace MinimalSetGame.Client.Entities;

public class Set
{
    public Guid Id { get; set; }
    public List<Card> Cards { get; set; } = [];
}
