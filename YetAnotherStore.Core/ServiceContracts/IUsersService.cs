namespace YetAnotherStore.Core.ServiceContracts;

/// <summary>
/// Defines methods for authenticating and registering users.
/// </summary>
/// <remarks>Operations are asynchronous and may involve network or I/O; implementations may return null to
/// indicate failure and typically produce authentication tokens and user information.</remarks>
public interface IUsersService
{
    /// <summary>
    /// Authenticates a user with the provided credentials and returns authentication details.
    /// </summary>
    /// <remarks>Performs asynchronous authentication, typically involving network I/O.</remarks>
    /// <param name="loginRequest">The credentials and options used to authenticate the user.</param>
    /// <returns>A task that resolves to an AuthenticationResponse containing tokens and user information if authentication
    /// succeeds; otherwise null.</returns>
    Task<AuthenticationResponse?> LoginAsync(LoginRequest loginRequest);

    /// <summary>
    /// Registers a new user account and returns authentication details.
    /// </summary>
    /// <remarks>Operation is asynchronous; callers should handle a null result and any exceptions thrown by
    /// the implementation.</remarks>
    /// <param name="registerRequest">Registration details required to create the user account.</param>
    /// <returns>An AuthenticationResponse containing tokens and user information, or null if registration fails.</returns>
    Task<AuthenticationResponse?> RegisterAsync(RegisterRequest registerRequest);
}
