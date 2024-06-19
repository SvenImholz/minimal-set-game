namespace MinimalSetGame.Contracts;

/// <summary>
///
/// </summary>
/// <param name="SetId"></param>
/// <param name="GameId"></param>
/// <param name="Cards"></param>
public record SetResponse(
    Guid SetId,
    Guid GameId,
    List<Guid> Cards);
