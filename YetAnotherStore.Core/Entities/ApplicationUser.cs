namespace YetAnotherStore.Core.Entities;

/// <summary>
/// Represents an application user with identity and profile information.
/// </summary>
/// <remarks>This class is typically used to store and transfer user-related data within the application, such as
/// during authentication, registration, or profile management scenarios.</remarks>
public class ApplicationUser
{
    public Guid UserId { get; set; }
    public string? Email { get; set; }
    public string? Password { get; set; }
    public string? FullName { get; set; }
    public string? Gender { get; set; }
}
