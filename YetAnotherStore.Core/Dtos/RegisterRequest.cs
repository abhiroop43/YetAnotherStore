namespace YetAnotherStore.Core.Dtos;

public record RegisterRequest(
    string? Email,
    string? Password,
    string? FullName,
    GenderOptions Gender
);
