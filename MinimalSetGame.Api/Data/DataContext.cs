using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Identity.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore;
using MinimalSetGame.Api.Entities;

namespace MinimalSetGame.Api.Data;

public class DataContext : IdentityDbContext<Player, IdentityRole<Guid>, Guid>
{
    readonly IConfiguration _configuration;

    public DataContext(
        DbContextOptions<DataContext> options,
        IConfiguration configuration) : base
        (options)
    {
        _configuration = configuration;
    }
    public DbSet<Player> Players { get; set; }
    public DbSet<Game> Games { get; set; }
    public DbSet<Card> Cards { get; set; }
    public DbSet<Set> Sets { get; set; }

    protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
    {
        optionsBuilder.UseNpgsql(_configuration.GetConnectionString("SetGameDb"));
    }

    protected override void OnModelCreating(ModelBuilder builder)
    {
        base.OnModelCreating(builder);

        builder.Entity<Game>().Property(g => g.Id).ValueGeneratedOnAdd();

        builder.Entity<Player>().Property(p => p.Id).ValueGeneratedOnAdd();

        builder.Entity<Card>().Property(c => c.Id).ValueGeneratedOnAdd();

        builder.Entity<Set>().Property(s => s.Id).ValueGeneratedOnAdd();

        builder.Entity<Game>()
            .HasMany(g => g.Deck)
            .WithOne()
            .HasForeignKey
                (c => c.GameId)
            .OnDelete(DeleteBehavior.Cascade);
    }
}
