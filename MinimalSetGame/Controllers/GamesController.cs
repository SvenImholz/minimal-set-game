using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using MinimalSetGame.Entities;

namespace MinimalSetGame.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    [Authorize]
    public class GamesController : ControllerBase
    {
        [HttpGet]
        public async Task<ActionResult<List<Game>>> GetGames()
        {
            await Task.CompletedTask;
            var game = new Game(new Player());
            return Ok(game);
        }
    }
}
