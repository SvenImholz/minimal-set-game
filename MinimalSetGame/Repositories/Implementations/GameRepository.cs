using Microsoft.EntityFrameworkCore;
using MinimalSetGame.Contracts;
using MinimalSetGame.Data;
using MinimalSetGame.Entities;
using MinimalSetGame.Repositories.Interfaces;
using MinimalSetGame.Services;

namespace MinimalSetGame.Repositories.Implementations;

public class GameRepository : IGameRepository
{
    readonly DataContext _context;
    private readonly CreateGameService _createGameService;

    public GameRepository(DataContext context, CreateGameService createGameService)
    {
        _context = context;
        _createGameService = createGameService;
    }

    public async Task<Game?> GetGameById(Guid gameId)
    {
        var game = await _context.Games.Include(g => g.Deck)
            .Include(g => g.Sets)
            .FirstOrDefaultAsync(
            g => g.Id ==
                 gameId);

        return game;
    }

    public Task<List<Game>> GetAllGamesFromPlayer(Guid playerId)
    {
        var games = _context.Games
            .Where(g => g.PlayerId == playerId)
            .ToList();

        return Task.FromResult(games);
    }

    public async Task<Game> Add(Guid playerId)
    {
        var game = await _createGameService.CreateGameAndCards(playerId);

        return game;
    }

    public Task Remove(Game game) { throw new NotImplementedException(); }

    public Task<Game> Update(Game game) { throw new NotImplementedException(); }

    public async Task<List<Game>> GetAllGames()
    {
        return await _context.Games.ToListAsync();
    }
}
