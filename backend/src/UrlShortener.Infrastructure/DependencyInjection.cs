using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using UrlShortener.Application.Interfaces;
using UrlShortener.Infrastructure.Persistence;
using UrlShortener.Infrastructure.Repositories;
using UrlShortener.Infrastructure.Services;

namespace UrlShortener.Infrastructure;

public static class DependencyInjection
{
    // O provider InMemory não usa connection string; apenas o nome do banco.
    public static IServiceCollection AddInfrastructure(this IServiceCollection services, IConfiguration configuration)
    {
        var databaseName = configuration["Persistence:DatabaseName"] ?? "UrlShortenerDb";

        services.AddDbContext<AppDbContext>(options => options.UseInMemoryDatabase(databaseName));
        services.AddScoped<IShortUrlRepository, ShortUrlRepository>();
        services.AddSingleton<ICodeGenerator, Base62CodeGenerator>();
        return services;
    }
}
