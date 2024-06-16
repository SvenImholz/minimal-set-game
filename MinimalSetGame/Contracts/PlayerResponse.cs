namespace MinimalSetGame.Contracts;

public record PlayerResponse(
    Guid Id,
    string FirstName,
    string LastName,
    string Email
);
