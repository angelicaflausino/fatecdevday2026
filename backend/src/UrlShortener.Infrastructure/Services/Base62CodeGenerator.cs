using System.Security.Cryptography;
using UrlShortener.Application.Interfaces;

namespace UrlShortener.Infrastructure.Services;

public class Base62CodeGenerator : ICodeGenerator
{
    public const int CodeLength = 7;
    private const string Alphabet = "0123456789ABCDEFGHIJKLMNOPQRSTUVWXYZabcdefghijklmnopqrstuvwxyz";

    public string Generate() => string.Create(CodeLength, 0, static (span, _) =>
    {
        for (var i = 0; i < span.Length; i++)
        {
            span[i] = Alphabet[RandomNumberGenerator.GetInt32(Alphabet.Length)];
        }
    });
}
