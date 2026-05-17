using YetAnotherStore.Core.Dtos;
using YetAnotherStore.Core.Entities;
using YetAnotherStore.Core.RepositoryContracts;

namespace YetAnotherStore.Infrastructure.Repositories;

internal class UsersRepository : IUsersRepository
{
    public async Task<ApplicationUser?> AddUserAsync(ApplicationUser user)
    {
        user.UserId = Guid.NewGuid();

        return user;
    }

    public async Task<ApplicationUser?> GetUserAsync(string? email, string? password)
    {
        return new ApplicationUser
        {
            UserId = Guid.NewGuid(),
            Email = email,
            Password = password,
            FullName = "John Doe",
            Gender = nameof(GenderOptions.Male),
        };
    }
}
