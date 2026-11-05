# Spec Delta

## Purpose
Permitir que um cliente da API crie uma URL curta a partir de uma URL original válida, recebendo um código único para uso posterior.

## ADDED Requirements

### Requirement: Criação de URL curta
O sistema SHALL expor `POST /api/urls` que recebe `originalUrl` e retorna `201 Created` com `code`, `shortUrl` e `originalUrl`. O `code` SHALL ter 7 caracteres alfanuméricos (Base62) e ser único entre as URLs curtas existentes. Cada requisição SHALL gerar um novo código, mesmo para uma URL já encurtada.

#### Scenario: URL válida é encurtada
- **GIVEN** que o cliente envia `originalUrl` igual a `https://exemplo.com/pagina`
- **WHEN** o cliente chama `POST /api/urls`
- **THEN** a resposta é `201 Created`
- **AND** o corpo contém `code` com 7 caracteres Base62, `shortUrl` terminando em `/{code}` e `originalUrl` igual à URL enviada

#### Scenario: Mesma URL enviada duas vezes
- **GIVEN** que `https://exemplo.com/pagina` já foi encurtada
- **WHEN** o cliente chama `POST /api/urls` novamente com a mesma URL
- **THEN** a resposta é `201 Created` com um `code` diferente do primeiro

#### Scenario: Colisão de código
- **GIVEN** que o código gerado já existe
- **WHEN** o cliente chama `POST /api/urls`
- **THEN** o sistema gera outro código até obter um não utilizado
- **AND** a resposta é `201 Created`

### Requirement: Validação da URL original
O sistema SHALL rejeitar com `400 Bad Request` qualquer `originalUrl` ausente, vazia, não absoluta, com esquema diferente de `http` ou `https`, ou com mais de 2048 caracteres.

#### Scenario: URL ausente ou vazia
- **GIVEN** que o cliente envia `originalUrl` ausente ou vazia
- **WHEN** o cliente chama `POST /api/urls`
- **THEN** a resposta é `400 Bad Request`

#### Scenario: Esquema não permitido
- **GIVEN** que o cliente envia `originalUrl` igual a `ftp://exemplo.com/arquivo`
- **WHEN** o cliente chama `POST /api/urls`
- **THEN** a resposta é `400 Bad Request`

#### Scenario: URL relativa
- **GIVEN** que o cliente envia `originalUrl` igual a `/pagina`
- **WHEN** o cliente chama `POST /api/urls`
- **THEN** a resposta é `400 Bad Request`

#### Scenario: URL acima do limite
- **GIVEN** que o cliente envia `originalUrl` com mais de 2048 caracteres
- **WHEN** o cliente chama `POST /api/urls`
- **THEN** a resposta é `400 Bad Request`

### Requirement: Documentação da API
O sistema SHALL publicar a documentação OpenAPI dos endpoints, descrita em português brasileiro.

#### Scenario: Documentação disponível
- **GIVEN** que a aplicação está em execução em ambiente de desenvolvimento
- **WHEN** o cliente acessa o documento OpenAPI
- **THEN** o documento descreve `POST /api/urls` e `GET /{code}` com suas respostas
