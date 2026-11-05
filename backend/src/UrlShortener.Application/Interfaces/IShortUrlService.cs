namespace UrlShortener.Application.Interfaces;

public interface IShortUrlService
{
    Task<ShortUrlDto> CreateAsync(CreateShortUrlDto request, CancellationToken cancellationToken);

    /// <summary>Retorna a URL original do código, ou null se o código não existir.</summary>
    Task<string?> ResolveAsync(string code, CancellationToken cancellationToken);
}
