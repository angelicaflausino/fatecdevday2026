# Proposal

## Why

O projeto possui apenas o scaffold do backend, sem nenhuma funcionalidade. Para o DevDay é necessário um MVP mínimo e demonstrável de um encurtador de URLs: criar uma URL curta e ser redirecionado para a URL original.

## What Changes

- Novo endpoint `POST /api/urls` que recebe uma URL original e retorna o código curto e a URL curta.
- Novo endpoint `GET /{code}` que redireciona (302) para a URL original, ou retorna 404 se o código não existir.
- Validação da URL de entrada: apenas `http`/`https`, absoluta, com no máximo 2048 caracteres.
- Geração de código aleatório Base62 de 7 caracteres, com nova tentativa em caso de colisão.
- Persistência com Entity Framework Core usando In-Memory Database.
- Testes unitários (casos de uso) e de integração (API) com xUnit.
- Documentação OpenAPI em português brasileiro.

Fora do escopo: contagem de cliques, expiração, alias customizado, listagem, autenticação.

**Desvio consciente da configuração do projeto:** migrations do EF Core e connection string por variável de ambiente ficam fora do MVP, pois o provider InMemory não suporta nenhum dos dois.

## Capabilities

### New Capabilities
- `url-shortening`: criação de URLs curtas a partir de URLs originais, com validação e geração de código único.
- `url-redirection`: resolução de um código curto e redirecionamento para a URL original.

### Modified Capabilities

Nenhuma.

## Impact

- Código: todas as camadas em `backend/src` (Domain, Application, Infrastructure, Api) e `backend/tests`.
- API: dois novos endpoints REST e documentação OpenAPI.
- Dependências: pacote `Microsoft.EntityFrameworkCore.InMemory` e, nos testes, `Microsoft.AspNetCore.Mvc.Testing`. Sem dependências externas de serviços.
- Agente responsável pela implementação: DotNet Developer.
