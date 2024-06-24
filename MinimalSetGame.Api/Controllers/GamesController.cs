using System.Security.Claims;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using MinimalSetGame.Api.Repositories.Interfaces;
using MinimalSetGame.Contracts;

namespace MinimalSetGame.Api.Controllers;

[Route("api/[controller]")]
[ApiController]
[Produces("application/json")]
// [Authorize]
public class GamesController : ControllerBase
{
    readonly IGameRepository _gameRepository;
    // readonly IPlayerRepository _playerRepository; fix
    public GamesController(IGameRepository gameRepository)
    {
        _gameRepository = gameRepository;
        // _playerRepository = playerRepository; //todo: uncoomment after fixing the IPlayerRepository
    }

    [HttpGet]
    public async Task<ActionResult<List<GameResponse>>> GetGames()
    {
        var games = await _gameRepository.GetAllGames();

        return Ok(games);
    }

    [HttpGet("{id:guid}")]
    [ProducesResponseType(StatusCodes.Status200OK)]
    [ProducesResponseType(StatusCodes.Status404NotFound)]
    public async Task<ActionResult<GameResponse>> GetGame(Guid id)
    {
        var game = await _gameRepository.GetGameById(id);

        if (game is null)
            return NotFound("No Game Found");

        return Ok(game);
    }

    [HttpPost]
    [ProducesResponseType(StatusCodes.Status201Created)]
    public async Task<ActionResult<GameResponse>> CreateGame()
    {
        var userId = User.FindFirst(ClaimTypes.NameIdentifier)?.Value ??
                     throw new Exception("No user id found in claims.");

        var playerId = new Guid(userId);


        var createdGame = await _gameRepository.Add(playerId);

        return CreatedAtAction(
        nameof(GetGames),
        new { id = createdGame.Id },
        createdGame);
    }
}
