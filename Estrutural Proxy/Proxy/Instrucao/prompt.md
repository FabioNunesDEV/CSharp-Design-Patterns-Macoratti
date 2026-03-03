# Prompt – reconstruir este projeto (Padrão Estrutural Proxy em C#/.NET 8)

Use este prompt para pedir ao ChatGPT (ou outro LLM) para gerar um projeto **o mais idêntico possível** ao exemplo implementado neste repositório.

---

## Prompt para o ChatGPT

Você é um assistente de programação. Gere um projeto **Console** em **C# 12 / .NET 8** que implemente o padrão de projeto estrutural **Proxy** (Proxy de Proteção) exatamente com a seguinte estrutura, nomes e comportamento.

### Requisitos gerais

- Linguagem/SDK: **C# 12** e **.NET 8**.
- Tipo de app: **Console**.
- Namespace para todas as classes: `Proxy`.
- O projeto deve compilar e executar.
- Use `Console.WriteLine` para demonstrar as mensagens.
- A implementação deve estar o mais próxima possível do padrão Proxy descrito abaixo.

### Estrutura de arquivos (relativa à raiz do projeto)

Crie os seguintes arquivos (com os nomes exatamente como listados):

- `Program.cs`
- `Funcionario.cs`
- `IPastaCompartilhada.cs`
- `PastaCompartiolhada.cs`  
  **Observação importante:** o nome do arquivo e da classe deve ser exatamente `PastaCompartiolhada` (com esse typo mesmo).
- `PastaCompartilhadaProxy.cs`

### Descrição do cenário

Uma empresa possui um computador com uma **pasta compartilhada** contendo informações confidenciais.
Somente um funcionário com perfil **CEO** pode executar a operação de leitura/gravação nessa pasta.

O cliente nunca deve acessar diretamente o objeto real sem passar pelo proxy.

### Papéis do padrão Proxy (obrigatório seguir)

- `IPastaCompartilhada` é o **Subject** (contrato comum)
- `PastaCompartiolhada` é o **RealSubject** (serviço real)
- `PastaCompartilhadaProxy` é o **Proxy** (proxy de proteção)
- `Program.cs` é o **Client** (demonstra a execução)

### Conteúdo de cada arquivo

#### `Funcionario.cs`

- Classe `Funcionario` com propriedades públicas (get/set):
  - `Nome` (`string`)
  - `Senha` (`string`)
  - `Perfil` (`string`)
- Construtor `Funcionario(string nome, string senha, string perfil)` que atribui os valores.

#### `IPastaCompartilhada.cs`

- Interface `IPastaCompartilhada` com o método:
  - `void OperacaoDeLeituraGravacao();`

#### `PastaCompartiolhada.cs` (RealSubject)

- Classe `PastaCompartiolhada` que implementa `IPastaCompartilhada`.
- Implementação de `OperacaoDeLeituraGravacao()` deve escrever exatamente:

`### Operação de leitura e gravação realizada na pasta compartilhada ###`

#### `PastaCompartilhadaProxy.cs` (Proxy de Proteção)

- Classe `PastaCompartilhadaProxy` que implementa `IPastaCompartilhada`.
- Campos privados:
  - `private IPastaCompartilhada pasta;`
  - `private Funcionario funcionario;`
- Construtor `PastaCompartilhadaProxy(Funcionario funcionario)` que atribui o campo.
- Método `OperacaoDeLeituraGravacao()`:
  - Verifique permissão com: `if (funcionario.Perfil.ToUpper() == "CEO")`
  - Se for CEO:
    - Instancie o RealSubject: `pasta = new PastaCompartiolhada();`
    - Escreva exatamente:

`O proxy 'Pasta Compartilhada' invoca a pasta Real: 'método usado: OperacaoDeLeituraGravacao()'`

(Com uma quebra de linha ao final `\n`)

    - Depois delegue para `pasta.OperacaoDeLeituraGravacao();`
  - Se não for CEO:
    - Escreva exatamente:

`O proxy 'Pasta Compartilhada' avisa: 'Você não tem permissão para acessar esta pasta'`

(Com uma quebra de linha ao final `\n`)

#### `Program.cs` (Client)

- Deve conter (top-level statements) a mesma sequência de escrita e chamadas:

1) Escreva:

`### Exemplo de implementação do padrão Proxy ###`

2) Teste 3 casos, nesta ordem, criando `Funcionario` e chamando o proxy:

- Programador:
  - Escreva:

`\nFuncionário com perfil 'Programador' acessando a Pasta Compartilhada Proxy`

  - Crie: `Funcionario funcionario = new Funcionario("MAcoratti","123456","Programador");`
  - Crie: `PastaCompartilhadaProxy pastaCompartilhadaProxy = new PastaCompartilhadaProxy(funcionario);`
  - Chame: `pastaCompartilhadaProxy.OperacaoDeLeituraGravacao();`

- Usuário:
  - Escreva:

`\nFuncionário com perfil 'Usuário' acessando a Pasta Compartilhada Proxy`

  - Reatribua: `pastaCompartilhadaProxy = new PastaCompartilhadaProxy(new Funcionario("Fábio","654321","Usuário"));`
  - Chame: `pastaCompartilhadaProxy.OperacaoDeLeituraGravacao();`

- CEO:
  - Escreva:

`\nFuncionário com perfil 'CEO' acessando a Pasta Compartilhada Proxy`

  - Reatribua: `pastaCompartilhadaProxy = new PastaCompartilhadaProxy(new Funcionario("Maria","123654","CEO"));`
  - Chame: `pastaCompartilhadaProxy.OperacaoDeLeituraGravacao();`

3) Finalize com `Console.Read();`

### Observações finais

- Não invente funcionalidades extras.
- Não mude nomes de classes/arquivos.
- Não altere a lógica de permissão.
- Gere o código completo de cada arquivo.
