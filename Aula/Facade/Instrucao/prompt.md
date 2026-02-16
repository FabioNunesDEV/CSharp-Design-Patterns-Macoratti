# Prompt — Padrão Estrutural Facade (Exemplo: Concessão de Empréstimo)

Crie um projeto Console em **.NET 8 (C# 12)** demonstrando o **padrão estrutural Facade** com um exemplo de **concessão de empréstimo**.

## Requisitos do código

### 1) Estrutura de pastas/namespaces
- `Facade/Facade` com a classe `MeuFacade` no namespace `Facade.Facade`
- `Facade/Subsistemas` com as classes no namespace `Facade.Subsistemas`:
  - `Cliente`
  - `Cadastro`
  - `Serasa`
  - `Cadin`
  - `LimiteCredito`

### 2) Classes do subsistema (simples e didáticas, usando `Console.WriteLine`)
- `Cliente`
  - Propriedade `Nome` (`string`) com `get; set;`
  - Construtor `Cliente(string nome)` que atribui `Nome`
- `Cadastro`
  - Método `void CadastrarCliente(Cliente cliente)` que imprime: `Cliente '{Nome}' cadastrado com sucesso.`
- `Serasa`
  - Método `bool EstaNoSerasa(Cliente cliente)` que imprime: `Verificando o Serasa para o cliente {Nome}` e retorna `false`
- `Cadin`
  - Método `bool EstaNoCadin(Cliente cliente)` que imprime: `Verificando o CADIN para o cliente {Nome}` e retorna `false`
- `LimiteCredito`
  - Método `bool PossuiLimiteCredito(Cliente cliente, double valor)` que imprime: `Verificando o limite de crédito para o cliente {Nome}`
  - Regra: se `valor > 200000.00` retorna `false`, senão `true`

### 3) Classe Facade
- `MeuFacade` deve possuir campos privados:
  - `LimiteCredito limite;`
  - `Cadastro cadastro;`
  - `Serasa serasa;`
  - `Cadin cadin;`
- Construtor instancia todos esses componentes.
- Método `bool ConcederEmprestimo(Cliente cliente, double valor)`:
  - imprime: `Concedendo empréstimo para o cliente {Nome} no valor de {valor}\n`
  - chama `cadastro.CadastrarCliente(cliente)`
  - aplica regras na ordem:
    1) se `serasa.EstaNoSerasa(cliente)` -> imprime `Empréstimo negado: cliente está no Serasa.` e retorna `false`
    2) else se `cadin.EstaNoCadin(cliente)` -> imprime `Empréstimo negado: cliente está no Cadin.` e retorna `false`
    3) else se `!limite.PossuiLimiteCredito(cliente, valor)` -> imprime `Empréstimo negado: valor solicitado ({valor}) excede o limite disponível.` e retorna `false`
  - caso passe em tudo, retorna `true`

### 4) `Program.cs` (top-level statements)
- criar `MeuFacade concederCreditoFacade = new MeuFacade();`
- Cenário 1:
  - `Cliente cliente1 = new Cliente("João");`
  - `bool resultado1 = concederCreditoFacade.ConcederEmprestimo(cliente1, 5000);`
  - imprimir: `O emprestimo pleiteado pelo cliente {Nome} foi {concedido/negado}\n\r`
- Cenário 2:
  - `Cliente cliente2 = new Cliente("Maria");`
  - `bool resultado2 = concederCreditoFacade.ConcederEmprestimo(cliente2, 300000);`
  - imprimir igual ao cenário 1
- `Console.ReadLine();`

## Observações
- Use exatamente esses nomes de classes/métodos/strings (acentos incluídos).
- Pode incluir comentários/XML docs explicando Facade vs subsistema, mas o comportamento e saída devem ficar iguais.
- Entregue o conteúdo completo de todos os arquivos `.cs` criados.
