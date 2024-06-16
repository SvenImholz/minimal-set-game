using System.Security.Claims;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using MinimalSetGame.Contracts;
using MinimalSetGame.Repositories.Interfaces;

namespace MinimalSetGame.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    [Authorize]
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

        [HttpPost]
        public async Task<ActionResult<CreateGameRequest>> CreateGame(
            CreateGameRequest createGameRequestrequest)
        {
            var userId = User.FindFirst(ClaimTypes.NameIdentifier)?.Value ??
                         throw new Exception("No user id found in claims.");

            var playerId = new Guid(userId);

            if (playerId != createGameRequestrequest.PlayerId)
                return Unauthorized("You can only create games for yourself.");

            var createdGame = await _gameRepository.Add(createGameRequestrequest);

            return Ok(createdGame);
        }
    }

}
