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

    public Task<Game> GetGameById(Guid gameId)
    {
        throw new NotImplementedException();
    }

    public Task<List<Game>> GetAllGamesFromPlayer(Guid playerId)
    {
        throw new NotImplementedException();
    }

    public async Task<Game> Add(CreateGameRequest gameRequest)
    {
        var game = await _createGameService.CreateGameAndCards(gameRequest.PlayerId);

        await _context.Games.AddAsync(game);
        await _context.SaveChangesAsync();
        return game;
    }

    public Task Remove(Game game)
    {
        throw new NotImplementedException();
    }

    public Task<Game> Update(Game game)
    {
        throw new NotImplementedException();
    }

    public async Task<List<Game>> GetAllGames()
    {
        return await _context.Games.ToListAsync();
    }
}
