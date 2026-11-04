# Frontend Instructions — Angular

## 1. Objetivo

Estas instruções definem os padrões obrigatórios para desenvolvimento de aplicações frontend utilizando Angular e TypeScript.

O Agente deve seguir estas diretrizes durante a criação, manutenção, refatoração e revisão de código.

As decisões de implementação devem priorizar:

- Component-Based Architecture.
- Separation of Concerns.
- Dependency Injection.
- SOLID Principles.
- DRY (Don't Repeat Yourself).
- KISS (Keep It Simple, Stupid).
- Reusability.
- Maintainability.
- Accessibility.
- Responsive Design.
- Performance.
- Security by Design.

**Regra geral:** priorizar soluções simples, componentes reutilizáveis, código tipado e separação clara de responsabilidades. Não introduzir complexidade desnecessária.

---

## 2. Tecnologias e padrões

Utilizar preferencialmente:

- Angular 21 ou versão definida pelo projeto.
- TypeScript com strict mode habilitado.
- HTML5 semântico.
- Tailwind CSS para estilização.
- RxJS para operações assíncronas e fluxos de dados.
- Angular Signals para gerenciamento de estado reativo.
- Angular Router para navegação.
- Angular HttpClient para comunicação HTTP.
- Reactive Forms para formulários.
- Vitest para testes unitários em novos projetos Angular, respeitando o executor já configurado no projeto.

### Regras gerais

- Priorizar APIs modernas e estáveis do Angular.
- Utilizar componentes standalone.
- Utilizar recursos nativos do Angular antes de adicionar bibliotecas externas.
- Não introduzir bibliotecas de UI sem necessidade ou autorização.
- Não atualizar versões de dependências sem avaliar os impactos.
- Respeitar a estrutura e as configurações existentes do projeto.
- Não utilizar JavaScript puro quando houver solução adequada em Angular e TypeScript.

---

## 3. Arquitetura e organização de pastas

Adotar arquitetura organizada por funcionalidades (Feature-Based Architecture).

Cada funcionalidade deve concentrar seus componentes, serviços, modelos e demais recursos relacionados.

### 3.1 Estrutura de diretórios

```text
src/frontend/
│
├── src/
│   ├── app/
│   │   ├── core/
│   │   │   ├── auth/
│   │   │   ├── guards/
│   │   │   ├── interceptors/
│   │   │   └── services/
│   │   │
│   │   ├── shared/
│   │   │   ├── components/
│   │   │   ├── directives/
│   │   │   ├── pipes/
│   │   │   └── models/
│   │   │
│   │   ├── features/
│   │   │   ├── tickets/
│   │   │   │   ├── components/
│   │   │   │   ├── pages/
│   │   │   │   ├── services/
│   │   │   │   ├── models/
│   │   │   │   └── tickets.routes.ts
│   │   │   │
│   │   │   └── dashboard/
│   │   │       ├── components/
│   │   │       ├── pages/
│   │   │       ├── services/
│   │   │       ├── models/
│   │   │       └── dashboard.routes.ts
│   │   │
│   │   ├── layout/
│   │   │   ├── components/
│   │   │   └── layouts/
│   │   │
│   │   ├── app.component.ts
│   │   ├── app.config.ts
│   │   └── app.routes.ts
│   │
│   ├── assets/
│   ├── environments/
│   ├── styles.css
│   └── index.html
│
├── angular.json
├── package.json
├── tsconfig.json
└── README.md
```

A estrutura deve ser adaptada ao tamanho e à complexidade do projeto. Não criar diretórios vazios ou camadas desnecessárias.

### 3.2 Responsabilidades

**Core**

Concentra recursos globais e serviços de infraestrutura da aplicação.

Exemplos:
- Autenticação.
- Autorização.
- HTTP Interceptors.
- Route Guards.
- Configurações globais.
- Serviços compartilhados de aplicação.

**Shared**

Concentra componentes e recursos reutilizáveis que não pertencem a uma funcionalidade específica.

Exemplos:
- Botões.
- Modais.
- Tabelas.
- Paginação.
- Componentes de formulário.
- Pipes.
- Directives.

Não colocar regras de negócio específicas de funcionalidades dentro de Shared.

**Features**

Concentra as funcionalidades do sistema.

Cada funcionalidade deve possuir seus próprios componentes, páginas, serviços e modelos.

Exemplos:
- Tickets.
- Users.
- Dashboard.
- Reports.

**Layout**

Concentra os componentes estruturais da aplicação.

Exemplos:
- Header.
- Sidebar.
- Navigation.
- Main Layout.
- Authentication Layout.

---

## 4. Componentes Angular

### 4.1 Standalone Components

Utilizar standalone components.

Não utilizar NgModules para organizar novas funcionalidades.

Cada componente deve declarar explicitamente suas dependências através de imports.

### 4.2 Responsabilidade dos componentes

Os componentes devem ser pequenos e possuir responsabilidades bem definidas.

Preferir separar:

- Page Components: responsáveis por compor páginas e coordenar funcionalidades.
- Presentation Components: responsáveis por apresentar informações e receber interações.
- Shared Components: componentes genéricos e reutilizáveis.

Não implementar regras complexas de negócio diretamente nos componentes.

Delegar operações e regras de aplicação para serviços apropriados.

### 4.3 Componentes reutilizáveis

Antes de criar um novo componente, verificar se existe algum componente que possa ser reutilizado.

Evitar:
- Duplicação de componentes.
- Componentes excessivamente genéricos.
- Componentes com muitas responsabilidades.
- Dependências desnecessárias entre componentes.

### 4.4 Comunicação entre componentes

Utilizar os mecanismos nativos do Angular:

- Inputs para recebimento de dados.
- Outputs para comunicação de eventos.
- Signals para estado reativo.
- Services compartilhados quando houver necessidade de compartilhar estado entre componentes não relacionados.

Em novos componentes, preferir as APIs modernas `input()` e `output()` quando compatíveis com o padrão existente.

Evitar manipulação direta de componentes filhos através de referências quando houver alternativas mais simples.

### 4.5 Change Detection

Priorizar ChangeDetectionStrategy.OnPush para os componentes.

Utilizar Signals e referências imutáveis para facilitar a atualização eficiente da interface.

Evitar chamadas de funções custosas diretamente nos templates.

---

## 5. TypeScript

O desenvolvimento deve utilizar TypeScript de maneira estritamente tipada.

### Regras obrigatórias

- Manter strict mode habilitado.
- Evitar utilização de `any`.
- Evitar type assertions desnecessárias.
- Utilizar interfaces e types para definir contratos.
- Utilizar enums ou união de tipos quando apropriado.
- Tratar valores opcionais e nulos explicitamente.
- Utilizar readonly quando os dados não devem ser modificados.
- Evitar duplicação de definições de tipos.
- Não utilizar `!` para ignorar verificações de nullability sem justificativa.
- Preferir funções pequenas e com responsabilidades específicas.

### Exemplo

```typescript
export interface Ticket {
  readonly id: string;
  title: string;
  description: string;
  priority: TicketPriority;
  status: TicketStatus;
}

export type TicketPriority =
  | 'Low'
  | 'Medium'
  | 'High'
  | 'Critical';

export type TicketStatus =
  | 'Open'
  | 'InProgress'
  | 'Resolved'
  | 'Closed';
```

Não utilizar objetos sem tipagem para representar entidades e contratos da aplicação.

---

## 6. Dependency Injection

Utilizar o sistema nativo de Dependency Injection do Angular.

### Regras

- Preferir a função `inject()` nos novos componentes e serviços.
- Utilizar services para encapsular operações compartilhadas.
- Definir o escopo adequado dos providers.
- Utilizar `providedIn: 'root'` para serviços singleton globais quando apropriado.
- Evitar dependências circulares.
- Não utilizar Service Locator.
- Evitar injeção de dependências desnecessárias em componentes.

### Exemplo

```typescript
@Injectable({
  providedIn: 'root'
})
export class TicketService {

  private readonly http = inject(HttpClient);

  getTickets(): Observable<Ticket[]> {
    return this.http.get<Ticket[]>('/api/tickets');
  }
}
```

---

## 7. Gerenciamento de estado

Utilizar Angular Signals para gerenciamento de estado reativo.

### Regras

- Utilizar `signal()` para estados locais.
- Utilizar `computed()` para valores derivados.
- Utilizar `input()` para propriedades reativas de componentes.
- Preferir `readonly` para expor estados que não devem ser alterados externamente.
- Utilizar RxJS para fluxos assíncronos, eventos e composição de operações HTTP.
- Utilizar `toSignal()` quando fizer sentido integrar Observables ao modelo de Signals.
- Não duplicar estados que podem ser derivados de outras informações.
- Evitar estados globais quando o estado pode permanecer dentro da funcionalidade.

### Exemplos

```typescript
export class TicketListComponent {

  readonly tickets = signal<Ticket[]>([]);

  readonly loading = signal(false);

  readonly totalTickets = computed(
    () => this.tickets().length
  );
}
```

### RxJS

- Utilizar operadores RxJS apropriados.
- Evitar subscriptions desnecessárias.
- Preferir async pipe ou toSignal() quando apropriado.
- Quando realizar subscriptions manuais, gerenciar o ciclo de vida utilizando takeUntilDestroyed() ou mecanismos equivalentes.
- Evitar nested subscriptions.
- Tratar erros explicitamente.
- Evitar utilização de Subjects como solução padrão para qualquer gerenciamento de estado.

Não introduzir NgRx ou outra biblioteca de gerenciamento de estado sem justificativa arquitetural.

### Uso de Effects

Utilizar `effect()` somente quando houver necessidade de sincronizar Signals com APIs externas ou realizar efeitos colaterais imperativos.

Preferir `computed()` para derivar estados.

Não utilizar Effects para manter estados duplicados sincronizados.

---

## 8. Comunicação com Backend — ASP.NET Core

A comunicação com o backend deve utilizar Angular HttpClient.

### 8.1 Services

- Criar serviços específicos para cada funcionalidade.
- Centralizar chamadas HTTP nos serviços.
- Não implementar chamadas HTTP diretamente nos componentes.
- Utilizar DTOs para definir contratos de entrada e saída.
- Tipar todas as respostas HTTP.
- Utilizar métodos HTTP adequados.
- Tratar erros de comunicação.
- Não duplicar regras de negócio do backend.

Exemplo:

```typescript
@Injectable({
  providedIn: 'root'
})
export class TicketService {

  private readonly http = inject(HttpClient);

  getTickets(): Observable<Ticket[]> {
    return this.http.get<Ticket[]>('/api/tickets');
  }

  createTicket(
    request: CreateTicketRequest
  ): Observable<Ticket> {
    return this.http.post<Ticket>(
      '/api/tickets',
      request
    );
  }
}
```

### 8.2 Contratos e DTOs

- Respeitar os contratos disponibilizados pelo backend.
- Não assumir propriedades que não existem na API.
- Não alterar nomes de propriedades sem necessidade.
- Utilizar modelos específicos para Requests e Responses.
- Criar mapeadores quando houver diferença entre DTOs da API e modelos de apresentação.
- Respeitar os formatos de data, números e enums definidos no contrato.
- Considerar campos opcionais e valores nulos.

As interfaces TypeScript devem refletir os contratos reais da API .NET.

### 8.3 Configuração da API

Utilizar configuração por ambiente para definir a URL base da API.

Exemplo:

```typescript
export const environment = {
  production: false,
  apiUrl: 'https://localhost:7001/api'
};
```

Não espalhar URLs de serviços diretamente nos componentes.

Não armazenar segredos ou credenciais nas configurações frontend.

### 8.4 HTTP Interceptors

Utilizar interceptors funcionais quando necessário.

Possíveis responsabilidades:

- Adicionar headers de autenticação.
- Propagar correlation IDs.
- Padronizar o tratamento de erros.
- Adicionar informações de rastreamento.
- Implementar comportamentos globais de comunicação.

Não concentrar regras específicas de negócio nos interceptors.

### 8.5 Tratamento de erros HTTP

- Tratar erros de maneira centralizada quando apropriado.
- Interpretar respostas ProblemDetails do ASP.NET Core.
- Exibir mensagens amigáveis ao usuário.
- Não apresentar StackTrace ou detalhes internos da API.
- Tratar erros 400, 401, 403, 404, 409, 429 e 500.
- Diferenciar erros de validação de erros de infraestrutura.
- Permitir tratamento específico de erros em funcionalidades que necessitem de comportamentos próprios.

---

## 9. Formulários — Reactive Forms

Preferir Reactive Forms para criação e manutenção de formulários.

Utilizar formulários tipados.

### Regras

- Criar formulários utilizando FormGroup e FormControl.
- Utilizar Typed Forms.
- Preferir NonNullableFormBuilder quando apropriado.
- Centralizar regras de validação.
- Utilizar Validators nativos antes de implementar validadores personalizados.
- Exibir mensagens de validação claras.
- Tratar os estados pristine, dirty, touched, valid e invalid.
- Desabilitar submissões quando o formulário estiver inválido ou em processamento.
- Implementar validações assíncronas somente quando necessárias.
- Evitar duplicação de regras de validação.

### Exemplo

```typescript
export class CreateTicketComponent {

  private readonly fb = inject(FormBuilder);

  readonly form = this.fb.nonNullable.group({
    title: ['', [
      Validators.required,
      Validators.maxLength(150)
    ]],
    description: ['', [
      Validators.required,
      Validators.maxLength(2000)
    ]],
    priority: ['Medium' as TicketPriority, [
      Validators.required
    ]]
  });
}
```

### Validação

As validações no frontend devem melhorar a experiência do usuário.

As regras de negócio e validações críticas devem continuar sendo garantidas pelo backend.

Não considerar validações do frontend como mecanismo de segurança.

---

## 10. Estilização — Tailwind CSS

Utilizar Tailwind CSS como padrão de estilização.

### Regras obrigatórias

- Preferir classes utilitárias do Tailwind.
- Evitar CSS personalizado quando houver solução equivalente no Tailwind.
- Evitar estilos inline.
- Evitar duplicação excessiva de combinações de classes.
- Utilizar componentes reutilizáveis para padrões visuais repetidos.
- Manter consistência de espaçamentos, cores, tipografia e bordas.
- Utilizar configurações e tokens visuais definidos no projeto.
- Não introduzir Bootstrap, Material UI ou outra biblioteca de componentes sem autorização.

### Design Responsivo

Todos os componentes devem considerar diferentes tamanhos de tela.

Utilizar breakpoints responsivos do Tailwind.

Priorizar abordagem mobile-first.

Validar:
- Desktop.
- Tablet.
- Mobile.

### Organização visual

- Manter hierarquia visual clara.
- Utilizar espaçamentos consistentes.
- Evitar excesso de elementos visuais.
- Manter alinhamento e proporções.
- Garantir legibilidade.
- Preservar a identidade visual definida para a aplicação.

### Componentes visuais

Priorizar criação e reutilização de componentes para:

- Buttons.
- Inputs.
- Selects.
- Modals.
- Tables.
- Cards.
- Alerts.
- Badges.
- Loading Indicators.
- Pagination.
- Dropdowns.

Não duplicar implementações visuais em funcionalidades diferentes.

---

## 11. Acessibilidade e HTML

Utilizar HTML semântico.

### Regras

- Utilizar elementos HTML adequados para cada finalidade.
- Utilizar labels associados aos inputs.
- Garantir navegação por teclado.
- Utilizar aria-label e outros atributos ARIA quando necessário.
- Garantir contraste adequado.
- Não depender exclusivamente de cores para transmitir informações.
- Utilizar atributos alt em imagens.
- Garantir foco visível nos elementos interativos.
- Implementar estados acessíveis para modais e componentes interativos.
- Utilizar botões para ações e links para navegação.

Priorizar conformidade com WCAG 2.2 AA quando aplicável ao projeto.

---

## 12. Angular Router

Utilizar Angular Router para gerenciamento de navegação.

### Regras

- Organizar rotas por funcionalidade.
- Utilizar lazy loading para funcionalidades independentes.
- Preferir loadComponent() e loadChildren() conforme a estrutura.
- Utilizar Route Guards para controlar acesso às rotas.
- Utilizar resolvers somente quando houver necessidade real.
- Evitar carregar funcionalidades que não são necessárias na inicialização.
- Organizar rotas protegidas e públicas.
- Implementar página de erro ou rota não encontrada.

### Exemplo

```typescript
export const routes: Routes = [
  {
    path: 'tickets',
    loadChildren: () =>
      import('./features/tickets/tickets.routes')
        .then(m => m.TICKET_ROUTES)
  }
];
```

Não utilizar Guards como substitutos de autorização no backend.

---

## 13. Segurança do Frontend

### 13.1 Autenticação

Quando aplicável:

- Utilizar OAuth 2.0 / OpenID Connect.
- Integrar com o provedor de identidade definido pela arquitetura.
- Utilizar bibliotecas oficiais quando disponíveis.
- Implementar renovação e expiração de sessão conforme o fluxo de autenticação.
- Não implementar mecanismos próprios de autenticação sem justificativa.
- Não confiar em informações de identidade ou permissões controladas pelo cliente.

### 13.2 Tokens e segredos

- Nunca armazenar segredos de aplicação no frontend.
- Não incluir client secrets, senhas ou credenciais em arquivos de ambiente.
- Preferir arquitetura BFF com cookies Secure, HttpOnly e SameSite quando definida pela solução.
- Quando utilizar SPA com tokens, seguir as recomendações de segurança do provedor OIDC.
- Não implementar armazenamento manual de tokens sem uma estratégia de autenticação aprovada.
- Evitar armazenamento de tokens de longa duração em localStorage.
- Não registrar tokens ou credenciais nos logs.

O frontend não deve acessar diretamente o Azure Key Vault para recuperar segredos de aplicação.

### 13.3 Proteção contra vulnerabilidades

- Respeitar os mecanismos nativos de sanitização do Angular.
- Não utilizar bypassSecurityTrustHtml() sem justificativa e revisão de segurança.
- Evitar manipulação direta do DOM.
- Não utilizar eval().
- Não construir templates dinamicamente com dados fornecidos pelo usuário.
- Validar URLs externas antes de utilizá-las.
- Evitar exposição de dados sensíveis na interface.
- Não confiar em validações realizadas exclusivamente no navegador.

### 13.4 Autorização

- Utilizar Guards para controlar navegação.
- Utilizar permissões para controlar elementos de interface quando aplicável.
- Ocultar ou desabilitar ações que o usuário não pode executar.
- Considerar que toda autorização efetiva deve ser validada pelo backend.

---

## 14. Performance

Aplicar boas práticas de desempenho.

- Utilizar lazy loading.
- Evitar carregamento desnecessário de módulos e funcionalidades.
- Utilizar OnPush.
- Utilizar track em loops com @for.
- Evitar chamadas repetidas à API.
- Evitar cálculos custosos nos templates.
- Utilizar Signals para estados reativos quando apropriado.
- Evitar subscriptions desnecessárias.
- Utilizar paginação para grandes volumes de dados.
- Otimizar imagens e arquivos estáticos.
- Evitar dependências externas de grande tamanho sem necessidade.
- Utilizar técnicas de carregamento sob demanda quando apropriado.

Não utilizar otimizações prematuras que dificultem a manutenção do código.

---

## 15. Padrões de templates Angular

Preferir a sintaxe moderna de controle de fluxo do Angular.

Utilizar:

- @if
- @else
- @for
- @switch
- @empty

Evitar utilizar as diretivas estruturais legadas em novos componentes quando houver equivalente moderno.

### Exemplo

```html
@if (loading()) {
  <app-loading />
} @else if (tickets().length > 0) {
  @for (ticket of tickets(); track ticket.id) {
    <app-ticket-card [ticket]="ticket" />
  }
} @else {
  <app-empty-state />
}
```

### Regras

- Manter templates simples e legíveis.
- Evitar lógica complexa no HTML.
- Utilizar computed para valores derivados.
- Evitar chamar métodos com processamento pesado no template.
- Utilizar track em listas iteráveis.
- Extrair trechos complexos para componentes reutilizáveis.

---

## 16. Logging e Observabilidade

Quando a arquitetura exigir observabilidade no frontend:

- Utilizar uma solução de instrumentação compatível com OpenTelemetry.
- Coletar informações relevantes de erros e desempenho.
- Propagar Trace Context quando aplicável.
- Correlacionar requisições frontend e backend quando suportado.
- Evitar enviar dados pessoais ou informações confidenciais.
- Não registrar tokens, senhas ou dados sensíveis.
- Evitar logs excessivos.
- Diferenciar informações de diagnóstico de informações destinadas ao usuário.

Não adicionar SDKs de observabilidade sem avaliar o impacto na aplicação e na arquitetura existente.

---

## 17. Testes automatizados

Utilizar testes automatizados para garantir a qualidade da aplicação.

### Unit Tests

Testar:

- Componentes.
- Serviços.
- Validators.
- Pipes.
- Directives.
- Guards.
- Interceptors.
- Funções de transformação de dados.

### Component Tests

Validar:

- Renderização dos componentes.
- Interações do usuário.
- Estados de carregamento.
- Estados vazios.
- Tratamento de erros.
- Validações de formulários.
- Comunicação entre componentes.

### Integration Tests

Testar:

- Comunicação entre componentes e serviços.
- Integração com HttpClient.
- Interceptors.
- Rotas.
- Guards.
- Fluxos completos de funcionalidades.

### Regras

- Utilizar Vitest em novos projetos quando for o executor padrão do Angular CLI.
- Respeitar o framework de testes existente em projetos estabelecidos.
- Utilizar HttpTestingController para simular chamadas HTTP quando apropriado.
- Evitar dependência de APIs externas durante testes unitários.
- Testar cenários de sucesso, erro e borda.
- Não testar apenas detalhes internos de implementação.
- Não considerar cobertura de código como único indicador de qualidade.

---

## 18. Integração com SDD — Spec-Driven Development

O desenvolvimento frontend deve ser orientado pelas especificações aprovadas.

Antes de iniciar uma implementação:

1. Consultar a especificação funcional em `specs/`.
2. Consultar o plano técnico.
3. Identificar os critérios de aceite.
4. Identificar os contratos da API.
5. Verificar componentes e funcionalidades existentes.
6. Identificar impactos nas funcionalidades relacionadas.
7. Identificar requisitos de acessibilidade, segurança e responsividade.

### Durante a implementação

- Seguir rigorosamente os requisitos documentados.
- Implementar somente o escopo aprovado.
- Não inventar funcionalidades ou comportamentos.
- Não alterar contratos da API por decisão própria.
- Reutilizar componentes existentes.
- Respeitar padrões visuais e arquiteturais.
- Implementar estados de loading, empty, success e error quando aplicáveis.
- Implementar testes relacionados aos critérios de aceite.

### Alterações de requisitos

Quando uma implementação exigir alteração na especificação:

- Identificar o requisito impactado.
- Descrever a inconsistência.
- Atualizar a especificação antes de modificar o código.
- Avaliar impactos sobre componentes, serviços, contratos e testes.
- Não implementar comportamentos que contrariem a especificação aprovada.

### Após a implementação

- Validar compilação.
- Executar testes.
- Verificar aderência à especificação.
- Verificar responsividade.
- Verificar acessibilidade.
- Verificar erros de console.
- Verificar integração com a API.
- Atualizar a documentação técnica quando necessário.

---

## 19. Regras de atuação do Agente

O Agente deve atuar como assistente de engenharia frontend.

### Antes de implementar

Deve:

- Analisar a estrutura existente.
- Consultar os arquivos de instrução.
- Consultar a especificação e o plano.
- Identificar componentes e serviços reutilizáveis.
- Verificar os padrões de nomenclatura.
- Verificar as dependências existentes.
- Identificar impactos em funcionalidades relacionadas.

### Durante a implementação

Deve:

- Utilizar Angular e TypeScript seguindo os padrões definidos.
- Utilizar standalone components.
- Utilizar Dependency Injection.
- Aplicar separação de responsabilidades.
- Utilizar Tailwind CSS.
- Respeitar os contratos da API.
- Não introduzir bibliotecas sem justificativa.
- Não modificar configurações globais sem necessidade.
- Evitar refatorações não relacionadas à tarefa.
- Não introduzir soluções arquiteturais desnecessárias.

### Após a implementação

Deve:

- Executar build.
- Executar os testes automatizados.
- Corrigir erros de compilação.
- Verificar aderência aos padrões.
- Validar os critérios de aceite.
- Verificar a integração com backend.
- Apresentar resumo das alterações.
- Informar limitações e pendências encontradas.

---

## 20. Critérios de aceite

Uma implementação frontend somente deve ser considerada concluída quando:

- [ ] A arquitetura por funcionalidades foi respeitada.
- [ ] Os componentes utilizam standalone.
- [ ] A separação de responsabilidades foi respeitada.
- [ ] A injeção de dependência está corretamente implementada.
- [ ] O TypeScript está devidamente tipado.
- [ ] Os serviços centralizam as chamadas HTTP.
- [ ] Os contratos estão alinhados com a API .NET.
- [ ] O gerenciamento de estado segue os padrões definidos.
- [ ] Os formulários utilizam Reactive Forms quando aplicável.
- [ ] As validações estão implementadas.
- [ ] O Tailwind CSS está sendo utilizado corretamente.
- [ ] A interface é responsiva.
- [ ] Os requisitos de acessibilidade foram considerados.
- [ ] Os requisitos de segurança foram considerados.
- [ ] Os testes automatizados foram implementados.
- [ ] O build executa sem erros.
- [ ] A implementação atende aos critérios de aceite da especificação.

---

## 21. Diretriz final

O Agente deve respeitar os padrões arquiteturais, tecnológicos e visuais definidos neste documento.

As implementações devem priorizar simplicidade, qualidade, reutilização, segurança e manutenibilidade.

**O frontend deve ser desenvolvido de forma independente do backend, mantendo contratos explícitos de integração e respeitando as responsabilidades de cada aplicação.**

Em caso de conflito entre uma solicitação e estas instruções, o Copilot deve identificar o conflito e solicitar esclarecimento antes de introduzir mudanças arquiteturais ou comprometer os padrões estabelecidos.