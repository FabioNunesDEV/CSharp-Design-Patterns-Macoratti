# Prompt — Projeto exemplo do padrão Flyweight (C# / .NET 8)

Crie um projeto **Console App** em **C# (.NET 8)** que demonstre o padrão de projeto estrutural **Flyweight**, com o mesmo objetivo e estrutura do exemplo clássico de “muitos círculos com cores diferentes”.

## Objetivo do exemplo

Demonstrar como o Flyweight **reduz o consumo de memória** ao **reutilizar (cachear) objetos** que compartilham o **estado intrínseco** (parte fixa/constante) e receber o **estado extrínseco** (parte variável) em tempo de execução.

- **Estado intrínseco (compartilhável):** coordenadas `x`, `y` e `raio` do círculo.
- **Estado extrínseco (variável por contexto):** `cor`.

A aplicação deve reutilizar o mesmo objeto `Circulo` ao trocar apenas a cor antes de desenhar.

## Estrutura esperada de arquivos

Crie os seguintes arquivos dentro do projeto:

- `IForma.cs`
- `Circulo.cs`
- `FormaFactory.cs`
- `Program.cs`

Use o namespace `Flyweight`.

## Requisitos de implementação

### 1) `IForma` (Flyweight)

- Interface `IForma` com o método:
  - `void Desenhar();`

### 2) `Circulo` (ConcreteFlyweight)

- Classe `Circulo : IForma`.
- Deve conter:
  - Propriedade pública `string Cor { get; set; }` (estado **extrínseco**).
  - Campos privados `x`, `y`, `raio` inicializados com valores fixos (estado **intrínseco**), por exemplo: `10`, `20`, `30`.
  - Método `SetCor(string cor)` que atribui a cor.
  - Método `Desenhar()` que imprime no console algo como:

  `Circulo: Desenhar() [Cor: {Cor}, x: {x}, y: {y}, raio: {raio}]`

### 3) `FormaFactory` (FlyweightFactory)

- Classe `FormaFactory` com:
  - Um cache **estático**:

    `public static Dictionary<string, IForma> formas = new Dictionary<string, IForma>();`

  - Um método **estático** `GetForma(string chave)` que:
    - Se `formas` contiver a `chave`, retorne a instância existente.
    - Caso contrário, se `chave == "circulo"`, crie um novo `Circulo`, adicione ao dicionário e retorne.
    - Para outras chaves, lance uma exceção com mensagem clara.

### 4) `Program` (Client)

No `Program.cs`, simule o uso repetido do Flyweight:

- Para cada cor, rode um `for` com 3 iterações:
  - Obtenha o círculo via `FormaFactory.GetForma("circulo")`.
  - Faça cast para `Circulo`.
  - Atribua a cor via `SetCor(...)`.
  - Chame `Desenhar()`.

Faça isso para as cores:

- Amarelo
- Vermelho
- Verde
- Azul

Ao final, mostre a quantidade de objetos realmente criados (tamanho do cache):

`Quantidade de objetos criados: {FormaFactory.formas.Count}`

O resultado esperado é que a contagem seja **1**, demonstrando o reuso da instância.

## Observações

- O foco é evidenciar a separação entre **intrínseco** (compartilhado) e **extrínseco** (fornecido pelo cliente).
- Inclua comentários curtos nos arquivos explicando o papel de cada classe no padrão (Client, Flyweight, ConcreteFlyweight, FlyweightFactory).

## Entregável

- Projeto compilando em `.NET 8`.
- Saída no console demonstrando múltiplos desenhos com cores diferentes, mas apenas **1** instância criada no cache.
