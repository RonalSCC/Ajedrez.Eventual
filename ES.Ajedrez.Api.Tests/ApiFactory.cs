using ES.Ajedrez.API;
using ES.Ajedrez.EventStore;
using Marten;
using Microsoft.AspNetCore.Hosting;
using Microsoft.AspNetCore.Mvc.Testing;
using Microsoft.AspNetCore.TestHost;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.DependencyInjection.Extensions;
using Testcontainers.PostgreSql;
using Wolverine.Marten;

namespace ES.Ajedrez.Api.Tests;

public class ApiFactory : WebApplicationFactory<IApiAssemblyMarker>, IAsyncLifetime
{
    private readonly PostgreSqlContainer _postgresContainer
        = new PostgreSqlBuilder().Build();

    public async Task InitializeAsync()
    {
        await _postgresContainer.StartAsync();
    }

    protected override void ConfigureWebHost(IWebHostBuilder builder)
    {
        builder.UseEnvironment("Development");
        builder.ConfigureTestServices(services =>
        {
            services.AgregarConfiguracionMarten(_postgresContainer.GetConnectionString(), true)
                .IntegrateWithWolverine();
        });
    }

    public Task DisposeAsync()
    {
        return _postgresContainer.DisposeAsync().AsTask();
    }
};