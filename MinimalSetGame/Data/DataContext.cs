using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Identity.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore;
using MinimalSetGame.Entities;

namespace MinimalSetGame.Data;

public class DataContext : IdentityDbContext<Player, IdentityRole<Guid>, Guid>
{
    readonly IConfiguration _configuration;
    public DbSet<Player> Players { get; set; }
    public DbSet<Game> Games { get; set; }

    public DataContext(
        DbContextOptions<DataContext> options,
        IConfiguration configuration) : base
        (options)
    {
        _configuration = configuration;
    }

    protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
    {
        optionsBuilder.UseNpgsql(_configuration.GetConnectionString("SetGameDb"));
    }


}
