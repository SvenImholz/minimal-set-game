using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using MinimalSetGame.Contracts;
using MinimalSetGame.Repositories.Interfaces;

namespace MinimalSetGame.Controllers;

[ApiController]
[Route("api/games/{gameId:guid}/[controller]")]
[Authorize]
public class CardsController : ControllerBase
{
    readonly ICardRepository _cardRepository;

    public CardsController(ICardRepository cardRepository)
    {
        _cardRepository = cardRepository;
    }

    [HttpGet]
    public async Task<ActionResult<List<CardResponse>>> GetCards(Guid gameId)
    {
        var cards = await _cardRepository.GetCards(gameId);

        return Ok(cards);
    }

    [HttpGet("Draw/{count:int}")]
    public async Task<ActionResult<List<CardResponse>>> DrawCards(Guid gameId, int count)
    {
        var cards = await _cardRepository.DrawCards(gameId, count);

        return Ok(cards);
    }
}
