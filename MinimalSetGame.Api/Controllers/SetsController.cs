using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using MinimalSetGame.Api.Repositories.Interfaces;
using MinimalSetGame.Contracts;

namespace MinimalSetGame.Api.Controllers;

[ApiController]
[Route("api/games/{gameId:guid}/[controller]")]
[Authorize]
[Produces("application/json")]
public class SetsController : ControllerBase
{
    readonly ISetsRepository _setsRepository;

    public SetsController(ISetsRepository setsRepository)
    {
        _setsRepository = setsRepository;
    }

    [HttpGet]
    [ProducesResponseType(StatusCodes.Status200OK)]
    [ProducesResponseType(StatusCodes.Status404NotFound)]
    public async Task<ActionResult<List<SetResponse>>> GetSets(Guid gameId)
    {
        var sets = await _setsRepository.GetSets(gameId);

        if (sets is null)
            return NotFound("Game not found.");

        // map to response
        var response = sets.Select(
            set => new SetResponse(
            set.Id,
            set.GameId,
            set.Cards.Select(card => card.Id).ToList()))
            .ToList();

        return Ok(response);
    }

    [HttpPost]
    [ProducesResponseType(StatusCodes.Status201Created)]
    [ProducesResponseType(StatusCodes.Status400BadRequest)]
    public async Task<ActionResult<SetResponse>> TryCreateSet(
        Guid gameId,
        CreateSetRequest setRequest)
    {
        var result = await _setsRepository.TryAdd(setRequest);

        if (result is null)
            return BadRequest("Invalid set.");

        return CreatedAtAction(
        nameof(TryCreateSet),
        new { gameId, setId = result.Id },
        result);
    }
}
