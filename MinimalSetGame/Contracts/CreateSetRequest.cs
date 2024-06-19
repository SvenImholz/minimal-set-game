namespace MinimalSetGame.Contracts;

public record CreateSetRequest(
    Guid GameId,
    List<Guid> Cards);
