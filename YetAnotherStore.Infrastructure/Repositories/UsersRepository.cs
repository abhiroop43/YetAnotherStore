using Dapper;
using YetAnotherStore.Core.Dtos;
using YetAnotherStore.Core.Entities;
using YetAnotherStore.Core.RepositoryContracts;
using YetAnotherStore.Infrastructure.DbContext;

namespace YetAnotherStore.Infrastructure.Repositories;

internal class UsersRepository(ApplicationDbContext dbContext) : IUsersRepository
{
    public async Task<ApplicationUser?> AddUserAsync(ApplicationUser user)
    {
        user.UserId = Guid.NewGuid();

        var query =
            "INSERT INTO public.\"users\" (\"userid\", \"email\", \"password\", \"fullname\", \"gender\") VALUES (@UserId, @Email, @Password, @FullName, @Gender)";

        var affectedRows = await dbContext.DbConnection.ExecuteAsync(query, user);

        return affectedRows > 0 ? user : null;
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
