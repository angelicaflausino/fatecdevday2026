using Microsoft.EntityFrameworkCore;
using UrlShortener.Domain.Entities;
using UrlShortener.Infrastructure.Persistence;
using UrlShortener.Infrastructure.Repositories;
using UrlShortener.Infrastructure.Services;

namespace UrlShortener.Tests.Unit;

public class InfrastructureTests
{
    private static AppDbContext CreateContext() =>
        new(new DbContextOptionsBuilder<AppDbContext>()
            .UseInMemoryDatabase(Guid.NewGuid().ToString())
            .Options);

    [Fact]
    public async Task Repositorio_SalvaEBuscaPorCodigo()
    {
        await using var context = CreateContext();
        var repository = new ShortUrlRepository(context);

        await repository.AddAsync(new ShortUrl { Id = Guid.NewGuid(), Code = "abc1234", OriginalUrl = "https://exemplo.com" }, default);

        Assert.True(await repository.CodeExistsAsync("abc1234", default));
        Assert.False(await repository.CodeExistsAsync("outro12", default));
        var found = await repository.GetByCodeAsync("abc1234", default);
        Assert.Equal("https://exemplo.com", found?.OriginalUrl);
        Assert.Null(await repository.GetByCodeAsync("outro12", default));
    }

    [Fact]
    public void GeradorBase62_GeraCodigoDe7CaracteresAlfanumericos()
    {
        var generator = new Base62CodeGenerator();

        for (var i = 0; i < 100; i++)
        {
            var code = generator.Generate();
            Assert.Equal(Base62CodeGenerator.CodeLength, code.Length);
            Assert.All(code, c => Assert.True(char.IsAsciiLetterOrDigit(c)));
        }
    }
}
