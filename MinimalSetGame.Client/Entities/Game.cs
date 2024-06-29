using MinimalSetGame.Shared.Enums;

namespace MinimalSetGame.Client.Entities;

public class Game
{
    public Guid Id { get; set; }
    public List<Card> Deck { get; set; } = [];
    public List<Set> Sets { get; set; } = [];
    public GameState State { get; set; }
    public DateTime CreatedAt { get; set; }
    public DateTime? FinishedAt { get; set; }
}
