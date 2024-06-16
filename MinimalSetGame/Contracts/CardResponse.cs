namespace MinimalSetGame.Contracts;

public record CardResponse(
    Guid Id,
    int Number,
    string Color,
    string Shape,
    string Fill,
    bool IsDrawn
    );
