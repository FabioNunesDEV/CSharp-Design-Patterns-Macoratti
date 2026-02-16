# Mapa de Contexto — Solução `Facade` (Padrão Estrutural Facade)

Este documento resume a intenção do projeto e a função de cada arquivo/classe, servindo como **contexto rápido** para futuras modificações e estudos.

## Objetivo do projeto
Demonstrar o **padrão estrutural Facade (Fachada)** em um projeto Console (.NET 8), reduzindo o acoplamento do código cliente com um conjunto de classes de um subsistema (cadastro + consultas de crédito + validação de limite).

A Facade expõe uma operação de alto nível (`ConcederEmprestimo`) e internamente orquestra chamadas ao subsistema.

## Estrutura do projeto (arquivos relevantes)

### Ponto de entrada (cliente do padrão)
- `Facade/Program.cs`
  - **Papel:** Cliente/consumidor do padrão.
  - **Responsabilidade:** Criar a instância de `MeuFacade` e chamar `ConcederEmprestimo` em dois cenários (valor baixo e valor alto).
  - **Importante:** Não instancia nem chama diretamente as classes do subsistema.

### Facade
- `Facade/Facade/MeuFacade.cs`
  - **Namespace:** `Facade.Facade`
  - **Papel:** Fachada (Facade).
  - **Responsabilidade:**
    - Instanciar e manter referências aos componentes do subsistema:
      - `Cadastro`, `Serasa`, `Cadin`, `LimiteCredito`
    - Expor um método de alto nível:
      - `bool ConcederEmprestimo(Cliente cliente, double valor)`
  - **Fluxo do método `ConcederEmprestimo`:**
    1. Log inicial da concessão.
    2. `Cadastro.CadastrarCliente(cliente)`
    3. Regras de decisão (na ordem):
       - Se `Serasa.EstaNoSerasa(cliente)` negar.
       - Else se `Cadin.EstaNoCadin(cliente)` negar.
       - Else se `!LimiteCredito.PossuiLimiteCredito(cliente, valor)` negar.
       - Caso contrário conceder.
  - **Contrato principal:** devolver `true`/`false` e ocultar a complexidade/ordem do subsistema.

### Subsistema (classes internas que executam as tarefas)
- `Facade/Subsistemas/Cliente.cs`
  - **Namespace:** `Facade.Subsistemas`
  - **Papel:** Entidade simples usada no exemplo.
  - **API:** propriedade `Nome` + construtor `Cliente(string nome)`.

- `Facade/Subsistemas/Cadastro.cs`
  - **Papel:** simular cadastro do cliente.
  - **API:** `void CadastrarCliente(Cliente cliente)` (log no console).

- `Facade/Subsistemas/Serasa.cs`
  - **Papel:** simular verificação no Serasa.
  - **API:** `bool EstaNoSerasa(Cliente cliente)` (log + retorna `false` no exemplo).

- `Facade/Subsistemas/Cadin.cs`
  - **Papel:** simular verificação no CADIN.
  - **API:** `bool EstaNoCadin(Cliente cliente)` (log + retorna `false` no exemplo).

- `Facade/Subsistemas/LimiteCredito.cs`
  - **Papel:** validar limite de crédito.
  - **API:** `bool PossuiLimiteCredito(Cliente cliente, double valor)`.
  - **Regra atual (didática):** nega se `valor > 200000.00`.

## Saída/Comportamento esperado (resumo)
- Para um valor baixo (ex.: 5000): tende a conceder, pois Serasa/Cadin retornam `false`.
- Para um valor alto (ex.: 300000): deve negar por limite.

## Onde alterar quando precisar evoluir o exemplo
- **Mudar regra de crédito:** `Subsistemas/LimiteCredito.cs`.
- **Simular restrições reais:** `Subsistemas/Serasa.cs` e/ou `Subsistemas/Cadin.cs`.
- **Adicionar novas etapas no fluxo (novo subsistema):**
  - Criar nova classe em `Subsistemas/`
  - Orquestrar dentro de `Facade/MeuFacade.cs` (cuidar para não virar “God Object”).
- **Criar novos cenários de teste:** `Program.cs`.

## Observações de estudo (padrão)
- A Facade **não impede** o uso direto do subsistema; ela apenas fornece um atalho/fluxo de alto nível.
- Risco: a Facade crescer demais (antipadrão “God Object”). Se aumentar o escopo, considerar dividir em mais de uma fachada.

## Documentação/Instrucao no repositório
- `Facade/Instrucao/padroes de projetos.txt`: transcrição/anotações sobre o padrão.
- `Facade/Instrucao/Padrão Estrutural Facade.md`: resumo estruturado do conteúdo do padrão.
- `Facade/Instrucao/guru_facade.md`: referência (estilo Refactoring Guru) sobre Facade.
- `Facade/Instrucao/prompt.md`: prompt que descreve como recriar o projeto/exemplo.
