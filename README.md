# FATEC DevDay 2026

Esse repositório contém o material de apoio da palestra `O desenvolvedor na era da IA: O que mudou e como se preparar` do evento FATEC DevDay 2026.

# Markdown

É uma linguagem de marcação leve utilizada para formatar textos de maneira simples. o formato de arquivo `.md` é amplamente utilizado para estruturar informações, documentações, instruções consumidas por modelos de linguagem **LLMs**.

Por ser texto simples o **Markdown** não exige interpretação de estruturas complexas como XML e é facilmente convertido em textos e tokens, ideal para dar contextos e instruções aos modelos de Inteligência Artificial.

[Documentação oficial CommonMark](https://spec.commonmark.org/0.31.2/)

[Aprenda com exemplos práticos](https://markdown.org/)

[Guia Markdown da MDN](https://developer.mozilla.org/en-US/docs/MDN/Writing_guidelines/Howto/Markdown_in_MDN)

---

# Visual Code

Ambiente de desenvolvimento leve e gratuito, multiplaforma e extensível. Utilizado por desenvolvedores para escrever, editar, executar, depurar e manter aplicações de software.

O VS Code é uma das principais ferramentas de desenvolvimento de software assistido por IA.

[Baixar VS Code](https://code.visualstudio.com/download)

---

# GitHub Copilot

É uma ferramenta de inteligência artificial desenvolvida pela **GitHub** em parceria com a **OpenAI** para desenvolvimento de software assistido por inteligência artificial.

Ele funciona como um **assistente** de programação com IA, integrado a ferramentas como **Visual Code** e **GitHub**.

Possui funcionalidades como:

- **Geração de código**: sugere trechos de código com base no contexto e nos comentários.
- **Autocompletar**: prevê e completa linhas ou blocos de código.
- **Chat**: permite conversar com a IA para tirar dúvidas, explicar códigos e resolver problemas.
- **Agentes de IA**: executam tarefas de desenvolvimento de forma mais autônoma.
- **Geração de testes**: auxilia na criação de testes unitários.
- **Refatoração**: sugere melhorias na estrutura e qualidade do código.
- **Documentação**: ajuda a criar comentários e documentações técnicas.

[Documentação oficial](https://docs.github.com/pt/copilot)

## GitHub Copilot Free

O GitHub oferece plano gratuito para qualquer pessoa com uma conta pessoal no GitHub.

**Como ativar:**

1. Acesse [GitHub](https://github.com/)
2. Faça login ou crie uma conta
3. Acesse [GitHub Copilot Plans](https://github.com/features/copilot/plans)
4. Selecione o plano **Copilot Free**
5. Ative o plano gratuito

**Como usar:**

[Configurar GitHub Copilot no VS Code](https://code.visualstudio.com/docs/setup/copilot)

## GitHub Copilot Student

Se você possui vínculo com uma instituição de enside e atende aos critérios de elegibilidade, pode solicitar o benefício educacional.

**Acesse:** [GitHub Education - Student Developer Pack](https://education.github.com/pack)


---

# Spec-Driven Development (SDD)

O **Desenvolvimento Orientado por Especificações**, é uma técnica de desenvolvimento de software assistido por Inteligência Artificial, na qual a especificação do que deve ser construído vem antes da implementação do código.

## Como funciona?

Você cria uma estrutura de documentos como fonte de verdade para orientar tantos os desenvolvedores de software quanto os agentes de IA (GitHub Copilot, Claude, Codex, Cursor etc.) a seguir as especificações.

O processo geralmente segue as etapas:

### 1. Especificar

Definir o problema, objetivos, requisitos funcionais, requisitos não funcionais e critérios de aceitação.

### 2. Planejar

Definir arquitetura, tecnologias, componentes, integrações e decisões técnicas.

### 3. Decompor Tarefas

Decompor a especificação e o planejamento em tarefas menores e executáveis.

### 4. Implementar

Utilizar desenvolvedores ou agentes de IA para implementar as tarefas seguindo as especificações.

### 5. Validar

Verificar se a implementação atende aos requisitos e critérios definidos.

## Principais beneficios do SDD

**Previsibilidade**: reduz ambiguidades durante o desenvolvimento.
**Consistência**: mantém a implementação alinhada aos requisitos.
**Rastreabilidade**: permite relacionar requisitos, tarefas e código.
**Governança**: facilita revisões técnicas e auditorias.
**Produtividade**: fornece contexto estruturado aos agentes de IA.
**Manutenibilidade**: facilita evoluções sem perder as decisões originais.

## Referências para estudos

1. [OpenSpec](https://openspec.dev/)

2. [GitHub Spec Kit – Documentação oficial](https://github.com/github/spec-kit)

3. [GitHub – Spec-Driven Development with AI](https://github.blog/ai-and-ml/generative-ai/spec-driven-development-with-ai-get-started-with-a-new-open-source-toolkit/)

4. [Microsoft – Diving Into Spec-Driven Development](https://developer.microsoft.com/blog/spec-driven-development)

5. [Spec Kit – Quickstart](https://github.com/github/spec-kit/blob/main/docs/quickstart.md)

---

# OpenSpec + GitHub Copilot - Início Rápido

## 1. O que é OpenSpec?

O [OpenSpec](https://openspec.dev/) é um framework de **Spec-Driven Development (SDD)** que organiza o desenvolvimento de software orientado por especificações.

Ele permite definir requisitos, documentar decisões técnicas, planejar tarefas e orientar agentes de IA antes da implementação do código.

O objetivo é garantir que desenvolvedores e agentes de IA tenham um entendimento comum sobre o que deve ser construído.

## 2. Pré-requisitos

Antes de começar, você precisa de:

- [Node.js](https://nodejs.org/) instalado.
- [Visual Studio Code](https://code.visualstudio.com/).
- Extensão do [GitHub Copilot](https://github.com/features/copilot) instalada e configurada.
- Repositório do projeto aberto no VS Code.

## 3. Instalação

Instale o OpenSpec globalmente utilizando npm:

```bash
npm install -g @fission-ai/openspec@latest
```

Verifique se a instalação foi realizada:

```bash
openspec --version
```

## 4. Configuração do projeto

Na raiz do repositório, execute:

```bash
openspec init --tools github-copilot
```

Esse comando inicializa o OpenSpec e configura sua integração com o GitHub Copilot.

A estrutura criada será semelhante a:

```text
projeto/
├── .github/
│   ├── prompts/
│   └── skills/
├── openspec/
│   ├── changes/
│   │   └── archive/
│   ├── specs/
│   └── config.yaml
├── src/
└── README.md
```

Reinicie o VS Code para carregar os comandos de integração.

## 5. Fluxo de trabalho

O OpenSpec utiliza um fluxo incremental para transformar ideias em implementações.

| Etapa | Comando | Objetivo |
|---|---|---|
| 1. Explorar | `/opsx-explore` | Explorar o problema e analisar alternativas. |
| 2. Propor | `/opsx-propose` | Criar a proposta e os artefatos da mudança. |
| 3. Revisar | — | Revisar requisitos, decisões e tarefas. |
| 4. Implementar | `/opsx-apply` | Implementar seguindo as tarefas definidas. |
| 5. Sincronizar | `/opsx-sync` | Atualizar as especificações principais. |
| 6. Arquivar | `/opsx-archive` | Arquivar a mudança concluída. |

**Importante:** os comandos `/opsx-*` são executados no chat do GitHub Copilot, não no terminal.

## 6. Criando sua primeira funcionalidade

**Passo 1 – Explorar a necessidade (opcional)**

No chat do GitHub Copilot:

```text
/opsx-explore

Quero adicionar uma funcionalidade de cadastro de usuários.
Analise a estrutura atual do projeto e identifique
as decisões necessárias antes da implementação.
```

**Passo 2 – Criar a proposta**

```text
/opsx-propose add-user-registration

Crie a especificação para implementar o cadastro de usuários,
considerando a arquitetura e os padrões existentes no projeto.
```

O OpenSpec criará os artefatos necessários para documentar a mudança:

```text
openspec/
└── changes/
    └── add-user-registration/
        ├── proposal.md
        ├── specs/
        │   └── users/
        │       └── spec.md
        ├── design.md
        └── tasks.md
```

**Passo 3 – Revisar a especificação**

Antes de implementar, revise:

- `proposal.md`: objetivo e escopo da funcionalidade.
- `specs/`: requisitos funcionais e cenários esperados.
- `design.md`: decisões e abordagem técnica.
- `tasks.md`: lista de tarefas necessárias para implementação.

Não avance para a implementação enquanto os requisitos e as decisões técnicas não estiverem alinhados.

**Passo 4 – Implementar**

No chat do GitHub Copilot:

```text
/opsx-apply
```

O agente utilizará os artefatos criados para implementar a funcionalidade e atualizar o progresso das tarefas.

**Passo 5 – Sincronizar as especificações**

Após validar a implementação:

```text
/opsx-sync
```

Esse comando sincroniza as especificações incrementais da mudança com as especificações principais do projeto.

**Passo 6 – Arquivar**

Após concluir a implementação:

```text
/opsx-archive
```

O OpenSpec arquivará a mudança concluída, mantendo o histórico do desenvolvimento.

## 7. Comandos úteis do OpenSpec

Os comandos abaixo são executados no terminal:

| Comando | Descrição |
|---|---|
| `openspec list` | Lista as mudanças em andamento. |
| `openspec list --specs` | Lista as especificações existentes. |
| `openspec view` | Exibe um painel com o estado das especificações e mudanças. |
| `openspec show <nome>` | Exibe os detalhes de uma especificação ou mudança. |
| `openspec validate <nome>` | Valida uma mudança ou especificação. |
| `openspec validate --all` | Valida todas as especificações e mudanças. |
| `openspec update` | Atualiza os arquivos de integração do OpenSpec. |
| `openspec version` | Exibe a versão e informações da instalação. |

## 8. Boas práticas

1. **Especifique antes de implementar:** não comece a desenvolver funcionalidades sem revisar seus requisitos.
2. **Respeite a arquitetura:** as decisões técnicas devem seguir os padrões já estabelecidos no projeto.
3. **Revise os artefatos:** a IA pode propor soluções incorretas ou incompletas.
4. **Mantenha as especificações atualizadas:** documente alterações de comportamento e requisitos.
5. **Implemente incrementalmente:** execute e valide as tarefas de forma organizada.
6. **Versione os artefatos:** mantenha os diretórios `openspec/` e `.github/` no Git.

## 9. Documentação oficial

- [OpenSpec – Documentação oficial](https://openspec.dev/docs)
- [OpenSpec – Quickstart](https://openspec.dev/docs/quickstart)
- [OpenSpec – CLI Reference](https://openspec.dev/docs/cli)
- [OpenSpec – Supported Tools](https://openspec.dev/docs/supported-tools)
- [OpenSpec – GitHub Repository](https://github.com/Fission-AI/OpenSpec)

---

# Cursos e Certificações Microsoft – GitHub Copilot e Applied Skills

## 1. Cursos oficiais de GitHub Copilot

Cursos **gratuitos** disponíveis na Microsoft Learn.

| Curso | Duração | Link |
|---|---|---|
| GitHub Copilot – Fundamentos Parte 1 | 5h17 | https://learn.microsoft.com/pt-br/training/paths/copilot/ |
| GitHub Copilot – Fundamentos Parte 2 | 3h27 | https://learn.microsoft.com/pt-br/training/paths/gh-copilot-2 |
| Introdução ao GitHub Copilot | 19 min | https://learn.microsoft.com/pt-br/training/modules/introduction-to-github-copilot/ |
|   |   |

## 2. Microsoft Applied Skills – Credenciais gratuitas

O Microsoft Applied Skills é um programa de credenciais práticas. Diferentemente das certificações tradicionais, você demonstra suas habilidades realizando uma avaliação baseada em laboratório.

### Desenvolvimento e GitHub Copilot

**Accelerate app development by using GitHub Copilot**

- Nível: Intermediário
- Área: Desenvolvimento de software
- Objetivo: Demonstrar capacidade de acelerar o desenvolvimento de aplicações utilizando GitHub Copilot.

[Microsoft Applied Skills: acelerar o desenvolvimento assistido por IA usando GitHub Copilot](https://learn.microsoft.com/pt-br/credentials/applied-skills/accelerate-app-development-by-using-github-copilot/)

### Azure e Inteligência Artificial

[Consulte o catálogo completo de Applied Skills com IA](https://learn.microsoft.com/pt-br/credentials/browse/?credential_types=applied%20skills&subjects=artificial-intelligence)

Áreas disponíveis:
- Azure
- Inteligência Artificial
- Desenvolvimento de software
- Segurança
- DevOps
- Dados
- Agentes de IA

## 3. Certificação oficial GitHub Copilot

**GitHub Copilot Certification**

- Nível: Intermediário
- Engenharia de prompts
- Recursos do GitHub Copilot
- Segurança e privacidade
- Produtividade no desenvolvimento

[Certificação GitHub Copilot](
https://learn.microsoft.com/credentials/certifications/github-copilot/)

**Observação**: a **certificação formal tem custo** e geralmente a preparação para o exame é gratuito.

[Guiga de estudo para o Exame GH-300: GitHub Copilot](https://learn.microsoft.com/pt-br/credentials/certifications/resources/study-guides/gh-300)

## 4. Ordem recomendada de estudo

1. GitHub Copilot Fundamentals – Parte 1.
2. GitHub Copilot Fundamentals – Parte 2.
3. Microsoft Applied Skills – GitHub Copilot.
4. Applied Skills voltadas para Azure AI e desenvolvimento de agentes.


## 5. Links principais

- Microsoft Learn: https://learn.microsoft.com/training/
- Microsoft Applied Skills: https://learn.microsoft.com/credentials/applied-skills/
- Certificações Microsoft: https://learn.microsoft.com/credentials/
- GitHub Copilot Documentation: https://docs.github.com/pt/copilot

---


# URL Shortener API (backend)

API de encurtamento de URLs em .NET 10 (Clean Architecture, Controllers, EF Core InMemory).

```bash
# executar (http://localhost:5254, OpenAPI em /openapi/v1.json em Development)
dotnet run --project backend/src/UrlShortener.Api --launch-profile http

# testar
dotnet test backend/UrlShortener.slnx
```

- `POST /api/urls` com `{ "originalUrl": "https://..." }` retorna `201` com `code` e `shortUrl`.
- `GET /{code}` redireciona (`302`) para a URL original, ou `404` se o código não existir.
- Os dados ficam em memória e são perdidos ao reiniciar a aplicação.
- Desvio consciente: o provider InMemory não suporta migrations nem connection string. O nome do banco vem de `Persistence:DatabaseName`.
