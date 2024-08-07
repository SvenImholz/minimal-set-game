using System.Security.Claims;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using MinimalSetGame.Api.Data;
using MinimalSetGame.Api.Entities;
using MinimalSetGame.Api.Repositories.Interfaces;
using MinimalSetGame.Api.Services;
using MinimalSetGame.Contracts;

namespace MinimalSetGame.Api.Controllers;

[Route("api/[controller]")]
[ApiController]
[Produces("application/json")]
[Authorize]
public class GamesController(IGameRepository gameRepository) : ControllerBase
{
    [HttpGet]
    public async Task<ActionResult<List<GameResponse>>> GetGames()
    {
        var games = await gameRepository.GetAllGames();
        // map to response
        var response = games.Select(
            game => new GameResponse(
            game.Id,
            game.Deck.Select(
                card => new CardResponse(
                Id: card.Id,
                Number: (int)card.Number,
                Color: (int)card.Color,
                Shape: (int)card.Shape,
                Fill: (int)card.Fill,
                card.IsDrawn))
                .ToList(),
            game.Sets.Select(
                set => new SetResponse(
                set.Id,
                set.GameId,
                set.Cards
                    .Select(c => c.Id)
                    .ToList()))
                .ToList(),
            (int)game.State,
            game.CreatedAt,
            game.FinishedAt)
            )
            .ToList();

        return response;
    }

    [HttpGet("{id:guid}")]
    [ProducesResponseType(StatusCodes.Status200OK)]
    [ProducesResponseType(StatusCodes.Status404NotFound)]
    public async Task<ActionResult<GameResponse>> GetGame(Guid id)
    {
        var game = await gameRepository.GetGameById(id);

        if (game is null)
            return NotFound("No Game Found");

        var gameResponse = new GameResponse(
            game.Id,
            game.Deck.Select(
                card => new CardResponse(
                Id: card.Id,
                Number: (int)card.Number,
                Color: (int)card.Color,
                Shape: (int)card.Shape,
                Fill: (int)card.Fill,
                card.IsDrawn))
                .ToList(),
            game.Sets.Select(
                set => new SetResponse(
                set.Id,
                set.GameId,
                set.Cards
                    .Select(c => c.Id)
                    .ToList()))
                .ToList(),
            (int)game.State,
            game.CreatedAt,
            game.FinishedAt);

        return gameResponse;
    }

    [HttpPost]
    [ProducesResponseType(StatusCodes.Status201Created)]
    public async Task<ActionResult<GameResponse>> CreateGame()
    {
        var userId = User.FindFirst(ClaimTypes.NameIdentifier)?.Value ??
                     throw new Exception("No user id found in claims.");

        var playerId = new Guid(userId);

        var createdGame = await gameRepository.Add(playerId);

        var gameResponse = new GameResponse(
            createdGame.Id,
            createdGame.Deck.Select(
                card => new CardResponse(
                Id: card.Id,
                Number: (int)card.Number,
                Color: (int)card.Color,
                Shape: (int)card.Shape,
                Fill: (int)card.Fill,
                card.IsDrawn))
                .ToList(),
            createdGame.Sets.Select(
                set => new SetResponse(
                set.Id,
                set.GameId,
                set.Cards
                    .Select(c => c.Id)
                    .ToList()))
                .ToList(),
            (int)createdGame.State,
            createdGame.CreatedAt,
            createdGame.FinishedAt);

        return gameResponse;
    }

    [HttpGet("{id:Guid}/hint")]
    public async Task<ActionResult<HintResponse>> GetHint(Guid id)
    {
        var game = await gameRepository.GetGameById(id);

        if (game is null)
            return NotFound("No Game Found");

        var hint = GameService.GetHint(game);

        if (hint is null)
            return NotFound("No possible set found");

        return hint;
    }
}
