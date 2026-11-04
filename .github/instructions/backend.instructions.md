# Backend Instructions — .NET

## 1. Objetivo

Estas instruções definem os padrões obrigatórios para desenvolvimento de aplicações backend utilizando C# e ASP.NET Core.

O Agente deve seguir estas diretrizes durante a criação, manutenção, refatoração e revisão de código.

As decisões arquiteturais devem priorizar:

- Clean Architecture.
- Separation of Concerns.
- Dependency Injection.
- SOLID Principles.
- DRY (Don't Repeat Yourself).
- KISS (Keep It Simple, Stupid).
- Secure by Design.
- Observability.
- Maintainability.
- Testability.

**Regra geral:** não introduzir complexidade arquitetural desnecessária. Priorizar soluções simples, explícitas, testáveis e de fácil manutenção.

---

## 2. Tecnologias e padrões

Utilizar preferencialmente:

- C#.
- ASP.NET Core Web API.
- .NET LTS, respeitando a versão definida no projeto.
- Entity Framework Core.
- FluentValidation.
- Microsoft.Extensions.DependencyInjection.
- Azure Key Vault para gerenciamento de segredos.
- OpenTelemetry para observabilidade.
- Health Checks para monitoramento.
- xUnit para testes automatizados.

Não atualizar versões de dependências ou frameworks sem necessidade e sem avaliar a compatibilidade com o projeto.

---

## 3. Arquitetura — Clean Architecture

A solução deve seguir os princípios de Clean Architecture, mantendo a independência entre as camadas.

### 3.1 Estrutura de projetos

```text
src/
├── MyApplication.Api/
│   ├── Controllers/
│   ├── Middleware/
│   ├── Extensions/
│   ├── Filters/
│   ├── Configuration/
│   └── Program.cs
│
├── MyApplication.Domain/
│   ├── Entities/
│   ├── Enums/
│   ├── ValueObjects/
│   ├── Interfaces/
│   └── Exceptions/
│
├── MyApplication.Application/
│   ├── Interfaces/
│   ├── Services/
│   ├── DTOs/
│   ├── Validators/
│   ├── Mappings/
│   └── Exceptions/
│
└── MyApplication.Infrastructure/
    ├── Persistence/
    │   ├── Context/
    │   ├── Entities/
    │   └── Configurations/
    ├── Repositories/
    ├── Services/
    ├── DependencyInjection.cs
    └── ExternalServices/

tests/
├── MyApplication.UnitTests/
└── MyApplication.IntegrationTests/
```

### 3.2 Responsabilidades das camadas

**API**
- Expor os endpoints HTTP.
- Implementar Controllers.
- Configurar autenticação e autorização.
- Configurar Middlewares.
- Configurar CORS e Rate Limiting.
- Configurar Health Checks.
- Realizar injeção das dependências.
- Converter resultados em respostas HTTP.

**Domain**
- Representar as entidades e regras fundamentais do domínio.
- Definir Value Objects e Enums.
- Definir contratos e abstrações pertencentes ao domínio.
- Não possuir dependências de Infrastructure, API ou frameworks externos.

**Application**
- Implementar os serviços e casos de uso da aplicação.
- Definir interfaces necessárias para acesso a recursos externos.
- Implementar DTOs e Validators.
- Orquestrar as operações de negócio.
- Não depender diretamente de Infrastructure ou API.

**Infrastructure**
- Implementar acesso ao banco de dados.
- Implementar repositórios.
- Implementar integrações externas.
- Implementar serviços de infraestrutura.
- Configurar Entity Framework Core.
- Implementar as interfaces definidas nas camadas internas.

### 3.3 Regras de dependência

As dependências devem sempre apontar para dentro da arquitetura.

- API pode depender de Application e Infrastructure.
- Application pode depender de Domain.
- Infrastructure pode depender de Application e Domain.
- Domain não pode depender de nenhuma camada externa.
- Application não pode depender de Infrastructure.

Não permitir referências circulares entre projetos.

---

## 4. Padrões arquiteturais obrigatórios

### 4.1 Não utilizar CQRS

Não utilizar CQRS (Command Query Responsibility Segregation).

Não implementar:
- Separação de Commands e Queries.
- Command Handlers.
- Query Handlers.
- Mediator Pattern.
- MediatR.
- Pipeline Behaviors.

Utilizar serviços de aplicação convencionais para organizar os casos de uso.

Exemplo:

```csharp
public interface ITicketService
{
    Task<TicketDto?> GetByIdAsync(
        Guid id,
        CancellationToken cancellationToken);

    Task<TicketDto> CreateAsync(
        CreateTicketDto request,
        CancellationToken cancellationToken);
}
```

### 4.2 Dependency Injection

Utilizar Dependency Injection nativa do ASP.NET Core.

- Não utilizar Service Locator.
- Preferir Constructor Injection.
- Registrar dependências por interfaces.
- Respeitar os ciclos de vida Singleton, Scoped e Transient.
- Evitar dependências desnecessárias.
- Centralizar os registros de cada camada em métodos de extensão.

Exemplo:

```csharp
public static class DependencyInjection
{
    public static IServiceCollection AddInfrastructure(
        this IServiceCollection services,
        IConfiguration configuration)
    {
        // Register infrastructure dependencies.

        return services;
    }
}
```

Utilizar registros separados para API, Application e Infrastructure quando necessário.

### 4.3 Repository Pattern

Utilizar Repository Pattern quando houver benefício na abstração do acesso aos dados.

- Definir contratos nas camadas internas.
- Implementar os repositórios em Infrastructure.
- Não expor DbContext diretamente para Controllers.
- Evitar abstrações genéricas desnecessárias.
- Não duplicar funcionalidades já fornecidas pelo Entity Framework Core.

---

## 5. Entity Framework Core — Database First

O acesso ao banco de dados deve utilizar Entity Framework Core com abordagem Database First.

### Regras obrigatórias

- O banco de dados é a fonte de verdade do modelo persistido.
- Gerar entidades e DbContext a partir do schema existente.
- Utilizar Scaffold-DbContext ou dotnet ef dbcontext scaffold.
- Não criar migrations para administrar o schema quando o projeto seguir Database First.
- Não alterar manualmente entidades geradas pelo Scaffold.
- Preservar customizações utilizando arquivos parciais e configurações separadas.
- Manter configurações de mapeamento em arquivos próprios quando necessário.
- Utilizar AsNoTracking() em consultas somente leitura.
- Utilizar consultas assíncronas.
- Utilizar CancellationToken nas operações assíncronas.
- Evitar consultas N+1.
- Projetar resultados com Select() quando não for necessário carregar entidades completas.
- Evitar carregamento desnecessário de relacionamentos.

### Exemplo de Scaffold

```bash
dotnet ef dbcontext scaffold \
  "Name=ConnectionStrings:DefaultConnection" \
  Microsoft.EntityFrameworkCore.SqlServer \
  --output-dir Persistence/Entities \
  --context-dir Persistence/Context \
  --context ApplicationDbContext \
  --no-onconfiguring \
  --force
```

Não armazenar connection strings diretamente no código-fonte.

---

## 6. Validação — FluentValidation

Utilizar FluentValidation para validação de DTOs e dados de entrada.

### Regras

- Criar um Validator para cada DTO que necessite de validação.
- Manter os Validators organizados em Application/Validators.
- Não concentrar regras de validação nos Controllers.
- Não duplicar regras de validação em diferentes camadas.
- Utilizar mensagens de validação claras.
- Validar campos obrigatórios, tamanhos, formatos e intervalos.
- Utilizar validações assíncronas quando houver necessidade de consultar recursos externos.
- Registrar os Validators através de Dependency Injection.

Exemplo:

```csharp
public class CreateTicketValidator
    : AbstractValidator<CreateTicketDto>
{
    public CreateTicketValidator()
    {
        RuleFor(x => x.Title)
            .NotEmpty()
            .MaximumLength(150);

        RuleFor(x => x.Description)
            .NotEmpty()
            .MaximumLength(2000);

        RuleFor(x => x.Priority)
            .IsInEnum();
    }
}
```

As validações devem ser executadas antes da realização das operações de negócio.

---

## 7. Segurança da API

Toda API deve considerar os seguintes requisitos de segurança.

### 7.1 CORS

Configurar Cross-Origin Resource Sharing (CORS).

- Definir origens explicitamente permitidas.
- Não utilizar AllowAnyOrigin() em produção.
- Definir métodos e headers permitidos.
- Não permitir credenciais com origens wildcard.
- Utilizar configurações específicas por ambiente.

### 7.2 Rate Limiting

Implementar Rate Limiting utilizando os recursos nativos do ASP.NET Core.

- Configurar políticas de limitação de requisições.
- Definir limites por endpoint ou grupo de endpoints.
- Considerar políticas por IP ou identidade autenticada.
- Retornar HTTP 429 quando o limite for excedido.
- Configurar políticas específicas para endpoints sensíveis.
- Evitar depender exclusivamente do IP quando a aplicação estiver atrás de proxies ou gateways.

### 7.3 Health Checks

Mapear endpoints de Health Checks.

Implementar, quando aplicável:

- Liveness: verifica se a aplicação está executando.
- Readiness: verifica se a aplicação está apta a receber requisições.
- Database Health Check: verifica conectividade com o banco de dados.
- External Dependencies Health Check: verifica dependências externas críticas.

Não expor informações sensíveis nos endpoints de saúde.

### 7.4 Azure Key Vault

Utilizar Azure Key Vault para armazenamento e recuperação de segredos.

- Não armazenar senhas, tokens ou connection strings sensíveis no código.
- Não versionar arquivos contendo segredos.
- Utilizar Managed Identity sempre que disponível no Azure.
- Aplicar princípio do menor privilégio.
- Configurar acesso ao Key Vault por RBAC.
- Separar segredos por ambiente.
- Evitar registrar segredos nos logs.
- Não utilizar credenciais fixas quando Managed Identity estiver disponível.

A integração deve utilizar as bibliotecas oficiais do Azure Identity e Azure.Extensions.AspNetCore.Configuration.Secrets, quando aplicável.

### 7.5 Autenticação e autorização

Quando aplicável:

- Utilizar autenticação baseada em JWT/OAuth 2.0/OIDC.
- Validar assinatura, issuer, audience e expiração dos tokens.
- Implementar autorização baseada em Policies.
- Aplicar princípio do menor privilégio.
- Não implementar autenticação própria sem necessidade.
- Não confiar em informações de identidade recebidas diretamente do cliente.

### 7.6 Segurança adicional

- Utilizar HTTPS.
- Implementar tratamento global de exceções.
- Utilizar ProblemDetails para respostas de erro padronizadas.
- Não expor StackTrace em produção.
- Evitar exposição de informações internas nos endpoints.
- Validar entradas para prevenir SQL Injection e outras vulnerabilidades.
- Não utilizar interpolação de strings para montar comandos SQL.
- Manter dependências atualizadas conforme política do projeto.

---

## 8. Observabilidade — OpenTelemetry

Utilizar OpenTelemetry SDK para instrumentação e observabilidade da aplicação.

A configuração deve considerar os três pilares:

- Logs.
- Metrics.
- Traces.

### 8.1 Distributed Tracing

Instrumentar:

- Requisições HTTP recebidas.
- Requisições HTTP realizadas para serviços externos.
- Operações de banco de dados.
- Operações relevantes da aplicação.
- Integrações e dependências externas.

Propagar contexto de rastreamento utilizando W3C Trace Context quando aplicável.

### 8.2 Metrics

Coletar métricas relevantes:

- Volume de requisições.
- Latência HTTP.
- Taxa de erros.
- Utilização de recursos.
- Métricas de dependências.
- Métricas específicas do negócio quando necessário.

### 8.3 Logging

Utilizar Microsoft.Extensions.Logging integrado ao OpenTelemetry.

- Preferir logs estruturados.
- Utilizar níveis adequados: Trace, Debug, Information, Warning, Error e Critical.
- Incluir TraceId e SpanId quando disponíveis.
- Evitar logs excessivos.
- Não registrar senhas, tokens, dados pessoais sensíveis ou informações confidenciais.
- Registrar exceções preservando informações úteis para diagnóstico.

### 8.4 Exportação

Configurar exporters conforme o ambiente e a infraestrutura disponível.

Priorizar integração com:

- Azure Monitor.
- Application Insights.
- OpenTelemetry Collector.

Não acoplar a implementação de negócio a um fornecedor específico de observabilidade.

---

## 9. API Design

### 9.1 Controllers

- Utilizar Controllers para exposição dos endpoints.
- Manter Controllers pequenos.
- Não implementar regras de negócio nos Controllers.
- Delegar operações para os serviços de Core.
- Utilizar DTOs para entrada e saída.
- Utilizar CancellationToken.
- Retornar os códigos HTTP apropriados.

### 9.2 HTTP Status Codes

Utilizar corretamente:

| Código | Utilização |
|---|---|
| 200 | Operação executada com sucesso |
| 201 | Recurso criado |
| 202 | Solicitação aceita para processamento |
| 204 | Operação executada sem conteúdo de retorno |
| 400 | Requisição inválida |
| 401 | Não autenticado |
| 403 | Sem autorização |
| 404 | Recurso não encontrado |
| 409 | Conflito de negócio |
| 422 | Erro de validação, quando adotado pelo contrato |
| 429 | Limite de requisições excedido |
| 500 | Erro interno |

### 9.3 DTOs

- Não expor entidades do Entity Framework diretamente.
- Criar DTOs específicos para requests e responses.
- Evitar DTOs excessivamente genéricos.
- Não retornar informações internas desnecessárias.
- Evitar propriedades que não fazem parte do contrato da API.

### 9.4 API Versioning

Quando necessário, utilizar versionamento explícito da API.

Evitar alterações incompatíveis em contratos existentes sem estratégia de versionamento.

---

## 10. Tratamento de exceções

Implementar tratamento global de exceções.

- Utilizar middleware ou Exception Handler nativo.
- Padronizar respostas com ProblemDetails.
- Diferenciar exceções de negócio de erros inesperados.
- Não utilizar exceções para controlar fluxos normais da aplicação.
- Não retornar mensagens internas de infraestrutura ao consumidor.
- Registrar erros com contexto suficiente para diagnóstico.

---

## 11. Testes automatizados

Utilizar xUnit como framework de testes.

### Unit Tests

Testar:

- Serviços de aplicação.
- Regras de negócio.
- Validadores.
- Tratamento de exceções.
- Comportamentos e cenários de sucesso e falha.

### Integration Tests

Testar:

- Endpoints HTTP.
- Integração com banco de dados.
- Configurações de Dependency Injection.
- Middlewares.
- Autenticação e autorização.
- Health Checks.

### Regras

- Não testar detalhes internos sem relevância funcional.
- Evitar dependências de infraestrutura real nos testes unitários.
- Utilizar ferramentas apropriadas para isolar dependências.
- Garantir cobertura dos principais cenários de negócio.
- Não considerar cobertura de código como único indicador de qualidade.

---

## 12. Boas práticas de desenvolvimento

O código deve seguir estas diretrizes:

- Utilizar nomes claros e descritivos.
- Preferir métodos pequenos e com responsabilidade única.
- Evitar classes excessivamente grandes.
- Utilizar async/await em operações assíncronas.
- Evitar `.Result` e `.Wait()`.
- Evitar métodos estáticos para lógica que dependa de serviços.
- Evitar código duplicado.
- Utilizar CancellationToken nas operações assíncronas.
- Evitar comentários que apenas repetem o código.
- Documentar decisões arquiteturais relevantes.
- Utilizar nullable reference types.
- Tratar corretamente valores nulos.
- Preferir tipos específicos em vez de object ou dynamic.
- Não introduzir abstrações sem necessidade.

---

## 13. Regras de atuação do Agente

Durante qualquer atividade de desenvolvimento, o Agente deve:

1. Analisar a estrutura existente antes de propor alterações.
2. Respeitar a arquitetura e os padrões já estabelecidos.
3. Consultar as especificações e decisões técnicas existentes.
4. Reutilizar componentes e abstrações existentes.
5. Não criar novos projetos ou camadas sem justificativa.
6. Não introduzir CQRS, MediatR ou padrões não solicitados.
7. Não modificar entidades geradas pelo Database First manualmente.
8. Não adicionar dependências sem justificar sua necessidade.
9. Não alterar versões de pacotes sem autorização.
10. Criar ou atualizar testes para novas funcionalidades.
11. Validar compilação e testes após as alterações.
12. Documentar decisões técnicas relevantes.

### Antes de implementar

O Agente deve:

- Identificar os projetos envolvidos.
- Identificar as dependências entre camadas.
- Verificar padrões existentes.
- Analisar os contratos e entidades envolvidos.
- Identificar impactos em segurança e observabilidade.

### Durante a implementação

O Agente deve:

- Implementar somente o escopo solicitado.
- Seguir as especificações aprovadas.
- Preservar compatibilidade com funcionalidades existentes.
- Evitar refatorações não relacionadas à tarefa.
- Não assumir requisitos não documentados.

### Após a implementação

O Agente deve:

- Executar build.
- Executar testes automatizados.
- Verificar erros de compilação.
- Verificar aderência à Clean Architecture.
- Verificar validações e tratamento de exceções.
- Verificar requisitos de segurança.
- Apresentar um resumo das alterações.
- Informar eventuais limitações ou pendências.

---

## 14. Critérios de aceite

Uma implementação somente deve ser considerada concluída quando:

- [ ] A arquitetura Clean Architecture foi respeitada.
- [ ] As dependências entre camadas estão corretas.
- [ ] Não foi introduzido CQRS ou MediatR.
- [ ] A injeção de dependência está configurada corretamente.
- [ ] O acesso ao banco respeita Database First.
- [ ] As validações utilizam FluentValidation.
- [ ] Os DTOs estão separados das entidades de persistência.
- [ ] As configurações de segurança foram consideradas.
- [ ] Os Health Checks estão mapeados.
- [ ] A instrumentação OpenTelemetry está configurada.
- [ ] Os segredos não estão expostos no código.
- [ ] Os testes automatizados foram implementados.
- [ ] O projeto compila sem erros.
- [ ] A implementação atende à especificação aprovada.

**Diretriz final:** o Agente deve atuar como assistente de engenharia de software, respeitando as decisões arquiteturais e os padrões estabelecidos neste documento. Em caso de conflito entre uma solicitação e estas instruções, deve identificar o conflito e solicitar esclarecimento antes de introduzir uma mudança arquitetural.