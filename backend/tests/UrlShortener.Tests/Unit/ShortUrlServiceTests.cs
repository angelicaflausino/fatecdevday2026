using FluentValidation;
using UrlShortener.Application;
using UrlShortener.Application.Interfaces;
using UrlShortener.Application.Services;
using UrlShortener.Application.Validators;
using UrlShortener.Domain.Entities;

namespace UrlShortener.Tests.Unit;

public class ShortUrlServiceTests
{
    private sealed class FakeRepository : IShortUrlRepository
    {
        public List<ShortUrl> Items { get; } = [];

        public Task<bool> CodeExistsAsync(string code, CancellationToken cancellationToken) =>
            Task.FromResult(Items.Any(x => x.Code == code));

        public Task<ShortUrl?> GetByCodeAsync(string code, CancellationToken cancellationToken) =>
            Task.FromResult(Items.FirstOrDefault(x => x.Code == code));

        public Task AddAsync(ShortUrl shortUrl, CancellationToken cancellationToken)
        {
            Items.Add(shortUrl);
            return Task.CompletedTask;
        }
    }

    private sealed class SequenceCodeGenerator(params string[] codes) : ICodeGenerator
    {
        private int _next;
        public string Generate() => codes[Math.Min(_next++, codes.Length - 1)];
    }

    private static ShortUrlService CreateService(FakeRepository repository, ICodeGenerator generator) =>
        new(repository, generator, new CreateShortUrlValidator());

    [Fact]
    public async Task CreateAsync_UrlValida_PersisteERetornaCodigo()
    {
        var repository = new FakeRepository();
        var service = CreateService(repository, new SequenceCodeGenerator("abc1234"));

        var result = await service.CreateAsync(new CreateShortUrlDto("https://exemplo.com/pagina"), default);

        Assert.Equal("abc1234", result.Code);
        Assert.Equal("https://exemplo.com/pagina", result.OriginalUrl);
        Assert.Single(repository.Items);
    }

    [Fact]
    public async Task CreateAsync_MesmaUrlDuasVezes_GeraCodigosDiferentes()
    {
        var repository = new FakeRepository();
        var service = CreateService(repository, new SequenceCodeGenerator("aaaaaaa", "bbbbbbb"));
        var request = new CreateShortUrlDto("https://exemplo.com/pagina");

        var first = await service.CreateAsync(request, default);
        var second = await service.CreateAsync(request, default);

        Assert.NotEqual(first.Code, second.Code);
        Assert.Equal(2, repository.Items.Count);
    }

    [Fact]
    public async Task CreateAsync_ColisaoDeCodigo_GeraOutroCodigo()
    {
        var repository = new FakeRepository();
        repository.Items.Add(new ShortUrl { Code = "colidiu", OriginalUrl = "https://outra.com" });
        var service = CreateService(repository, new SequenceCodeGenerator("colidiu", "novo123"));

        var result = await service.CreateAsync(new CreateShortUrlDto("https://exemplo.com"), default);

        Assert.Equal("novo123", result.Code);
    }

    [Fact]
    public async Task CreateAsync_ColisoesEsgotamTentativas_LancaExcecao()
    {
        var repository = new FakeRepository();
        repository.Items.Add(new ShortUrl { Code = "colidiu", OriginalUrl = "https://outra.com" });
        var service = CreateService(repository, new SequenceCodeGenerator("colidiu"));

        await Assert.ThrowsAsync<InvalidOperationException>(() =>
            service.CreateAsync(new CreateShortUrlDto("https://exemplo.com"), default));
    }

    [Theory]
    [InlineData(null)]
    [InlineData("")]
    [InlineData("ftp://exemplo.com/arquivo")]
    [InlineData("/pagina")]
    public async Task CreateAsync_UrlInvalida_LancaValidationException(string? url)
    {
        var repository = new FakeRepository();
        var service = CreateService(repository, new SequenceCodeGenerator("abc1234"));

        await Assert.ThrowsAsync<ValidationException>(() => service.CreateAsync(new CreateShortUrlDto(url), default));
        Assert.Empty(repository.Items);
    }

    [Fact]
    public async Task CreateAsync_UrlAcimaDoLimite_LancaValidationException()
    {
        var service = CreateService(new FakeRepository(), new SequenceCodeGenerator("abc1234"));
        var url = "https://exemplo.com/" + new string('a', CreateShortUrlValidator.MaxUrlLength);

        await Assert.ThrowsAsync<ValidationException>(() => service.CreateAsync(new CreateShortUrlDto(url), default));
    }

    [Fact]
    public async Task ResolveAsync_CodigoExistente_RetornaUrlOriginal()
    {
        var repository = new FakeRepository();
        repository.Items.Add(new ShortUrl { Code = "aB3dE9x", OriginalUrl = "https://exemplo.com/pagina" });
        var service = CreateService(repository, new SequenceCodeGenerator("abc1234"));

        var result = await service.ResolveAsync("aB3dE9x", default);

        Assert.Equal("https://exemplo.com/pagina", result);
    }

    [Fact]
    public async Task ResolveAsync_CodigoInexistente_RetornaNulo()
    {
        var service = CreateService(new FakeRepository(), new SequenceCodeGenerator("abc1234"));

        Assert.Null(await service.ResolveAsync("naoexis", default));
    }
}
