**Data:** 2026-02-16
**Link**: [C# - Apresentando o Padrão Facade](https://www.youtube.com/watch?v=QKcwvOJexqg&list=PLJ4k1IC8GhW1L7fOWe238fetknEfBmG1I&index=12)
**Curso:** Padrões de Projeto
**Professor**: #Jose-Carlos-Macoratti
**Instituição:** #youtube 

**Tags:** #Padrões-Projetos #Programação #Código-Limpo #Boas-Praticas

### Conteúdo
----------------
# Padrão Estrutural Facade

O **Padrão Estrutural Facade** (Fachada), definido no livro _Design Patterns_ do **Gang of Four (GoF)**, tem como principal objetivo **fornecer uma interface unificada e simplificada para um conjunto de interfaces em um subsistema complexo**.

De forma simples, o Facade atua como uma **fachada** que esconde a complexidade interna de um sistema, expondo apenas o que o cliente realmente precisa enxergar.

![[2.33.12-Imagem-A.png]]
## Intenção do Padrão

O padrão Facade:

- Fornece uma interface de nível mais alto.
    
- Simplifica o uso de um subsistema complexo.
    
- Esconde detalhes internos de implementação.
    
- Reduz a dependência direta do cliente com múltiplas classes.
    

Em outras palavras, ele fica no topo de um grupo de classes (subsistema) e permite que elas sejam acessadas de maneira unificada e simplificada.

---

## Problema que o Facade Resolve

Imagine um sistema onde, para realizar uma operação simples, o cliente precise:

- Criar várias instâncias.
    
- Invocar métodos em sequência.
    
- Conhecer a ordem correta das chamadas.
    
- Lidar com múltiplos detalhes internos.
    

Isso gera:

- Alto acoplamento.
    
- Complexidade para o cliente.
    
- Dificuldade de manutenção.
    

O Facade resolve esse problema criando uma **classe intermediária** que centraliza essas chamadas e expõe apenas um método simplificado.

---

## Exemplo Conceitual – Sistema de Vendas

Em um sistema hipotético de vendas, para registrar um pedido seria necessário:

1. Obter detalhes do produto.
    
2. Processar o pagamento.
    
3. Emitir e enviar nota fiscal.
    

Sem o Facade, o cliente teria que:

- Instanciar cada classe envolvida.
    
- Executar os métodos na ordem correta.
    
- Tratar cada etapa manualmente.
    

Com o Facade, criamos uma classe (por exemplo, `Pedido`) com um método como `GravarPedido()`, que:

- Instancia as classes necessárias.
    
- Executa as operações internas.
    
- Encapsula toda a lógica do processo.
    

Agora, o cliente precisa apenas chamar um único método.

A complexidade continua existindo, mas está **oculta atrás da fachada**.

---

## Estrutura do Padrão (Segundo o GoF)

Os participantes do padrão são:

### 1. Facade

- Conhece quais classes do subsistema são responsáveis por cada solicitação.
    
- Delegar as chamadas para os objetos apropriados.
    
- Fornece a interface simplificada para o cliente.
    

### 2. Classes do Subsistema

- Implementam as funcionalidades reais.
    
- Não possuem conhecimento sobre a existência da Facade.
    
- Podem ser utilizadas diretamente, se necessário.
    

Um ponto importante: o subsistema **continua acessível**, o Facade não impede o acesso direto — ele apenas oferece uma forma mais simples de utilização.

---

## Exemplo Conceitual – Sistema de Concessão de Crédito

Considere um sistema de análise de crédito com operações como:

- Cadastro de cliente.
    
- Verificação em órgãos de restrição (como Serasa e Cadin).
    
- Cálculo de limite de crédito.
    
- Avaliação final para concessão do empréstimo.
    

Sem o Facade, o cliente teria que:

- Instanciar cada classe.
    
- Executar cada verificação manualmente.
    
- Coordenar toda a lógica.
    

Com o Facade:

- Criamos uma classe (por exemplo, `MeuFacade`).
    
- Expondo um método como `ConcederEmprestimo()`.
    
- Internamente, ele chama cadastro, consulta restrições e calcula limite.
    
- Retorna apenas o resultado final.
    

O cliente interage apenas com uma única classe e um único método.

---

## Quando Usar o Padrão Facade

Devemos usar o Facade quando:

- Queremos simplificar uma sequência de operações complexas.
    
- Precisamos fornecer uma interface única e uniforme.
    
- Desejamos reduzir o acoplamento entre cliente e subsistema.
    
- Estamos trabalhando com arquitetura em camadas.
    
- Queremos definir um ponto de entrada para cada camada.
    

É um padrão muito utilizado, muitas vezes até de forma inconsciente.

---

## Vantagens

- Reduz o acoplamento entre cliente e subsistema.
    
- Isola o cliente das mudanças internas.
    
- Facilita manutenção e evolução do sistema.
    
- Simplifica o uso de APIs complexas.
    
- Melhora a organização quando usado em arquiteturas em camadas.
    

O baixo acoplamento permite alterar componentes internos sem impactar diretamente os clientes.

---

## Desvantagens

- Introduz uma camada adicional no sistema.
    
- Pode aumentar a complexidade estrutural.
    
- Pode gerar dependências excessivas concentradas na Facade.
    
- Exige manutenção quando políticas específicas de clientes são adicionadas.
    

### Risco Importante: Objeto Deus (God Object)

Se mal implementado, o Facade pode se transformar em um **God Object**, concentrando responsabilidades demais.

Isso é considerado um antipadrão.

Por isso, é fundamental respeitar o princípio da responsabilidade única (SRP).

---

## Diferença Entre Facade e Adapter

Embora parecidos estruturalmente, possuem intenções diferentes:

### Adapter

- Altera uma interface para torná-la compatível com outra.
    
- Resolve problemas de incompatibilidade.
    

### Facade

- Não altera a interface.
    
- Apenas fornece uma interface mais simples e de alto nível.
    
- Reduz complexidade.
    

A principal diferença está na **intenção do padrão**.

---

## Relação com Abstract Factory

O padrão Abstract Factory pode ser visto como uma espécie de Facade para criação de objetos, pois fornece uma interface unificada para criar famílias de objetos relacionados.

---

## Como Identificar um Facade

Podemos reconhecer um Facade quando:

- Existe uma classe com interface simples.
    
- Ela delega a maior parte do trabalho para outras classes.
    
- O cliente não precisa conhecer o subsistema interno.
    
- A classe atua como ponto central de acesso.
    

---

## Conclusão

O Padrão Estrutural Facade é uma solução elegante para:

- Esconder complexidade.
    
- Reduzir acoplamento.
    
- Simplificar o uso de subsistemas.
    
- Melhorar a organização arquitetural.
    

Ele não elimina a complexidade — apenas a encapsula.

Quando bem aplicado, melhora a legibilidade, manutenção e evolução do sistema. Quando mal aplicado, pode se tornar um ponto de acoplamento excessivo e virar um antipadrão.

O segredo está no equilíbrio e no respeito aos princípios do SOLID.


### Complementos externos
---------
