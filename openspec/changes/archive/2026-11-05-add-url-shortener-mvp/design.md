# Design

## Context

O backend em `backend/` já possui a solution com os projetos Api, Application, Domain, Infrastructure e Tests (.NET 10), sem funcionalidades. A configuração do projeto exige Clean Architecture, Controllers derivados de `ControllerBase`, DTOs, injeção de dependência, sem Minimal APIs e sem endpoints no `Program.cs`. Motivação em proposal.md - Why.

## Goals / Non-Goals

**Goals:**
- Entregar os dois endpoints do MVP respeitando as camadas e dependências apontando para dentro (Api e Infrastructure -> Application -> Domain).
- Manter a persistência atrás de uma abstração para permitir trocar o provider depois.

**Non-Goals:**
- Migrations, connection string por variável de ambiente e provider relacional (ver Decisão 5).
- Cache, métricas, rate limiting e autenticação.

## Decisões

1. **Camadas**
   - Domain: entidade `ShortUrl` (`Id`, `Code`, `OriginalUrl`, `CreatedAt`).
   - Application: casos de uso `CreateShortUrl` e `ResolveShortUrl`, contratos `IShortUrlRepository` e `ICodeGenerator`, DTOs de entrada e saída.
   - Infrastructure: `AppDbContext` (EF Core InMemory), `ShortUrlRepository`, `Base62CodeGenerator`, e método de extensão de registro de DI.
   - Api: `UrlsController` (`POST /api/urls`) e `RedirectController` (`GET /{code}`), derivados de `ControllerBase`, com `[ApiController]` e atributos de rota.

2. **Código curto: Base62 aleatório de 7 caracteres, com retry em colisão.** Alternativas: hash da URL (colide e vincula código à URL), sequencial (previsível). Aleatório com `RandomNumberGenerator` evita enumeração trivial; o espaço de 62^7 torna colisões raras, e o índice único na coluna `Code` mais o retry (limite de tentativas, por exemplo 5) garantem unicidade.

3. **Redirect 302.** Alternativa 301 é cacheada pelo navegador, impedindo evoluções futuras como contagem de cliques ou troca de destino.

4. **Validação.** Feita na Api via DataAnnotations no DTO (obrigatório, tamanho máximo 2048) e na Application, que valida URI absoluta com esquema `http`/`https`. Isso mantém a regra mesmo se o caso de uso for chamado fora do controller. Falhas retornam `400` com `ProblemDetails`. Um destino interno (SSRF) não é risco aqui, pois o servidor nunca acessa a URL, apenas redireciona o cliente.

5. **InMemory sem migrations.** O provider InMemory não suporta migrations nem connection string. O MVP usa `UseInMemoryDatabase` com o nome do banco vindo de configuração (`appsettings`), e `EnsureCreated` não é necessário. Isso é um desvio consciente da configuração do projeto, e fica registrado para a futura troca por provider relacional, que reintroduz migrations e connection string por variável de ambiente.

6. **Rota raiz `/{code}`.** Como não há outros endpoints na raiz, `GET /{code}` não conflita com `/api/urls`. O `shortUrl` retornado é montado com o esquema e host da requisição.

7. **Testes.** Unitários dos casos de uso com repositório e gerador substituídos (xUnit). Integração com `WebApplicationFactory`, usando um nome de banco InMemory único por teste para garantir isolamento.

## Risks / Trade-offs

- [Dados perdidos ao reiniciar a aplicação, por ser InMemory] -> Aceitável para o MVP e para o DevDay; documentar na README.
- [Colisão de código sob carga] -> Índice único, retry limitado e erro `500` explícito se esgotar as tentativas.
- [Rota `/{code}` captura qualquer caminho de um segmento] -> Retorna 404 para códigos inexistentes; novos endpoints devem usar prefixo `/api`.
- [Mesma URL gera vários códigos] -> Decisão de simplicidade; deduplicação pode vir depois.
