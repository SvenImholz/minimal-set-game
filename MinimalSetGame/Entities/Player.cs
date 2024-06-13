using Microsoft.AspNetCore.Identity;

namespace MinimalSetGame.Entities;

public class Player : IdentityUser<Guid>
{
    public Player()
    {
    }
}
