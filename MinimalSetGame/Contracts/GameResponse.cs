
namespace MinimalSetGame.Contracts;

public record GameResponse(
    Guid Id,
    List<CardResponse> Deck,
    List<SetResponse> Sets,
    string State,
    DateTime CreatedAt,
    DateTime? FinishedAt
);
