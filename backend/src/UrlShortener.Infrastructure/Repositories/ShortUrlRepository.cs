using Microsoft.EntityFrameworkCore;
using UrlShortener.Application.Interfaces;
using UrlShortener.Domain.Entities;
using UrlShortener.Infrastructure.Persistence;

namespace UrlShortener.Infrastructure.Repositories;

public class ShortUrlRepository(AppDbContext context) : IShortUrlRepository
{
    public Task<bool> CodeExistsAsync(string code, CancellationToken cancellationToken) =>
        context.ShortUrls.AsNoTracking().AnyAsync(x => x.Code == code, cancellationToken);

    public Task<ShortUrl?> GetByCodeAsync(string code, CancellationToken cancellationToken) =>
        context.ShortUrls.AsNoTracking().FirstOrDefaultAsync(x => x.Code == code, cancellationToken);

    public async Task AddAsync(ShortUrl shortUrl, CancellationToken cancellationToken)
    {
        context.ShortUrls.Add(shortUrl);
        await context.SaveChangesAsync(cancellationToken);
    }
}
