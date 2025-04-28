using Testcontainers.PostgreSql;

namespace ES.Ajedrez.Api.Tests;

public class PostgressFixture : IAsyncLifetime
{
    private readonly PostgreSqlContainer _postgresContainer
        = new PostgreSqlBuilder().Build();

    public string ConectionString = string.Empty; 

    public async Task InitializeAsync()
    {
        await _postgresContainer.StartAsync();
        ConectionString = _postgresContainer.GetConnectionString();
    }

    public async Task DisposeAsync()
    {
        await _postgresContainer.DisposeAsync();
    }
}