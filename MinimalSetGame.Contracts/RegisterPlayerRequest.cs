namespace MinimalSetGame.Contracts;

public record RegisterPlayerRequest(
    string Email,
    string Password,
    string? FirstName,
    string? LastName);
