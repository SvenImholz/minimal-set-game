using Microsoft.AspNetCore.Identity;

namespace MinimalSetGame.Entities;

public class Player : IdentityUser<Guid>
{
    public List<Game> Games { get; private set; } = [];
    public string? FirstName { get; private set; }
    public string? LastName { get; private set; }

    public Player()
    {
    }

    public Player(string firstName, string lastName)
    {
        FirstName = firstName;
        LastName = lastName;
    }
}
