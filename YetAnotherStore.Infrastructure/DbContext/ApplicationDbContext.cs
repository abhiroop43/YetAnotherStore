using System.Data;
using Microsoft.Extensions.Configuration;
using Npgsql;

namespace YetAnotherStore.Infrastructure.DbContext;

public class ApplicationDbContext
{
    private readonly IDbConnection _connection;

    public ApplicationDbContext(IConfiguration configuration)
    {
        var connectionString = configuration.GetConnectionString("DefaultConnection");

        _connection = new NpgsqlConnection(connectionString);
    }

    public IDbConnection DbConnection => _connection;
}
