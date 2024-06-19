namespace MinimalSetGame.Contracts;

public record CardResponse(
    Guid Id,
    int Number,
    int Color,
    int Shape,
    int Fill,
    bool IsDrawn
    );
