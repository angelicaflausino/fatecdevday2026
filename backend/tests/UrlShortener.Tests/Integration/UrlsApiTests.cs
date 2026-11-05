using System.Net;
using System.Net.Http.Json;
using Microsoft.AspNetCore.Mvc.Testing;
using UrlShortener.Api.Controllers;

namespace UrlShortener.Tests.Integration;

public class UrlsApiTests : IDisposable
{
    private readonly ApiFactory _factory = new();
    private readonly HttpClient _client;

    public UrlsApiTests()
    {
        _client = _factory.CreateClient(new WebApplicationFactoryClientOptions { AllowAutoRedirect = false });
    }

    public void Dispose()
    {
        _client.Dispose();
        _factory.Dispose();
    }

    private Task<HttpResponseMessage> PostAsync(string? originalUrl) =>
        _client.PostAsJsonAsync("/api/urls", new { originalUrl });

    [Fact]
    public async Task Post_UrlValida_Retorna201ComCodigo()
    {
        var response = await PostAsync("https://exemplo.com/pagina");

        Assert.Equal(HttpStatusCode.Created, response.StatusCode);
        var body = await response.Content.ReadFromJsonAsync<CreateShortUrlResponse>();
        Assert.NotNull(body);
        Assert.Equal(7, body.Code.Length);
        Assert.EndsWith("/" + body.Code, body.ShortUrl);
        Assert.Equal("https://exemplo.com/pagina", body.OriginalUrl);
    }

    [Fact]
    public async Task Post_MesmaUrlDuasVezes_RetornaCodigosDiferentes()
    {
        var first = await (await PostAsync("https://exemplo.com/pagina")).Content.ReadFromJsonAsync<CreateShortUrlResponse>();
        var second = await (await PostAsync("https://exemplo.com/pagina")).Content.ReadFromJsonAsync<CreateShortUrlResponse>();

        Assert.NotEqual(first!.Code, second!.Code);
    }

    [Theory]
    [InlineData(null)]
    [InlineData("")]
    [InlineData("ftp://exemplo.com/arquivo")]
    [InlineData("/pagina")]
    public async Task Post_UrlInvalida_Retorna400(string? url)
    {
        var response = await PostAsync(url);

        Assert.Equal(HttpStatusCode.BadRequest, response.StatusCode);
    }

    [Fact]
    public async Task Post_UrlAcimaDoLimite_Retorna400()
    {
        var response = await PostAsync("https://exemplo.com/" + new string('a', 2048));

        Assert.Equal(HttpStatusCode.BadRequest, response.StatusCode);
    }

    [Fact]
    public async Task Get_CodigoExistente_Retorna302ComLocation()
    {
        var created = await (await PostAsync("https://exemplo.com/pagina")).Content.ReadFromJsonAsync<CreateShortUrlResponse>();

        var response = await _client.GetAsync("/" + created!.Code);

        Assert.Equal(HttpStatusCode.Found, response.StatusCode);
        Assert.Equal("https://exemplo.com/pagina", response.Headers.Location?.ToString());
    }

    [Fact]
    public async Task Get_CodigoInexistente_Retorna404()
    {
        var response = await _client.GetAsync("/naoexis");

        Assert.Equal(HttpStatusCode.NotFound, response.StatusCode);
    }

    [Fact]
    public async Task Get_BancosIsoladosEntreFactories()
    {
        var created = await (await PostAsync("https://exemplo.com/pagina")).Content.ReadFromJsonAsync<CreateShortUrlResponse>();

        using var otherFactory = new ApiFactory();
        using var otherClient = otherFactory.CreateClient(new WebApplicationFactoryClientOptions { AllowAutoRedirect = false });
        var response = await otherClient.GetAsync("/" + created!.Code);

        Assert.Equal(HttpStatusCode.NotFound, response.StatusCode);
    }
}
