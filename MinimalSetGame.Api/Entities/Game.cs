using MinimalSetGame.Api.Enums;

namespace MinimalSetGame.Api.Entities;

public class Game
{

    Game() {}

    public Game(Guid playerId)
    {
        PlayerId = playerId;
        State = GameState.Started;
        CreatedAt = DateTime.UtcNow;
    }
    public Guid Id { get; set; }
    public List<Card> Deck { get; set; } = [];
    public List<Set> Sets { get; set; } = [];
    public Guid PlayerId { get; set; }
    public GameState State { get; set; }
    public DateTime CreatedAt { get; set; }
    public DateTime? FinishedAt { get; set; }




}
