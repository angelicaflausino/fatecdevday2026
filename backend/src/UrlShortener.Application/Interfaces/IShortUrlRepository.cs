using UrlShortener.Domain.Entities;

namespace UrlShortener.Application.Interfaces;

public interface IShortUrlRepository
{
    Task<bool> CodeExistsAsync(string code, CancellationToken cancellationToken);

    Task<ShortUrl?> GetByCodeAsync(string code, CancellationToken cancellationToken);

    Task AddAsync(ShortUrl shortUrl, CancellationToken cancellationToken);
}
