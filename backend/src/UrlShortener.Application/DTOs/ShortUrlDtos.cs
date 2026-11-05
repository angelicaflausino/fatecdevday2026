namespace UrlShortener.Application;

public record CreateShortUrlDto(string? OriginalUrl);

public record ShortUrlDto(string Code, string OriginalUrl);
