using FluentValidation;

namespace UrlShortener.Application.Validators;

public class CreateShortUrlValidator : AbstractValidator<CreateShortUrlDto>
{
    public const int MaxUrlLength = 2048;

    public CreateShortUrlValidator()
    {
        RuleFor(x => x.OriginalUrl)
            .NotEmpty().WithMessage("A URL original é obrigatória.")
            .MaximumLength(MaxUrlLength).WithMessage($"A URL original deve ter no máximo {MaxUrlLength} caracteres.")
            .Must(BeAbsoluteHttpUrl).WithMessage("A URL original deve ser absoluta e usar http ou https.");
    }

    private static bool BeAbsoluteHttpUrl(string? url) =>
        Uri.TryCreate(url, UriKind.Absolute, out var uri)
        && (uri.Scheme == Uri.UriSchemeHttp || uri.Scheme == Uri.UriSchemeHttps);
}
