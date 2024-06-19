namespace MinimalSetGame.Contracts;

public record SetResponse(
    Guid SetId,
    Guid GameId,
    List<Guid> Cards);
