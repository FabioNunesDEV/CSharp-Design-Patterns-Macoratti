# Map Context - `SingletonMultiThread`

Este documento descreve o contexto essencial do projeto `SingletonMultiThread` para facilitar futuras interações (manutenção, evolução e explicações) envolvendo o exemplo do padrão criacional **Singleton** em ambiente **multithread**.

## Visão geral

- **Objetivo:** demonstrar um **Singleton thread-safe** controlando acesso concorrente a um **recurso compartilhado** (um arquivo `log.txt`).
- **Abordagem:** múltiplas threads tentam escrever no mesmo arquivo; a exclusão mútua é garantida por `lock`.
- **Efeito demonstrado:** a escrita no arquivo ocorre de forma **serializada** (uma thread por vez), com o arquivo “bloqueado” por **1 segundo** durante cada escrita.

## Plataforma e configurações

- SDK/Projeto: Console App (`Exe`)
- Target Framework: `.NET 8` (`net8.0`)
- `ImplicitUsings`: `enable`
- `Nullable`: `enable`

Arquivo de projeto:

- `SingletonMultiThread/SingletonMultiThread.csproj`

## Estrutura de arquivos (principais)

- `SingletonMultiThread/Program.cs`
  - Orquestra o teste com **4 threads**.
  - Gera o conteúdo (3 parágrafos por thread) e solicita a escrita via Singleton.

- `SingletonMultiThread/Singleton.cs`
  - Implementa o **Singleton thread-safe**.
  - Centraliza a escrita no arquivo de log com `lock`.

## Fluxo de execução

1. O programa define o caminho do log como:
   - `Path.Combine(AppContext.BaseDirectory, "log.txt")`
   - Observação: `AppContext.BaseDirectory` aponta, em geral, para a pasta de saída (`bin/.../net8.0`).
2. Se existir `log.txt`, ele é removido para garantir um teste “limpo”.
3. São criadas **4 threads** (`Thread-1` a `Thread-4`).
4. Cada thread:
   - Monta um texto com cabeçalho + 3 parágrafos + rodapé.
   - Chama `Singleton.Instance.WriteToLog(logFilePath, content)`.
5. O `Main` aguarda todas finalizarem (`Join`).

## Recurso compartilhado

- Arquivo: `log.txt`
- Operação concorrente: escrita (`append`) por múltiplas threads.
- Estratégia: sincronização de acesso com `lock` dentro da classe `Singleton`.

## Detalhes do Singleton thread-safe

Arquivo: `SingletonMultiThread/Singleton.cs`

- Campo estático `_instance` guarda a referência da instância única.
- `_lockObject` é o objeto “cadeado” usado para sincronização.
- A propriedade `Instance` utiliza **verificação dupla** (*double-check locking*):
  - Checa `_instance` antes do `lock` (caminho rápido após inicialização).
  - Checa novamente dentro do `lock` para evitar condição de corrida.

### Escrita no log

Método: `WriteToLog(string logFilePath, string message)`

- Executa `lock (_lockObject)` para garantir exclusão mútua na escrita.
- Cria o diretório do log, se necessário (`Directory.CreateDirectory`).
- Faz append com `File.AppendAllText`.
- Mantém o bloqueio por **1 segundo** (`Thread.Sleep(TimeSpan.FromSeconds(1))`) para evidenciar o comportamento de serialização.

## Como executar

Via CLI:

- `dotnet run --project SingletonMultiThread/SingletonMultiThread.csproj`

## Resultado esperado

- No console:
  - Mensagens com timestamp indicando quando cada thread solicitou e concluiu a escrita.
- No arquivo `log.txt`:
  - 4 blocos completos (um por thread), sem linhas “intercaladas” entre threads.

