using Microsoft.AspNetCore.Mvc;
using UrlShortener.Application;
using UrlShortener.Application.Interfaces;

namespace UrlShortener.Api.Controllers;

/// <summary>Criação de URLs curtas.</summary>
[ApiController]
[Route("api/urls")]
public class UrlsController(IShortUrlService service) : ControllerBase
{
    /// <summary>Cria uma URL curta a partir de uma URL original.</summary>
    /// <response code="201">URL curta criada.</response>
    /// <response code="400">URL original ausente ou inválida.</response>
    [HttpPost]
    [ProducesResponseType<CreateShortUrlResponse>(StatusCodes.Status201Created)]
    [ProducesResponseType<ValidationProblemDetails>(StatusCodes.Status400BadRequest)]
    public async Task<IActionResult> Create(
        [FromBody] CreateShortUrlDto request,
        CancellationToken cancellationToken)
    {
        var created = await service.CreateAsync(request, cancellationToken);
        var shortUrl = $"{Request.Scheme}://{Request.Host}/{created.Code}";

        return Created(shortUrl, new CreateShortUrlResponse(created.Code, shortUrl, created.OriginalUrl));
    }
}

/// <summary>Resposta da criação de URL curta.</summary>
public record CreateShortUrlResponse(string Code, string ShortUrl, string OriginalUrl);
