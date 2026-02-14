# Context Map — Projeto `Composite` (.NET 8)

## Visão geral
Projeto Console em **.NET 8 / C# 12** que demonstra o padrão estrutural **Composite**.

**Domínio do exemplo:** cálculo do total de **horas trabalhadas** em uma estrutura hierárquica (árvore) composta por:
- **Organização/Departamentos** (nós compostos)
- **Funcionários** (nós folha)

A mesma operação `GetHoraTrabalhada()` é aplicada de forma **uniforme** em toda a árvore, usando **polimorfismo** e **recursão**.

---

## Estrutura do projeto (pastas/arquivos)

- `Composite/Composite.csproj`
  - Projeto Console (`OutputType=Exe`)
  - `TargetFramework=net8.0`
  - `ImplicitUsings=enable`, `Nullable=enable`

- `Composite/Component/HoraTrabalhada.cs`
  - **Component** do Composite (classe base abstrata)

- `Composite/Leaf/Funcionario.cs`
  - **Leaf** do Composite (não possui filhos)

- `Composite/Composite/Organizacao.cs`
  - **Composite** do Composite (contém filhos: folhas e/ou outros composites)

- `Composite/Program.cs`
  - **Cliente**: monta a árvore e dispara o cálculo

- `Composite/Instrucoes/`
  - `refactoring_guru.md`: referência conceitual do padrão Composite (tradução/explicação)
  - `padroes de projetos.txt`: transcrição/roteiro explicativo do exemplo e do padrão
  - `Padrão Estrutural Composite.md`: resumo estruturado do padrão + cenário do exemplo
  - `prompt.txt`: prompt para recriar a solução (arquitetura + arquivos + comentários)
  - `contextMap.md`: este mapa de contexto

---

## Papéis no padrão Composite (mapeamento)

### `HoraTrabalhada` — Component
Arquivo: `Composite/Component/HoraTrabalhada.cs`

Responsabilidades:
- Define o **contrato comum** para folhas e composites.
- Expõe:
  - `Nome`: nome do nó (pode ser funcionário, departamento ou organização)
  - `GetHoraTrabalhada()`: operação principal da árvore (calcular/retornar horas)
  - `Add(...)`/`Remove(...)`: operações de composição (por padrão lançam `NotImplementedException`)

Pontos importantes:
- `Add`/`Remove` são `virtual` e **não** são obrigatórios para folhas.
- A uniformidade do padrão vem do cliente chamar apenas `GetHoraTrabalhada()` sem checar tipos.

---

### `Funcionario` — Leaf
Arquivo: `Composite/Leaf/Funcionario.cs`

Responsabilidades:
- Nó terminal: **não possui filhos**.
- Mantém e retorna suas horas:
  - `Id`: identificador apenas para exibição
  - `Horas`: horas registradas
- `GetHoraTrabalhada()`:
  - Escreve log no console
  - Retorna `Horas`

Pontos importantes:
- Não sobrescreve `Add`/`Remove`. Se chamado, lança exceção via implementação da base.

---

### `Organizacao` — Composite
Arquivo: `Composite/Composite/Organizacao.cs`

Responsabilidades:
- Nó composto: contém uma coleção de filhos (`List<HoraTrabalhada>`).
- `Add`/`Remove` gerenciam os filhos.
- `GetHoraTrabalhada()`:
  - Itera pelos filhos
  - Soma `child.GetHoraTrabalhada()` (**recursão** se o filho também for `Organizacao`)
  - Escreve total no console
  - Retorna o total

Pontos importantes:
- A lista aceita qualquer `HoraTrabalhada` (folha ou composite).
- O cálculo total surge do somatório recursivo da subárvore.

---

### `Program.cs` — Cliente
Arquivo: `Composite/Program.cs`

Responsabilidades:
- Monta a árvore exemplo:
  - Raiz: `"Secretária Administrativa"`
  - Departamentos:
    - `"Departamento de TI"`
    - `"Departamento de Compras"`
  - Subdepartamento:
    - `"Departamento de RH"` como filho de TI
  - Folhas (funcionários) com horas

- Executa:
  - `organizacao.GetHoraTrabalhada();`
  - `Console.ReadKey();`

Pontos importantes:
- Demonstra que o cliente não precisa saber se está chamando em folha ou composite.

---

## Fluxo de execução (alto nível)
1. `Program.cs` cria objetos `Organizacao` (composites) e `Funcionario` (folhas).
2. A árvore é montada via `Add()`.
3. O cliente chama `GetHoraTrabalhada()` apenas na raiz.
4. `Organizacao.GetHoraTrabalhada()`:
   - chama `GetHoraTrabalhada()` em cada filho
   - filho folha retorna horas
   - filho composite calcula suas próprias somas
5. Console exibe logs por funcionário e totais por departamento/organização.

---

## Alterações comuns (guias rápidos)

### 1) Trocar o domínio (ex.: preço de produtos/caixas)
- Renomear `HoraTrabalhada` para algo como `Item`/`Componente`.
- Trocar `GetHoraTrabalhada()` para `GetPreco()`.
- Em `Funcionario`, virar `Produto`.
- Em `Organizacao`, virar `Caixa`.

### 2) Restringir o que pode ser filho
Atualmente `Organizacao` aceita qualquer `HoraTrabalhada`.
- Se precisar restringir (ex.: depto não pode conter depto X), implementar validação em `Add`.

### 3) Evitar exceções em `Add/Remove` para folhas
Se preferir comportamento “no-op” (não recomendado para didática):
- Sobrescrever `Add`/`Remove` em `Funcionario` para não lançar exceção.

### 4) Melhorar logs / visualização da árvore
- Adicionar nível/indentação no `GetHoraTrabalhada()` do composite.
- Passar profundidade como parâmetro (ou armazenar contexto de impressão).

---

## Referências internas do repositório
- `Composite/Instrucoes/refactoring_guru.md`
- `Composite/Instrucoes/padroes de projetos.txt`
- `Composite/Instrucoes/Padrão Estrutural Composite.md`
- `Composite/Instrucoes/prompt.txt`
