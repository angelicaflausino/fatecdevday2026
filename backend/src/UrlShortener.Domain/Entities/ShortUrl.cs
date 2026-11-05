namespace UrlShortener.Domain.Entities;

public class ShortUrl
{
    public Guid Id { get; set; }
    public string Code { get; set; } = string.Empty;
    public string OriginalUrl { get; set; } = string.Empty;
    public DateTime CreatedAt { get; set; }
}
