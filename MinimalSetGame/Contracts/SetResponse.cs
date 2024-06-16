namespace MinimalSetGame.Contracts;

public record SetResponse(
    Guid SetId,
    List<Guid> Cards);
