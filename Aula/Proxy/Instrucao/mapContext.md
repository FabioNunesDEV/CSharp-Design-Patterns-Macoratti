# Mapa de contexto (Context Map) – Projeto `Proxy` (C# 12 / .NET 8)

Este documento descreve, de forma objetiva, **como o código deste projeto funciona**, quais são os **papéis do padrão Proxy**, e como as classes se relacionam. A intenção é servir como **contexto rápido** para uso com IA (ex.: ChatGPT/Copilot) ao tirar dúvidas, gerar diagramas, ou recriar o projeto.

---

## Objetivo do projeto

Demonstrar o padrão de projeto estrutural **Proxy**, na variação **Proxy de Proteção**.

- Existe um recurso “sensível” (uma **pasta compartilhada** com informações confidenciais).
- O acesso ao recurso deve ser controlado por um objeto intermediário (o **proxy**).
- Somente usuários com perfil **`CEO`** podem executar a operação.

---

## Visão geral do fluxo

1. O cliente (`Program.cs`) cria um `Funcionario` com um `Perfil`.
2. O cliente cria `PastaCompartilhadaProxy`, passando o `Funcionario`.
3. O cliente chama `OperacaoDeLeituraGravacao()` no proxy.
4. O proxy valida o perfil:
   - Se `Perfil.ToUpper() == "CEO"`:
     - instancia o objeto real (`PastaCompartiolhada`)
     - registra uma mensagem no console
     - delega a chamada ao objeto real
   - caso contrário:
     - registra uma mensagem de acesso negado

Esse fluxo garante que o cliente **não acessa** o objeto real diretamente (controle de acesso centralizado no proxy).

---

## Papéis do padrão Proxy no projeto

| Papel (Proxy pattern) | Elemento no projeto | Descrição |
|---|---|---|
| **Subject** | `IPastaCompartilhada` | Interface/contrato comum. Permite que `Proxy` e `RealSubject` sejam usados de forma intercambiável. |
| **RealSubject** | `PastaCompartiolhada` | Implementa a operação real (leitura/gravação). No exemplo, apenas escreve uma mensagem no console. |
| **Proxy** | `PastaCompartilhadaProxy` | Controla o acesso ao `RealSubject` com base no perfil do funcionário e delega a chamada quando permitido. |
| **Client** | `Program.cs` | Demonstra a execução chamando o proxy com diferentes perfis. |

---

## Arquivos e responsabilidades

### `Program.cs` (Client)

- Script/cliente com *top-level statements*.
- Executa 3 cenários (Programador, Usuário, CEO) e chama o proxy.
- Serve apenas para demonstrar o padrão.

### `Funcionario.cs`

- Estrutura de dados simples com:
  - `Nome`, `Senha`, `Perfil`.
- No exemplo, apenas `Perfil` é usado na regra de autorização.

### `IPastaCompartilhada.cs` (Subject)

- Declara o método: `void OperacaoDeLeituraGravacao();`
- Mantém o contrato comum para `Proxy` e `RealSubject`.

### `PastaCompartiolhada.cs` (RealSubject)

- Implementa `IPastaCompartilhada`.
- Executa a operação “real” (simulada via `Console.WriteLine`).

> Observação: o nome `PastaCompartiolhada` contém um typo proposital e deve ser preservado para manter compatibilidade com o projeto.

### `PastaCompartilhadaProxy.cs` (Proxy)

- Implementa `IPastaCompartilhada`.
- Mantém referência a:
  - `Funcionario` (contexto para autorização)
  - `IPastaCompartilhada pasta` (onde será armazenado o `RealSubject`)
- Regra de acesso:
  - permite apenas `CEO` (comparação via `ToUpper()`)
- Quando permitido:
  - instancia `PastaCompartiolhada` (inicialização sob demanda)
  - delega a operação

---

## Regras e invariantes importantes

- A autorização é feita exclusivamente por:
  - `funcionario.Perfil.ToUpper() == "CEO"`
- O `Program.cs` demonstra acesso negado para perfis não-CEO.
- O proxy é responsável por decidir quando criar e usar o objeto real.
- O objetivo é didático: o “trabalho real” é apenas uma mensagem no console.

---

## Mensagens esperadas no console (para validação rápida)

- Sempre imprime o cabeçalho do exemplo.
- Para Programador e Usuário: imprime mensagem de acesso negado.
- Para CEO: imprime mensagem do proxy informando que está invocando o objeto real + mensagem do RealSubject.

---

## Como pedir ajuda à IA (sugestões de prompts)

- “Explique o papel de cada classe segundo o padrão Proxy usando o arquivo `mapContext.md` como referência.”
- “Gere um diagrama UML (Mermaid ou PlantUML) para este projeto com base no `mapContext.md`.”
- “Crie testes unitários que validem que apenas `CEO` executa a operação real (sem alterar a regra de autorização).”
- “Recrie este projeto do zero mantendo nomes e textos exatamente iguais (ver também `prompt.md`).”
