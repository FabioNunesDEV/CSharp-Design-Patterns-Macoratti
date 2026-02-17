# Mapa de Contexto — Exemplo do padrão Flyweight (C# / .NET 8)

Este documento descreve o **contexto do código** do projeto `Flyweight`, servindo como referência rápida para futuras manutenções, refatorações e extensões.

## 1) Visão geral

- **Tipo de app:** Console
- **Framework alvo:** .NET 8
- **Padrão demonstrado:** **Flyweight** (estrutural)
- **Objetivo:** reduzir consumo de memória ao **compartilhar instâncias** que possuem **estado intrínseco** (constante) e receber o **estado extrínseco** (variável) em tempo de execução.

O exemplo implementa um único tipo de forma (`Circulo`). A variação (cor) é atribuída em runtime, enquanto os dados fixos do círculo permanecem no objeto compartilhado.

## 2) Conceitos do padrão aplicados no projeto

### Estado intrínseco (compartilhável)

- Dados constantes, iguais para várias “instâncias lógicas”.
- No projeto:
  - `x`, `y`, `raio` dentro de `Circulo`.

### Estado extrínseco (não compartilhável)

- Dados variáveis conforme o contexto/chamada.
- No projeto:
  - `Cor` (propriedade de `Circulo`), definida pelo cliente a cada uso via `SetCor`.

### Cache / Reuso

- O reuso é feito por um cache em `FormaFactory.formas`.
- A chave (`string chave`) identifica o Flyweight (no exemplo: `"circulo"`).

## 3) Estrutura de arquivos e responsabilidades

### `IForma.cs`

- Papel no padrão: **Flyweight (Interface)**.
- Responsabilidade:
  - Definir o contrato comum: `void Desenhar();`.

### `Circulo.cs`

- Papel no padrão: **ConcreteFlyweight**.
- Responsabilidades:
  - Armazenar o **estado intrínseco** (`x`, `y`, `raio`).
  - Receber/usar o **estado extrínseco** (`Cor`).
  - Expor:
    - `SetCor(string cor)`
    - `Desenhar()` (imprime estado intrínseco + extrínseco)

### `FormaFactory.cs`

- Papel no padrão: **FlyweightFactory**.
- Responsabilidades:
  - Controlar criação e reuso de Flyweights através de cache.
  - API:
    - `public static Dictionary<string, IForma> formas`
    - `public static IForma GetForma(string chave)`
- Regra:
  - Se a chave existir no dicionário, retorna a instância existente.
  - Se não existir e a chave for suportada (`"circulo"`), cria e adiciona ao cache.

### `Program.cs`

- Papel no padrão: **Client**.
- Responsabilidades:
  - Solicitar instâncias via `FormaFactory.GetForma("circulo")`.
  - Definir o estado extrínseco (cor) antes de chamar `Desenhar()`.
  - Exibir a contagem de instâncias criadas no cache, validando o reuso.

## 4) Fluxo de execução (alto nível)

1. `Program` faz loop por cores.
2. Em cada iteração:
   - chama `FormaFactory.GetForma("circulo")`.
   - recebe sempre a mesma instância cacheada (após a primeira criação).
   - ajusta `Cor` via `SetCor`.
   - chama `Desenhar()`.
3. Ao final, imprime `FormaFactory.formas.Count`.

## 5) Invariantes / Comportamento esperado

- O cache deve conter **apenas 1** instância para a chave `"circulo"`.
- `FormaFactory.formas.Count` deve ser `1` após execução do exemplo.
- A saída no console deve mostrar `Desenhar()` sendo chamado várias vezes com cores diferentes.

## 6) Pontos de atenção para futuras alterações

- **Concorrência:** `Dictionary` estático não é thread-safe. Se houver uso concorrente, considerar `ConcurrentDictionary`.
- **Estado extrínseco:** como a instância é compartilhada, a escrita em `Cor` pode causar interferência entre usos simultâneos.
- **Extensibilidade:** ao adicionar novas formas (ex.: `Quadrado`), será necessário:
  - criar nova classe que implemente `IForma`
  - decidir o estado intrínseco/específico
  - adaptar `FormaFactory.GetForma(...)` para aceitar novas chaves
- **Imutabilidade:** em um Flyweight mais estrito, o estado intrínseco deve ser imutável (por exemplo, inicializado no construtor e sem setters).

## 7) Referências (materiais do repositório)

- `Flyweight\Instrucao\transcricao_aula.txt`
- `Flyweight\Instrucao\Padrão Estrutural Flyweight.md`
- `Flyweight\Instrucao\material_site.txt`
- `Flyweight\Instrucao\prompt.md`
