namespace MinimalSetGame.Contracts;

public record CreateSetRequest(
    Guid GameId,
    IEnumerable<CardResponse> Cards);
