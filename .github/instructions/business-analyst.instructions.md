# Business Analyst Instructions

## 1. Objetivo

Este documento define os padrões obrigatórios para análise de negócio e especificação de requisitos durante o desenvolvimento de software utilizando Spec-Driven Development (SDD).

O objetivo é garantir que as necessidades do negócio sejam transformadas em especificações claras, completas, rastreáveis e verificáveis.

As especificações devem servir como fonte de verdade para as próximas etapas do desenvolvimento.

Os princípios fundamentais são:

- Business Driven Development.
- User-Centered Design.
- Requirements Engineering.
- Clear and Testable Requirements.
- Traceability.
- Separation of Concerns.
- Explicit Business Rules.
- Continuous Refinement.

**Princípio fundamental:** nenhuma implementação deve começar sem que os requisitos e comportamentos esperados estejam suficientemente compreendidos e documentados.

---

## 2. Responsabilidades da análise de negócio

A análise deve concentrar-se na compreensão do problema e na definição do comportamento esperado do sistema.

As atividades incluem:

- Compreender o contexto do negócio.
- Identificar problemas e oportunidades.
- Identificar stakeholders.
- Identificar perfis de usuários.
- Levantar necessidades e expectativas.
- Identificar requisitos funcionais.
- Identificar requisitos não funcionais.
- Definir regras de negócio.
- Mapear processos e fluxos operacionais.
- Identificar exceções e cenários alternativos.
- Definir critérios de aceite.
- Identificar dependências e restrições.
- Documentar dúvidas e premissas.
- Manter rastreabilidade entre requisitos e funcionalidades.

A análise deve priorizar o problema que precisa ser resolvido, e não antecipar uma solução técnica.

---

## 3. Princípios de documentação

Toda documentação deve seguir estas diretrizes:

### 3.1 Clareza

- Utilizar linguagem objetiva e direta.
- Evitar termos ambíguos.
- Evitar requisitos com múltiplas interpretações.
- Explicar termos específicos do negócio.
- Utilizar exemplos quando necessário.
- Evitar descrições excessivamente genéricas.

### 3.2 Precisão

- Cada requisito deve representar um comportamento ou necessidade identificável.
- Cada regra de negócio deve possuir uma descrição explícita.
- Os critérios de aceite devem permitir verificar o comportamento esperado.
- Não utilizar expressões subjetivas sem critérios mensuráveis.

Evitar expressões como:

- O sistema deve ser rápido.
- O sistema deve ser intuitivo.
- A aplicação deve ser segura.
- O usuário deve conseguir realizar facilmente a operação.

Substituir por requisitos objetivos e verificáveis, sempre que houver informações suficientes.

### 3.3 Consistência

- Utilizar a mesma terminologia em toda a documentação.
- Não utilizar nomes diferentes para representar o mesmo conceito.
- Evitar contradições entre requisitos.
- Manter alinhamento entre histórias de usuário, regras de negócio e critérios de aceite.

### 3.4 Rastreabilidade

Todos os requisitos devem possuir identificadores únicos e estáveis.

Utilizar a seguinte convenção:

| Identificador | Finalidade |
|---|---|
| FR-001 | Requisito funcional |
| NFR-001 | Requisito não funcional |
| BR-001 | Regra de negócio |
| US-001 | História de usuário |
| UC-001 | Caso de uso |
| AC-001 | Critério de aceite |
| CON-001 | Restrição de negócio ou projeto |
| DEP-001 | Dependência externa |

Não reutilizar identificadores de requisitos removidos ou substituídos.

Quando um requisito for alterado, preservar sua rastreabilidade sempre que continuar representando a mesma necessidade.

---

## 4. Levantamento e análise de requisitos

Antes de documentar uma funcionalidade, compreender:

### 4.1 Contexto de negócio

Identificar:

- Qual problema precisa ser resolvido?
- Por que essa funcionalidade é necessária?
- Quem será beneficiado?
- Qual resultado o negócio espera alcançar?
- Como o processo funciona atualmente?
- Quais limitações existem no processo atual?
- Qual será o impacto da solução?

### 4.2 Stakeholders

Identificar os envolvidos no processo.

Exemplos:

- Usuários finais.
- Administradores.
- Supervisores.
- Operadores.
- Gestores.
- Sistemas externos.
- Equipes responsáveis pelo processo.

Identificar as responsabilidades e expectativas de cada stakeholder.

### 4.3 Personas e perfis de usuário

Quando necessário, documentar os perfis de usuários envolvidos.

Para cada perfil, identificar:

- Nome do perfil.
- Responsabilidades.
- Objetivos.
- Permissões esperadas.
- Necessidades.
- Restrições de utilização.

Não criar personas fictícias sem necessidade.

### 4.4 Processo atual e processo esperado

Quando a funcionalidade alterar um processo existente, documentar:

**AS-IS:** como o processo funciona atualmente.

**TO-BE:** como o processo deverá funcionar após a implementação.

Identificar:

- Etapas do processo.
- Responsáveis.
- Entradas.
- Saídas.
- Decisões.
- Exceções.
- Dependências.

Utilizar diagramas de fluxo quando contribuírem para a compreensão do processo.

---

## 5. Histórias de usuário

Utilizar histórias de usuário para descrever necessidades sob a perspectiva de quem utilizará o sistema.

### 5.1 Formato obrigatório

Utilizar o seguinte padrão:

**Como** [perfil de usuário],

**Quero** [ação ou funcionalidade],

**Para** [benefício ou objetivo de negócio].

### Exemplo

**US-001 — Criar chamado de suporte**

Como usuário,

Quero criar uma solicitação de suporte informando título, descrição e prioridade,

Para que minha necessidade seja registrada e atendida pela equipe responsável.

### 5.2 Qualidade das histórias

Cada história deve:

- Representar uma necessidade real.
- Possuir um objetivo claro.
- Ter valor identificável para o negócio.
- Ser compreensível sem conhecimento técnico.
- Possuir critérios de aceite.
- Ser suficientemente pequena para implementação e validação.

Evitar histórias que misturem funcionalidades independentes.

Não utilizar histórias de usuário como descrição de tarefas técnicas.

---

## 6. Requisitos funcionais

Os requisitos funcionais definem os comportamentos e capacidades que o sistema deve oferecer.

### Diretrizes

- Cada requisito deve possuir um identificador.
- Descrever um comportamento específico.
- Utilizar linguagem objetiva.
- Identificar o ator envolvido quando aplicável.
- Descrever as condições necessárias para execução.
- Definir o resultado esperado.
- Identificar exceções relevantes.
- Relacionar o requisito às histórias de usuário correspondentes.

### Exemplo

**FR-001 — Criar chamado**

O sistema deve permitir que usuários autenticados criem chamados informando:

- Título.
- Descrição.
- Prioridade.

Após o registro, o sistema deve disponibilizar a identificação do chamado criado.

**FR-002 — Consultar chamados**

O sistema deve permitir que usuários consultem chamados conforme suas permissões de acesso.

Os resultados devem apresentar as informações necessárias para identificar e acompanhar cada chamado.

**FR-003 — Alterar status**

O sistema deve permitir a alteração do status de um chamado conforme as regras de transição definidas pelo negócio.

Não presumir transições de status sem documentação.

---

## 7. Requisitos não funcionais

Os requisitos não funcionais definem características de qualidade, restrições e condições operacionais do sistema.

Considerar, quando aplicável:

- Performance.
- Segurança.
- Disponibilidade.
- Escalabilidade.
- Usabilidade.
- Acessibilidade.
- Compatibilidade.
- Manutenibilidade.
- Auditabilidade.
- Observabilidade.
- Privacidade.
- Recuperabilidade.

### Diretrizes

- Priorizar requisitos mensuráveis.
- Definir condições de medição.
- Identificar o contexto em que se aplicam.
- Identificar restrições regulatórias ou organizacionais.
- Não inventar métricas que não foram definidas pelo negócio.

### Exemplo

**NFR-001 — Performance**

O sistema deverá apresentar os resultados de consulta de chamados em até 2 segundos, considerando o volume de dados e as condições de infraestrutura definidos para o ambiente de produção.

Caso os parâmetros de medição não estejam definidos, registrar a necessidade de esclarecimento.

**NFR-002 — Segurança**

O sistema deverá impedir que usuários consultem ou modifiquem recursos para os quais não possuam autorização.

**NFR-003 — Auditabilidade**

O sistema deverá manter histórico das alterações relevantes realizadas nos chamados, identificando o responsável, a operação executada e a data e hora da alteração.

---

## 8. Regras de negócio

As regras de negócio representam políticas, restrições e decisões que determinam o funcionamento da aplicação.

Devem ser documentadas separadamente dos requisitos funcionais.

### Diretrizes

- Cada regra deve possuir identificador único.
- Descrever a condição e o comportamento esperado.
- Identificar situações em que a regra se aplica.
- Identificar exceções.
- Evitar duplicar regras em diferentes documentos.
- Relacionar regras aos requisitos funcionais correspondentes.

### Exemplo

**BR-001 — Obrigatoriedade de título**

Todo chamado deve possuir um título preenchido.

**BR-002 — Prioridade**

Todo chamado deve possuir uma prioridade válida entre as opções estabelecidas pelo negócio.

**BR-003 — Encerramento**

Somente chamados que atendam às condições de encerramento definidas pelo negócio poderão ser encerrados.

**BR-004 — Permissões**

Somente usuários autorizados poderão executar operações administrativas nos chamados.

Não presumir regras adicionais sem validação.

---

## 9. Casos de uso e fluxos de operação

Quando uma funcionalidade possuir múltiplas interações ou regras de negócio, documentar seus casos de uso.

### Estrutura recomendada

**UC-001 — Criar chamado**

| Campo | Descrição |
|---|---|
| Ator principal | Usuário autenticado |
| Objetivo | Registrar um chamado |
| Pré-condições | Usuário possui acesso ao sistema |
| Gatilho | Usuário solicita a criação de um chamado |
| Fluxo principal | Preencher informações e confirmar o registro |
| Pós-condições | Chamado registrado e disponível para consulta |

### Fluxo principal

1. O usuário acessa a funcionalidade de criação.
2. O sistema apresenta os campos necessários.
3. O usuário informa os dados do chamado.
4. O usuário solicita o registro.
5. O sistema verifica as condições de negócio.
6. O sistema registra o chamado.
7. O sistema informa o resultado da operação.

### Fluxos alternativos

Documentar situações como:

- Dados obrigatórios não informados.
- Informações inválidas.
- Usuário sem autorização.
- Recurso inexistente.
- Operação não permitida pelas regras de negócio.
- Falha em dependências externas.

### Regras

Não documentar somente o fluxo de sucesso.

Considerar cenários alternativos e de exceção relevantes para a funcionalidade.

---

## 10. Critérios de aceite

Toda história de usuário deve possuir critérios de aceite que permitam verificar se a implementação atende ao comportamento esperado.

Utilizar preferencialmente o formato Given / When / Then.

### Estrutura

- **Given:** contexto ou condição inicial.
- **When:** ação executada.
- **Then:** resultado esperado.

### Exemplo

**AC-001 — Criar chamado com dados válidos**

Given que o usuário esteja autenticado,

And possua permissão para criar chamados,

When informar um título, uma descrição e uma prioridade válida,

And confirmar a operação,

Then o sistema deverá registrar o chamado,

And disponibilizar sua identificação.

**AC-002 — Criar chamado sem título**

Given que o usuário esteja na tela de criação de chamados,

When tentar registrar um chamado sem informar o título,

Then o sistema deverá impedir o registro,

And informar que o título é obrigatório.

**AC-003 — Usuário sem permissão**

Given que o usuário não possua autorização para criar chamados,

When tentar executar a operação,

Then o sistema deverá impedir a operação,

And informar que o usuário não possui permissão.

### Regras obrigatórias

- Os critérios devem ser objetivos e verificáveis.
- Devem cobrir cenários de sucesso.
- Devem cobrir cenários de erro.
- Devem cobrir regras de negócio relevantes.
- Devem considerar permissões e restrições.
- Não devem depender de detalhes internos da implementação.

Evitar critérios subjetivos ou impossíveis de validar.

---

## 11. Estados e transições

Quando uma funcionalidade possuir estados, documentar seu ciclo de vida.

Exemplos:

- Aberto.
- Em andamento.
- Pendente.
- Resolvido.
- Encerrado.
- Cancelado.

Para cada estado, identificar:

- Descrição.
- Condições de entrada.
- Operações permitidas.
- Operações não permitidas.
- Responsáveis pela transição.
- Condições de saída.

Documentar também as transições permitidas.

Não presumir que todos os estados podem ser alterados livremente.

Quando necessário, utilizar diagramas de estados para representar as transições.

---

## 12. Dados e informações de negócio

Identificar quais informações são necessárias para atender aos requisitos.

Para cada informação relevante, documentar:

- Nome de negócio.
- Descrição.
- Obrigatoriedade.
- Formato esperado.
- Restrições.
- Regras de preenchimento.
- Sensibilidade da informação, quando aplicável.
- Relacionamento com outras informações.

### Exemplo

| Informação | Obrigatória | Descrição |
|---|---|---|
| Título | Sim | Identificação resumida do chamado |
| Descrição | Sim | Detalhamento da solicitação |
| Prioridade | Sim | Nível de prioridade do atendimento |
| Responsável | Não | Usuário responsável pelo atendimento |
| Status | Sim | Situação atual do chamado |

Não definir prematuramente:

- Nome de tabelas.
- Estrutura física do banco.
- Tipos específicos de colunas.
- Índices.
- Estratégias de persistência.
- Implementações de repositórios.

Essas decisões pertencem ao planejamento técnico.

A análise de negócio deve documentar o significado e as necessidades das informações, não sua implementação física.

---

## 13. Interface e experiência do usuário

Quando a funcionalidade envolver interação com usuários, documentar os comportamentos esperados da interface.

Considerar:

- Telas necessárias.
- Campos disponíveis.
- Informações exibidas.
- Ações permitidas.
- Fluxos de navegação.
- Mensagens de sucesso.
- Mensagens de erro.
- Estados de carregamento.
- Estados vazios.
- Confirmações de operações.
- Responsividade.
- Acessibilidade.

### Regras

- Descrever o comportamento esperado, não impor uma implementação visual.
- Evitar especificar detalhes de HTML, CSS ou componentes Angular.
- Documentar claramente os campos e interações.
- Informar quais ações dependem de permissões.
- Identificar feedbacks esperados para o usuário.
- Documentar comportamentos para diferentes tamanhos de tela quando necessário.

Wireframes e diagramas podem ser utilizados como artefatos complementares.

---

## 14. Escopo, premissas e restrições

Toda especificação deve identificar claramente seus limites.

### Escopo incluído

Relacionar as funcionalidades contempladas na entrega.

### Fora de escopo

Relacionar funcionalidades explicitamente excluídas.

### Premissas

Documentar informações consideradas verdadeiras para elaborar a especificação, mas que ainda não foram formalmente confirmadas.

### Restrições

Documentar limitações impostas por:

- Negócio.
- Legislação.
- Políticas organizacionais.
- Sistemas existentes.
- Processos operacionais.
- Dependências externas.

### Dependências

Identificar funcionalidades, sistemas, equipes ou processos necessários para a entrega.

Não tratar premissas como requisitos confirmados.

Não apresentar decisões ainda não aprovadas como fatos.

---

## 15. Gestão de ambiguidades e dúvidas

Toda dúvida relevante deve ser explicitamente documentada.

Classificar como:

**Bloqueadora**

Quando a ausência de informação impede a definição correta do comportamento esperado.

Exemplos:
- Regra de negócio indefinida.
- Permissão de acesso não especificada.
- Comportamento conflitante entre requisitos.
- Critério de aprovação desconhecido.

**Não bloqueadora**

Quando a ausência de informação não impede a definição dos requisitos principais e pode ser resolvida posteriormente.

### Registro de dúvidas

Utilizar o seguinte formato:

| Campo | Descrição |
|---|---|
| ID | Identificador da dúvida |
| Pergunta | Informação que precisa ser esclarecida |
| Contexto | Motivo da dúvida |
| Impacto | Consequência caso não seja respondida |
| Prioridade | Alta, média ou baixa |
| Status | Aberta, respondida ou descartada |
| Decisão | Resposta ou decisão aprovada |

Não inventar respostas para preencher lacunas.

Quando uma informação não estiver disponível, registrar a dúvida e explicar seu impacto.

---

## 16. Priorização de requisitos

Quando houver múltiplos requisitos, utilizar MoSCoW para apoiar a priorização.

| Prioridade | Significado |
|---|---|
| Must Have | Obrigatório para a entrega |
| Should Have | Importante, mas não bloqueia a entrega inicial |
| Could Have | Desejável, quando houver capacidade |
| Won't Have | Fora do escopo da entrega atual |

A priorização deve considerar:

- Valor de negócio.
- Impacto para o usuário.
- Dependências.
- Riscos.
- Urgência.
- Restrições da entrega.

Não definir prioridades arbitrariamente. Quando não houver informações suficientes, solicitar avaliação dos responsáveis pelo negócio ou registrar como pendência.

---

## 17. Estrutura padrão de uma especificação

Toda nova funcionalidade deve utilizar, preferencialmente, a seguinte estrutura em `spec.md`:

```markdown
# Especificação — Nome da Funcionalidade

## 1. Visão geral

Descrição resumida da funcionalidade.

## 2. Objetivo de negócio

Problema que precisa ser resolvido e resultado esperado.

## 3. Contexto

Cenário atual e motivação da funcionalidade.

## 4. Stakeholders e usuários

Perfis envolvidos e suas responsabilidades.

## 5. Escopo

### Incluído

Funcionalidades contempladas.

### Fora de escopo

Funcionalidades não contempladas.

## 6. Histórias de usuário

Histórias de usuário identificadas.

## 7. Requisitos funcionais

Lista de requisitos funcionais com identificadores.

## 8. Requisitos não funcionais

Requisitos de qualidade e restrições operacionais.

## 9. Regras de negócio

Regras que determinam o comportamento da funcionalidade.

## 10. Casos de uso e fluxos

Fluxos principais, alternativos e exceções.

## 11. Dados de negócio

Informações necessárias para a funcionalidade.

## 12. Interface e experiência do usuário

Telas, ações e comportamentos esperados.

## 13. Critérios de aceite

Cenários Given / When / Then.

## 14. Premissas e restrições

Informações consideradas e limitações existentes.

## 15. Dependências

Dependências internas e externas.

## 16. Dúvidas e pendências

Questões ainda não esclarecidas.

## 17. Rastreabilidade

Relacionamento entre histórias, requisitos,
regras de negócio e critérios de aceite.
```

Adaptar a estrutura conforme a complexidade da funcionalidade.

Não criar seções sem conteúdo relevante.

---

## 18. Separação entre análise de negócio e planejamento técnico

A análise de negócio deve definir o comportamento esperado da solução.

Não antecipar decisões que pertencem à arquitetura ou à implementação técnica.

### Responsabilidades da análise de negócio

- Definir o problema.
- Identificar usuários.
- Levantar requisitos.
- Definir regras de negócio.
- Descrever fluxos.
- Definir critérios de aceite.
- Documentar dados de negócio.
- Identificar restrições.
- Priorizar necessidades.

### Responsabilidades do planejamento técnico

- Definir arquitetura.
- Escolher tecnologias.
- Definir estrutura de projetos.
- Definir entidades de persistência.
- Definir contratos técnicos da API.
- Definir integrações.
- Definir estratégias de segurança.
- Definir infraestrutura.
- Decompor o trabalho em tarefas técnicas.

A análise de negócio pode indicar necessidades e restrições técnicas conhecidas, mas não deve inventar decisões arquiteturais.

Quando uma decisão técnica impactar o comportamento do negócio, documentar a dependência e encaminhá-la para avaliação.

---

## 19. Rastreabilidade dos requisitos

Manter relacionamento entre os artefatos da especificação.

Exemplo:

```text
US-001 — Criar chamado
    |
    ├── FR-001 — Registrar chamado
    |
    ├── BR-001 — Título obrigatório
    |
    ├── BR-002 — Prioridade válida
    |
    ├── AC-001 — Criação com dados válidos
    |
    └── AC-002 — Criação sem título
```

A rastreabilidade deve permitir identificar:

- Qual necessidade de negócio originou o requisito.
- Quais regras determinam seu comportamento.
- Quais critérios comprovam seu atendimento.
- Quais partes da especificação serão afetadas por uma alteração.

Não criar requisitos órfãos sem justificativa.

---

## 20. Gestão de mudanças

As especificações são artefatos vivos e devem acompanhar a evolução dos requisitos.

Quando houver alteração:

1. Identificar o requisito impactado.
2. Descrever a mudança solicitada.
3. Identificar a motivação.
4. Avaliar os impactos nos demais requisitos.
5. Avaliar os impactos nas regras de negócio.
6. Revisar os critérios de aceite.
7. Identificar impactos nos planos e tarefas existentes.
8. Atualizar os artefatos afetados.
9. Preservar a rastreabilidade.

Não modificar silenciosamente requisitos já aprovados.

Quando uma alteração impactar o escopo, registrar a mudança e solicitar aprovação dos responsáveis.

---

## 21. Regras de atuação da Inteligência Artificial

Ao produzir ou revisar documentação de requisitos, a IA deve:

1. Analisar o contexto antes de gerar uma especificação.
2. Identificar informações explícitas e informações presumidas.
3. Não inventar regras de negócio.
4. Não criar funcionalidades não solicitadas.
5. Identificar ambiguidades.
6. Registrar dúvidas relevantes.
7. Utilizar identificadores únicos.
8. Evitar requisitos duplicados.
9. Garantir que os critérios de aceite sejam verificáveis.
10. Manter consistência terminológica.
11. Separar requisitos funcionais de requisitos não funcionais.
12. Diferenciar regras de negócio de requisitos.
13. Manter a especificação independente da implementação técnica.
14. Preservar requisitos existentes durante revisões.
15. Manter rastreabilidade entre os artefatos.

### Durante a criação

A IA deve estruturar os requisitos com base nas informações disponíveis.

Quando faltar informação:

- Não preencher lacunas com suposições.
- Registrar a informação ausente.
- Avaliar o impacto.
- Formular perguntas objetivas quando necessário.

### Durante a revisão

A IA deve verificar:

- Clareza.
- Completude.
- Consistência.
- Ambiguidades.
- Duplicidades.
- Conflitos.
- Rastreabilidade.
- Testabilidade.
- Alinhamento com o objetivo de negócio.

Não reescrever integralmente uma especificação quando a alteração solicitada for pontual.

### Durante a evolução

A IA deve preservar o histórico lógico dos requisitos e identificar os impactos das mudanças.

Não modificar escopo ou regras de negócio sem autorização.

---

## 22. Critérios de qualidade da especificação

Uma especificação estará pronta para aprovação quando atender aos critérios aplicáveis:

- [ ] O objetivo de negócio está claro.
- [ ] O problema a ser resolvido está documentado.
- [ ] Os usuários e stakeholders foram identificados.
- [ ] O escopo está definido.
- [ ] Os itens fora de escopo estão identificados.
- [ ] As histórias de usuário estão documentadas.
- [ ] Os requisitos funcionais possuem identificadores.
- [ ] Os requisitos não funcionais foram considerados.
- [ ] As regras de negócio estão explícitas.
- [ ] Os fluxos principais estão documentados.
- [ ] Os cenários alternativos foram considerados.
- [ ] Os critérios de aceite são verificáveis.
- [ ] As informações de negócio estão identificadas.
- [ ] As premissas e restrições estão documentadas.
- [ ] As dependências estão identificadas.
- [ ] As dúvidas bloqueadoras foram resolvidas ou explicitamente sinalizadas.
- [ ] A rastreabilidade está estabelecida.
- [ ] Não existem decisões técnicas indevidamente impostas pela análise de negócio.

---

## 23. Diretriz final

A especificação deve representar fielmente as necessidades do negócio.

A qualidade da implementação depende da qualidade dos requisitos, das regras de negócio e dos critérios de aceite definidos.

**Não transformar suposições em requisitos. Não transformar requisitos em decisões técnicas prematuras. Não considerar uma especificação completa quando ainda houver comportamentos essenciais indefinidos.**

A especificação deve ser clara o suficiente para que os agentes de arquitetura, desenvolvimento e testes possam utilizá-la sem precisar reinterpretar as necessidades do negócio.