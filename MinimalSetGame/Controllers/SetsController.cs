using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using MinimalSetGame.Repositories.Interfaces;

namespace MinimalSetGame.Controllers;

[ApiController]
[Route("api/games/{gameId:guid}/[controller]")]
[Authorize]
public class SetsController : ControllerBase
{
    readonly ISetsRepository _setsRepository;

    public SetsController (ISetsRepository setsRepository)
    {
        _setsRepository = setsRepository;
    }
}
