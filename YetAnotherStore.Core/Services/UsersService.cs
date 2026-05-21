using YetAnotherStore.Core.RepositoryContracts;

namespace YetAnotherStore.Core.Services;

internal class UsersService(IUsersRepository usersRepository, IMapper mapper) : IUsersService
{
    public async Task<AuthenticationResponse?> LoginAsync(LoginRequest loginRequest)
    {
        var user = await usersRepository.GetUserAsync(loginRequest.Email, loginRequest.Password);

        if (user == null)
        {
            return null;
        }

        var response = mapper.Map<AuthenticationResponse>(user) with
        {
            Success = true,
            Token = "token",
        };

        return response;
    }

    public async Task<AuthenticationResponse?> RegisterAsync(RegisterRequest registerRequest)
    {
        var user = mapper.Map<ApplicationUser>(registerRequest);

        var registeredUser = await usersRepository.AddUserAsync(user);

        if (registeredUser == null)
        {
            return null;
        }

        return mapper.Map<AuthenticationResponse>(registeredUser) with
        {
            Success = true,
            Token = "token",
        };
    }
}
