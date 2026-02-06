**Data:** 2026-02-04
**Link**: [C# - Padrão Singleton](https://www.youtube.com/watch?v=7M8Oq4XT3Is&list=PLJ4k1IC8GhW1L7fOWe238fetknEfBmG1I&index=7)
**Curso:** Padrões de Projeto
**Professor**: #Jose-Carlos-Macoratti
**Instituição:** #youtube 

**Tags:** #Padrões-Projetos #Programação #Código-Limpo #Boas-Praticas

### Conteúdo
----------------
# Padrão Criacional Singleton

## Definição

O **Singleton** é um padrão de projeto criacional cuja principal finalidade é **garantir que uma classe possua apenas uma única instância**, além de **fornecer um ponto de acesso global a essa instância**.

Esse padrão é utilizado quando se deseja controlar rigorosamente o acesso a um recurso compartilhado, evitando múltiplas criações do mesmo objeto ao longo da aplicação.

## Intenção do Padrão

Os dois objetivos centrais do Singleton são:

- Garantir que apenas **uma instância** da classe exista durante todo o ciclo de vida da aplicação  
- Fornecer um **ponto de acesso global**, controlado e seguro, a essa instância

Dessa forma, o Singleton evita duplicações indesejadas e centraliza o controle de recursos críticos.

## Estrutura Conceitual

Os principais elementos conceituais do padrão Singleton são:

- Um **campo estático** que mantém a referência para a única instância da classe  
- Um **construtor privado**, impedindo que a classe seja instanciada externamente  
- Um **método ou propriedade estática** responsável por criar a instância (caso ainda não exista) e retorná-la

Essa estrutura impede a criação direta de objetos e garante que o controle da instância fique exclusivamente dentro da própria classe.

## Exemplos de Uso

O Singleton é comumente utilizado nos seguintes cenários:

- Controle de acesso a **recursos compartilhados**, como conexões com banco de dados ou arquivos  
- Implementações de **log**, onde múltiplas partes do sistema precisam registrar informações em um único destino  
- Armazenamento e compartilhamento de **configurações globais** da aplicação  
- Classes utilitárias que **não mantêm estado**, mas precisam ser acessadas globalmente

## Quando Usar o Singleton

O uso do padrão Singleton pode ser considerado quando:

- Faz sentido que a classe tenha **apenas uma instância**  
- É necessário um ponto de acesso único e bem definido ao objeto  
- O objeto representa um recurso compartilhado e sensível

## Quando Não Usar o Singleton

O padrão Singleton **não deve ser utilizado** nos seguintes casos:

- Como substituto de **variáveis globais**  
- Quando a classe precisa permitir **múltiplas instâncias**  
- Quando o acoplamento global pode dificultar testes, manutenção ou evolução do sistema

Usar Singleton como acesso irrestrito a dados globais é considerado uma má prática.

## Problemas em Ambientes Multithread

Uma implementação básica de Singleton pode funcionar corretamente em aplicações de thread única, porém **não é segura em ambientes multithread**.

Em cenários com múltiplas threads, pode ocorrer a criação simultânea de mais de uma instância, violando o princípio do padrão.

## Singleton Thread-Safe

Para garantir o funcionamento correto em ambientes concorrentes, é necessário:

- Sincronizar o acesso ao ponto de criação da instância  
- Garantir que apenas uma thread possa criar a instância por vez  

Isso evita condições de corrida e assegura que a instância seja criada apenas uma única vez.

## Otimização com Verificação Dupla

Uma abordagem mais eficiente é a chamada **verificação dupla**, que consiste em:

- Verificar se a instância já existe antes de aplicar qualquer mecanismo de bloqueio  
- Aplicar o bloqueio apenas se a instância ainda não tiver sido criada  

Essa técnica reduz o custo de sincronização após a instância já estar disponível, tornando a implementação mais eficiente.

## Considerações Finais

O padrão Singleton é simples em conceito, mas exige cuidado na implementação, especialmente em aplicações modernas que utilizam múltiplas threads.

Quando bem aplicado, ele garante controle, consistência e segurança no acesso a recursos compartilhados. Quando mal utilizado, pode introduzir acoplamento excessivo e dificultar a manutenção do sistema.

### Complementos externos
---------
