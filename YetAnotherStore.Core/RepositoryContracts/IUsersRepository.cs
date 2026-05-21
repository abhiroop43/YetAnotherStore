namespace YetAnotherStore.Core.RepositoryContracts;

/// <summary>
/// Provides asynchronous operations to add and retrieve ApplicationUser instances from a backing store.
/// </summary>
/// <remarks>Implementations perform I/O, validation, and secure password verification. They are responsible for
/// error handling, protecting sensitive data, and concurrency considerations. Prefer non-blocking asynchronous
/// implementations and consider exposing cancellation support where appropriate.</remarks>
public interface IUsersRepository
{
    /// <summary>
    /// Adds the supplied ApplicationUser to the underlying store asynchronously and returns the created user.
    /// </summary>
    /// <remarks>Implementations may validate the user and persist it to backing storage; failures may throw
    /// exceptions.</remarks>
    /// <param name="user">The ApplicationUser to add.</param>
    /// <returns>A Task whose result is the created ApplicationUser, or null if the user could not be created.</returns>
    Task<ApplicationUser?> AddUserAsync(ApplicationUser user);

    /// <summary>
    /// Asynchronously retrieves the ApplicationUser that matches the specified email and password, or null if no match
    /// exists.
    /// </summary>
    /// <remarks>Implementations must perform password verification securely and may perform I/O; avoid
    /// exposing sensitive information.</remarks>
    /// <param name="email">The email address used to identify the user; may be null.</param>
    /// <param name="password">The password used to validate the identified user; may be null.</param>
    /// <returns>A Task whose result is the matching ApplicationUser, or null if no matching user is found.</returns>
    Task<ApplicationUser?> GetUserAsync(string? email, string? password);
}
