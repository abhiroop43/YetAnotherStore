using AutoMapper;
using YetAnotherStore.Core.Dtos;
using YetAnotherStore.Core.Entities;
using YetAnotherStore.Core.RepositoryContracts;
using YetAnotherStore.Core.ServiceContracts;

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

        // return new AuthenticationResponse(
        //     user.UserId,
        //     user.Email,
        //     user.FullName,
        //     user.Gender,
        //     "dummy",
        //     true
        // );
    }

    public async Task<AuthenticationResponse?> RegisterAsync(RegisterRequest registerRequest)
    {
        // var user = new ApplicationUser
        // {
        //     Email = registerRequest.Email,
        //     FullName = registerRequest.FullName,
        //     Password = registerRequest.Password,
        //     Gender = registerRequest.Gender.ToString(),
        // };

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

        // return new AuthenticationResponse(
        //     registeredUser.UserId,
        //     registeredUser.Email,
        //     registeredUser.FullName,
        //     registeredUser.Gender,
        //     "dummy",
        //     true
        // );
    }
}
