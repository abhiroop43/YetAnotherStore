namespace YetAnotherStore.Core.Dtos;

public record AuthenticationResponse(
    Guid UserId,
    string? Email,
    string? FullName,
    string? Gender,
    string? Token,
    bool Success
);
