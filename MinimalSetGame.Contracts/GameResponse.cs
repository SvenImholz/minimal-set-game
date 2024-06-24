
namespace MinimalSetGame.Contracts;

public record GameResponse(
    Guid Id,
    List<CardResponse> Deck,
    List<SetResponse> Sets,
    int State,
    DateTime CreatedAt,
    DateTime? FinishedAt
);
