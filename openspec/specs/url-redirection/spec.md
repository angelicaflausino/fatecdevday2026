# url-redirection Specification

## Purpose
Permitir que qualquer cliente acesse uma URL curta e seja redirecionado para a URL original associada ao código.

## Requirements

### Requirement: Redirecionamento por código curto
O sistema SHALL expor `GET /{code}` que responde `302 Found` com o cabeçalho `Location` igual à URL original associada ao código. Se o código não existir, o sistema SHALL responder `404 Not Found`.

#### Scenario: Código existente
- **GIVEN** que existe uma URL curta com `code` `aB3dE9x` para `https://exemplo.com/pagina`
- **WHEN** o cliente chama `GET /aB3dE9x`
- **THEN** a resposta é `302 Found`
- **AND** o cabeçalho `Location` é `https://exemplo.com/pagina`

#### Scenario: Código inexistente
- **GIVEN** que não existe URL curta com o código `naoexis`
- **WHEN** o cliente chama `GET /naoexis`
- **THEN** a resposta é `404 Not Found`

#### Scenario: Redirecionamento não é cacheado de forma permanente
- **GIVEN** que existe uma URL curta válida
- **WHEN** o cliente chama `GET /{code}`
- **THEN** o status é `302` e não `301`
