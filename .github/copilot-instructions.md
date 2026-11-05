# GitHub Copilot Instructions

## Metodologia de Desenvolvimento

Este projeto utiliza **OpenSpec** como framework para implementar Spec-Driven Development (SDD).

O OpenSpec é a fonte oficial de especificações, requisitos e decisões relacionadas à evolução do projeto.

### Diretrizes obrigatórias

1. **Consultar o OpenSpec:** Antes de implementar qualquer funcionalidade, consulte as especificações existentes no diretório `openspec/`.
2. **Seguir as especificações:** Toda implementação deve respeitar os requisitos, critérios de aceitação e decisões arquiteturais documentados nas especificações.
3. **Não assumir requisitos:** Não invente comportamentos ou regras de negócio que não estejam definidos. Solicite esclarecimentos quando necessário.
4. **Propor mudanças antes de implementar:** Para novas funcionalidades ou alterações relevantes, utilize o fluxo de mudanças do OpenSpec.
5. **Manter a documentação atualizada:** Toda alteração de comportamento deve refletir nas respectivas especificações.
6. **Respeitar as decisões arquiteturais:** Não introduza tecnologias, bibliotecas, padrões ou dependências que contrariem as definições existentes no OpenSpec.
7. **Implementação rastreável:** As alterações no código devem estar alinhadas às propostas, especificações e tarefas documentadas.

### Fluxo de desenvolvimento

Para implementar novas funcionalidades, siga o fluxo:

1. Analisar o contexto e os requisitos existentes.
2. Criar uma proposta de mudança utilizando OpenSpec.
3. Definir ou atualizar as especificações.
4. Elaborar o plano de implementação e as tarefas.
5. Implementar as alterações conforme as especificações aprovadas.
6. Executar os testes necessários.
7. Validar a implementação em relação aos critérios de aceitação.
8. Atualizar ou arquivar a mudança conforme o fluxo do OpenSpec.

### Estrutura do OpenSpec

O diretório `openspec/` contém os artefatos utilizados para orientar o desenvolvimento:

- `openspec/config.yaml`: configurações e contexto do projeto.
- `openspec/specs/`: especificações atuais do sistema.
- `openspec/changes/`: propostas de mudanças, especificações incrementais e tarefas.

### Regra principal

**O código deve implementar as especificações, e não as especificações justificar o código já implementado.**

O GitHub Copilot deve atuar de acordo com essa metodologia durante todas as etapas de análise, planejamento, implementação, revisão e manutenção do projeto.
