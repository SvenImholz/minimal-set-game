using SetGame.Domain.Common.Enums;

namespace MinimalSetGame.Entities;

public class Game
{
    public List<Card> Deck { get; set; }
    public List<Set> Sets { get; set; }
    public Player Player { get; set; }
    public GameState State { get; set; }
}
