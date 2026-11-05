using FluentValidation;
using UrlShortener.Application.Interfaces;
using UrlShortener.Domain.Entities;

namespace UrlShortener.Application.Services;

public class ShortUrlService(
    IShortUrlRepository repository,
    ICodeGenerator codeGenerator,
    IValidator<CreateShortUrlDto> validator) : IShortUrlService
{
    public const int MaxCodeAttempts = 5;

    public async Task<ShortUrlDto> CreateAsync(CreateShortUrlDto request, CancellationToken cancellationToken)
    {
        await validator.ValidateAndThrowAsync(request, cancellationToken);

        var code = await GenerateUniqueCodeAsync(cancellationToken);
        var shortUrl = new ShortUrl
        {
            Id = Guid.NewGuid(),
            Code = code,
            OriginalUrl = request.OriginalUrl!,
            CreatedAt = DateTime.UtcNow
        };

        await repository.AddAsync(shortUrl, cancellationToken);
        return new ShortUrlDto(shortUrl.Code, shortUrl.OriginalUrl);
    }

    public async Task<string?> ResolveAsync(string code, CancellationToken cancellationToken)
    {
        var shortUrl = await repository.GetByCodeAsync(code, cancellationToken);
        return shortUrl?.OriginalUrl;
    }

    private async Task<string> GenerateUniqueCodeAsync(CancellationToken cancellationToken)
    {
        for (var attempt = 0; attempt < MaxCodeAttempts; attempt++)
        {
            var code = codeGenerator.Generate();
            if (!await repository.CodeExistsAsync(code, cancellationToken))
            {
                return code;
            }
        }

        throw new InvalidOperationException("Não foi possível gerar um código único.");
    }
}
