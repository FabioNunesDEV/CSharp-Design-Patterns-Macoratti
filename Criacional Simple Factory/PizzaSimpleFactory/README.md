# PizzaSimpleFactory — Simple Factory (Fábrica Simples)

Este projeto demonstra o padrão de projeto **Simple Factory** usando o domínio de **pizzas** como exemplo.

A ideia central do padrão é **centralizar a lógica de criação de objetos** (instanciação) em um único ponto (a “fábrica”), reduzindo acoplamento entre quem **pede** um objeto e as **implementações concretas** existentes.

---

## Visão geral do fluxo

1. O programa inicia e chama a “pizzaria”.
2. A pizzaria recebe o pedido (tipo de pizza).
3. A pizzaria **não instancia** diretamente uma pizza concreta.
4. Em vez disso, delega a criação para a **fábrica**.
5. A fábrica decide qual classe concreta instanciar e devolve um objeto do tipo base `Pizza`.
6. A pizzaria trabalha com a abstração (`Pizza`) e executa o processo comum (por exemplo: preparar/assar/entregar, conforme implementado).

---

## Estrutura e responsabilidade de cada arquivo

### `Program.cs`
**O que faz:**
- Ponto de entrada da aplicação.
- Dispara a execução inicial chamando o fluxo principal da “pizzaria” (por exemplo, `PizzaSimpleFactory.Pizzaria.SolicitaPizza();`).

**Importância para o Simple Factory:**
- Mantém o *bootstrap* do app simples.
- Não participa da criação de pizzas; apenas inicia o caso de uso.

---

### `Pizzaria.cs`
**O que faz:**
- Implementa o “cliente” do padrão: o componente que **precisa** de pizzas para executar o caso de uso.
- Solicita a criação de uma pizza por tipo e executa o fluxo de negócio associado ao pedido (o passo a passo para atender o pedido).

**Importância para o Simple Factory:**
- É o principal beneficiado pelo padrão: em vez de conter vários `new PizzaCalabreza()` / `new PizzaMussarela()`, delega a criação.
- Passa a depender primariamente da abstração `Pizza`, evitando acoplamento com classes concretas.

---

### `PizzaSimpleFactory.cs`
**O que faz:**
- Implementa a **fábrica simples**.
- Contém um método que, a partir de um identificador (ex.: string/enum com o tipo), cria e retorna a pizza correta.

**Importância para o Simple Factory:**
- Centraliza a lógica de instanciação.
- Torna a manutenção mais direta: para adicionar um novo tipo, a alteração de criação fica concentrada na fábrica.

**Observação:**
- O Simple Factory normalmente usa uma decisão condicional (ex.: `switch`) para escolher a implementação concreta. Isso é esperado neste padrão.

---

### `Pizza.cs`
**O que faz:**
- Define o **tipo base** (classe base ou abstrata) para todas as pizzas.
- Consolida o contrato comum e/ou comportamento compartilhado.

**Importância para o Simple Factory:**
- Permite que a fábrica retorne um tipo comum (`Pizza`), e o cliente (`Pizzaria`) trabalhe com a abstração.
- Reduz o acoplamento: a pizzaria não precisa conhecer detalhes das subclasses.

---

### `PizzaCalabreza.cs`
**O que faz:**
- Implementa uma pizza concreta: “Calabreza”.
- Contém detalhes específicos dessa variação (ingredientes, nome, comportamento especializado, etc.).

**Importância para o Simple Factory:**
- Representa um dos “produtos concretos” que a fábrica pode criar.
- Demonstra como novas variações podem ser adicionadas como novas classes, mantendo o cliente estável.

---

### `PizzaMussarela.cs`
**O que faz:**
- Implementa uma pizza concreta: “Mussarela”.
- Contém detalhes específicos dessa variação (ingredientes, nome, comportamento especializado, etc.).

**Importância para o Simple Factory:**
- Outro “produto concreto” criado pela fábrica.
- Ajuda a evidenciar o papel da fábrica em encapsular a seleção/instanciação do tipo correto.

---

## Como o padrão ajuda aqui

- **Menos acoplamento:** `Pizzaria` não sabe quais classes concretas existem.
- **Um ponto de mudança:** se a forma de criar pizzas mudar, você mexe principalmente na fábrica.
- **Código cliente mais limpo:** o fluxo de negócio fica separado da lógica de instanciação.

---

## Quando evoluir além do Simple Factory

Em sistemas maiores, quando a lógica condicional na fábrica começa a crescer muito, é comum evoluir para padrões como **Factory Method** ou **Abstract Factory**, dependendo da necessidade.
