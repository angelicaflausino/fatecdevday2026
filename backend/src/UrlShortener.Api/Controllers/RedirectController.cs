using Microsoft.AspNetCore.Mvc;
using UrlShortener.Application.Interfaces;

namespace UrlShortener.Api.Controllers;

/// <summary>Redirecionamento de URLs curtas.</summary>
[ApiController]
public class RedirectController(IShortUrlService service) : ControllerBase
{
    /// <summary>Redireciona para a URL original associada ao código.</summary>
    /// <response code="302">Redirecionamento para a URL original.</response>
    /// <response code="404">Código inexistente.</response>
    [HttpGet("{code}")]
    [ProducesResponseType(StatusCodes.Status302Found)]
    [ProducesResponseType(StatusCodes.Status404NotFound)]
    public async Task<IActionResult> Resolve(string code, CancellationToken cancellationToken)
    {
        var originalUrl = await service.ResolveAsync(code, cancellationToken);

        return originalUrl is null ? NotFound() : Redirect(originalUrl);
    }
}
