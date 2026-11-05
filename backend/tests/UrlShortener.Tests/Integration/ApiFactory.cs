using Microsoft.AspNetCore.Hosting;
using Microsoft.AspNetCore.Mvc.Testing;
using Microsoft.AspNetCore.TestHost;

namespace UrlShortener.Tests.Integration;

// Cada instância usa um banco InMemory próprio, garantindo isolamento entre testes.
public class ApiFactory : WebApplicationFactory<Program>
{
    protected override void ConfigureWebHost(IWebHostBuilder builder) =>
        builder.UseSetting("Persistence:DatabaseName", Guid.NewGuid().ToString());
}
