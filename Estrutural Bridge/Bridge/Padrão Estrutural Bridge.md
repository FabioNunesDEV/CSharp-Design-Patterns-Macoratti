**Data:** 2026-02-07
**Link**: [C# - Apresentando o Padrão Bridge](https://www.youtube.com/watch?v=cub-nXT2H-E&list=PLJ4k1IC8GhW1L7fOWe238fetknEfBmG1I&index=9)
**Curso:** Padrões de Projeto
**Professor**: #Jose-Carlos-Macoratti
**Instituição:** #youtube 

**Tags:** #Padrões-Projetos #Programação #Código-Limpo #Boas-Praticas

### Conteúdo
----------------
# Padrão Estrutural Bridge

## Visão Geral
O padrão **Bridge** é um padrão estrutural cujo objetivo principal é **desacoplar uma abstração da sua implementação**, permitindo que ambas evoluam de forma **independente**.  
Ele atua dividindo uma classe maior em **duas hierarquias distintas**: uma de abstração e outra de implementação.

A ideia central é separar **o que o objeto faz** (abstração) de **como ele faz** (implementação), reduzindo acoplamento e aumentando flexibilidade.

## Motivação
Em muitos sistemas, uma classe cresce demais ao concentrar tanto regras de negócio quanto detalhes técnicos.  
Isso dificulta manutenção, evolução e reutilização.

O Bridge resolve esse problema ao:
- Separar responsabilidades
- Evitar dependência direta entre abstração e implementação
- Permitir variações independentes em ambos os lados

## Conceito Fundamental
O padrão Bridge introduz uma **interface intermediária**, chamada de *bridge*, que atua como uma ponte entre:
- A **classe de abstração**
- As **classes concretas de implementação**

Dessa forma:
- O cliente interage apenas com a abstração
- A abstração delega o trabalho para a implementação
- A implementação pode ser trocada em tempo de execução

## Estrutura Conceitual
O padrão é composto por duas hierarquias independentes:

### Hierarquia de Abstração
- Define o comportamento de alto nível
- Contém uma referência para a interface do implementador
- Pode ser estendida por subclasses que refinam a abstração

### Hierarquia de Implementação
- Define os detalhes técnicos da funcionalidade
- É acessada apenas através da interface bridge
- Pode ter múltiplas implementações concretas

Essas hierarquias não dependem diretamente uma da outra.

## Participantes do Padrão

### Abstraction
- Classe abstrata
- Define a interface de alto nível do objeto
- Mantém uma referência para o implementador
- Delegação das operações para o implementador

### Refined Abstraction
- Especialização da abstração
- Pode adicionar ou alterar comportamentos
- Continua independente das implementações concretas

### Implementor
- Interface que define os métodos que as implementações concretas devem fornecer
- Atua como a ponte entre abstração e implementação

### Concrete Implementor
- Implementações concretas da interface Implementor
- Contêm os detalhes técnicos reais da funcionalidade

### Cliente
- Trabalha apenas com a abstração
- Não conhece nem depende das implementações concretas

## Exemplo Conceitual de Aplicação
Um cenário típico envolve persistência de dados:
- A abstração representa a persistência
- As implementações concretas podem salvar dados em:
  - Sistema de arquivos
  - Banco de dados
  - Outros meios

A abstração não precisa ser alterada ao adicionar ou remover uma forma de persistência.

Outro exemplo clássico envolve:
- Processamento de regras de negócio (abstração)
- Geração de saída em diferentes formatos (implementação)
  - XML
  - JSON
  - Texto
  - PDF

O formato é decidido em tempo de execução, sem impactar a regra de negócio.

## Quando Usar o Padrão Bridge
- Quando se deseja **ocultar detalhes de implementação do cliente**
- Para evitar **forte acoplamento** entre abstração e implementação
- Quando a implementação pode mudar sem recompilar a abstração
- Quando diferentes objetos compartilham uma implementação comum
- Quando abstração e implementação precisam evoluir de forma independente

## Vantagens
- Reduz acoplamento entre abstração e implementação
- Facilita manutenção e evolução do sistema
- Aumenta reutilização de código
- Reduz duplicação de lógica
- Promove o princípio **Aberto/Fechado**
- Melhora extensibilidade do sistema

## Desvantagens
- Aumenta a quantidade de classes no sistema
- Pode elevar a complexidade estrutural
- Requer bom entendimento do domínio para separar corretamente responsabilidades
- Nem sempre é adequado para cenários simples

## Relação com Outros Padrões
O padrão Bridge possui estrutura semelhante ao **Adapter**, porém:
- **Adapter** é usado para adaptar sistemas já existentes
- **Bridge** é aplicado principalmente no **design de novos sistemas**

## Conclusão
O padrão Bridge é uma solução poderosa para sistemas que precisam ser flexíveis, extensíveis e de fácil manutenção.  
Ele permite separar claramente regras de negócio de detalhes técnicos, possibilitando mudanças seguras e independentes em ambas as partes.



### Complementos externos
---------
[Otávio Miranda (282) Bridge Teoria - Padrões de Projeto - Parte 18/45 - YouTube](https://www.youtube.com/watch?v=-gsuMWLxAko)

[Rafactoring Guru - Bridge em C# / Padrões de Projeto](https://refactoring.guru/pt-br/design-patterns/bridge)