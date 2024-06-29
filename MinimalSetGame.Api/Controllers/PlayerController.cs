using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;
using MinimalSetGame.Api.Entities;
using MinimalSetGame.Contracts;

namespace MinimalSetGame.Api.Controllers;

[ApiController]
[Route("api/[controller]")]
public class PlayerController : ControllerBase
{
    readonly SignInManager<Player> _signInManager;
    readonly UserManager<Player> _userManager;

    public PlayerController(
        UserManager<Player> userManager,
        SignInManager<Player> signInManager)
    {
        _userManager = userManager;
        _signInManager = signInManager;
    }

    [HttpPost("register")]
    public async Task<ActionResult<PlayerResponse>> Register(
        RegisterPlayerRequest
            registerPlayerRequest)
    {
        var player = new Player
        {
            UserName = registerPlayerRequest.Email,
            Email = registerPlayerRequest.Email,
            PasswordHash = registerPlayerRequest.Password,
            FirstName = registerPlayerRequest.FirstName,
            LastName = registerPlayerRequest.LastName
        };

        var result = await _userManager.CreateAsync(player, player.PasswordHash);

        if (!result.Succeeded)
            return BadRequest(result.Errors);

        await _signInManager.SignInAsync(player, true);

        return Ok("Player registered successfully.");
    }

    [HttpPost("login")]
    [ProducesResponseType(StatusCodes.Status200OK)]
    [ProducesResponseType(StatusCodes.Status400BadRequest)]
    public async Task<ActionResult<PlayerResponse>> Login(
        LoginPlayerRequest loginPlayerRequest)
    {
        var result = await _signInManager.PasswordSignInAsync(
        loginPlayerRequest.Email,
        loginPlayerRequest.Password,
        true,
        false);

        if (!result.Succeeded)
            return BadRequest("Invalid login attempt.");

        var player = await _userManager.FindByEmailAsync(loginPlayerRequest.Email);

        if (player?.Email is null)
            return BadRequest("Invalid login attempt.");

        var playerResponse = new PlayerResponse(
        player.Id,
        player.FirstName ?? string.Empty,
        player.LastName ?? string.Empty,
        player.Email
        );

        return Ok(playerResponse);
    }

    [HttpGet("manage/info")]
    [Authorize]
    public async Task<ActionResult<PlayerResponse>> GetPlayerInfo()
    {
        var player = await _userManager.GetUserAsync(User);

        if (player is null)
            return BadRequest("Invalid player.");

        var playerResponse = new PlayerResponse(
        player.Id,
        player.FirstName ?? string.Empty,
        player.LastName ?? string.Empty,
        player.Email
        );

        return Ok(playerResponse);
    }
}
