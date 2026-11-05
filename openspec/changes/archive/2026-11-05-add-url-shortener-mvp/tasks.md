# Tasks

## 1. Setup e limpeza do scaffold

- [x] 1.1 Adicionar referências entre projetos (Api -> Application, Infrastructure; Infrastructure -> Application; Application -> Domain) e verificar que `dotnet build backend/UrlShortener.slnx` compila.
- [x] 1.2 Adicionar o pacote `Microsoft.EntityFrameworkCore.InMemory` em Infrastructure e `Microsoft.AspNetCore.Mvc.Testing` em Tests; verificar que `dotnet restore` conclui sem erros.
- [x] 1.3 Remover os `Class1.cs` e `UnitTest1.cs` e o endpoint `/weatherforecast` (Minimal API) do `Program.cs`, mantendo apenas configuração e inicialização; verificar que `Program.cs` não contém `MapGet`/`MapPost`.

## 2. Domain e Application (casos de uso)

- [x] 2.1 Criar a entidade `ShortUrl` (`Id`, `Code`, `OriginalUrl`, `CreatedAt`) em Domain; verificar que o projeto compila.
- [x] 2.2 Criar em Application os contratos `IShortUrlRepository` e `ICodeGenerator` e os DTOs de entrada e saída de criação; verificar que o projeto compila.
- [x] 2.3 Implementar o caso de uso de criação com validação (URL absoluta, esquema http/https, máximo 2048 caracteres) e retry de colisão com limite de tentativas; verificar com testes unitários xUnit cobrindo URL válida, mesma URL duas vezes, colisão, URL vazia, esquema ftp, URL relativa e URL acima do limite.
- [x] 2.4 Implementar o caso de uso de resolução de código (retorna a URL original ou indica não encontrado); verificar com testes unitários para código existente e inexistente.

## 3. Infrastructure (persistência e geração de código)

- [x] 3.1 Criar `AppDbContext` com índice único em `Code` e o `ShortUrlRepository`; verificar com teste que salva e busca por código usando banco InMemory com nome único por teste.
- [x] 3.2 Implementar `Base62CodeGenerator` (7 caracteres, `RandomNumberGenerator`); verificar com teste de tamanho 7 e alfabeto Base62.
- [x] 3.3 Criar o método de extensão de registro de DI (nome do banco InMemory vindo de configuração); verificar que a aplicação resolve os serviços ao iniciar.

## 4. Api (Controllers e documentação)

- [x] 4.1 Criar `UrlsController` (`POST /api/urls`, `ControllerBase`, `[ApiController]`) retornando 201 com `code`, `shortUrl`, `originalUrl` e 400 com `ProblemDetails` em URL inválida; verificar com testes de integração.
- [x] 4.2 Criar `RedirectController` (`GET /{code}`) retornando 302 com `Location` ou 404; verificar com testes de integração, incluindo que o status é 302 e não 301.
- [x] 4.3 Registrar Controllers, DI e OpenAPI no `Program.cs` e documentar endpoints em português brasileiro (comentários XML/atributos de produces); verificar que o documento OpenAPI descreve `POST /api/urls` e `GET /{code}`.
- [x] 4.4 Atualizar `UrlShortener.Api.http` com exemplos dos dois endpoints; verificar que as chamadas funcionam com a API em execução.

## 5. Verificação final

- [x] 5.1 Executar `dotnet test backend/UrlShortener.slnx` e verificar que todos os testes passam, com isolamento entre testes (banco InMemory único por teste).
- [x] 5.2 Executar a API, encurtar uma URL e abrir o `shortUrl` retornado, verificando o redirecionamento para a URL original.
- [x] 5.3 Registrar na README do repositório como executar e testar, e o desvio de migrations e connection string; verificar que os comandos descritos funcionam como escritos.
