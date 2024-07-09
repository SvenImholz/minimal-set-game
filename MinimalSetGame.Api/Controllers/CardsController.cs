using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using MinimalSetGame.Api.Repositories.Interfaces;
using MinimalSetGame.Contracts;

namespace MinimalSetGame.Api.Controllers;

[ApiController]
[Route("api/games/{gameId:guid}/[controller]")]
[Authorize]
public class CardsController(ICardRepository cardRepository) : ControllerBase
{

    [HttpGet]
    public async Task<ActionResult<List<CardResponse>>> GetCards(Guid gameId)
    {
        var cards = await cardRepository.GetCards(gameId);

        var response = cards.Select(c => new CardResponse(c.Id, (int)c.Number, (int)c
                .Color, (int)c
                .Shape, (int)c.Fill, c.IsDrawn)).ToList();

        return response;
    }

    [HttpGet("Draw/{count:int}")]
    public async Task<ActionResult<List<CardResponse>>> DrawCards(Guid gameId, int count)
    {
        var cards = await cardRepository.DrawCards(gameId, count);

        var response = cards.Select(c => new CardResponse(c.Id, (int)c.Number, (int)c
                .Color, (int)c
                .Shape, (int)c.Fill, c.IsDrawn)).ToList();

        return response;
    }
}
