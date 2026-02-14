**Data:** 2026-02-14
**Link**: [C# - Apresentando o Padrão Composite](https://www.youtube.com/watch?v=eroPRZ0M6fc&list=PLJ4k1IC8GhW1L7fOWe238fetknEfBmG1I&index=10)
**Curso:** Padrões de Projeto
**Professor**: #Jose-Carlos-Macoratti
**Instituição:** #youtube 

**Tags:** #Padrões-Projetos #Programação #Código-Limpo #Boas-Praticas

### Conteúdo
----------------
# Padrão Estrutural Composite

O **Composite** é um padrão estrutural do GoF que permite compor objetos em uma estrutura semelhante a uma árvore para representar hierarquias do tipo **parte-todo**.

A ideia central do padrão é permitir que o cliente trate **objetos individuais** e **composições de objetos** de forma **uniforme**, ou seja, como se fossem um único objeto.

Esse padrão é especialmente útil quando o problema pode ser modelado como uma estrutura hierárquica em árvore.

![[2.33.10-Imagem-A.png]]

---

## Conceito Fundamental

O padrão Composite:

- Organiza objetos em uma estrutura de árvore.
    
- Permite executar operações recursivamente em toda a estrutura.
    
- Faz com que objetos simples (folhas) e objetos compostos sejam tratados da mesma forma pelo cliente.
    

Em outras palavras:

> Se uma operação pode ser realizada em um objeto simples, ela também deve poder ser realizada em um objeto composto.

---

## Exemplo Conceitual – Computador

Considere um computador como um conjunto de partes:

- Computador
    
    - Gabinete
        
        - Placa-mãe
            
            - CPU
                
            - RAM
                
    - Periféricos
        
        - Mouse
            
        - Teclado
            

Nesse cenário:

- **Computador, Gabinete, Placa-mãe e Periféricos** são objetos compostos.
    
- **CPU, RAM, Mouse e Teclado** são objetos folha (primitivos).
    

Se for possível obter o preço de um Mouse, também deve ser possível obter:

- O preço dos Periféricos
    
- O preço do Gabinete
    
- O preço do Computador inteiro
    

A operação é a mesma, mas o comportamento é diferente internamente.  
Nos compostos, a operação é aplicada de forma recursiva aos seus filhos.

---

## Estrutura do Padrão Composite

O padrão possui três elementos principais:

### 1. Component

É uma interface ou classe abstrata.

Define as operações comuns que devem ser implementadas por:

- Objetos folha
    
- Objetos compostos
    

Ela representa o contrato comum da hierarquia.

---

### 2. Leaf (Folha)

Representa um objeto simples.

- Não possui filhos.
    
- Implementa as operações definidas no Component.
    
- Executa diretamente o comportamento.
    

É o nó terminal da árvore.

---

### 3. Composite

Representa um objeto composto.

- Possui filhos (que podem ser Leaf ou outros Composite).
    
- Implementa a interface Component.
    
- Gerencia os elementos filhos.
    
- Executa operações de forma recursiva sobre os filhos.
    

Normalmente contém métodos como:

- Adicionar filho
    
- Remover filho
    
- Percorrer filhos
    

---

### Cliente

O cliente trabalha apenas com o tipo **Component**.

Ele não precisa saber se está lidando com:

- Um objeto simples (Leaf)
    
- Um objeto composto (Composite)
    

Isso garante a uniformidade de uso.

---

## Quando Usar o Composite

O padrão é indicado quando:

- O problema pode ser representado como uma estrutura em árvore.
    
- Precisamos representar hierarquias parte-todo.
    
- Queremos que o cliente ignore a diferença entre objetos simples e compostos.
    
- Precisamos executar operações recursivamente sobre uma estrutura hierárquica.
    

---

## Vantagens

- Permite tratar objetos simples e compostos de maneira uniforme.
    
- Simplifica o código cliente.
    
- Facilita a navegação em estruturas hierárquicas.
    
- Permite aplicar operações recursivas de forma natural.
    
- Melhora a extensibilidade da estrutura.
    

---

## Desvantagens

- Pode tornar o design excessivamente genérico.
    
- Pode dificultar a restrição de quais objetos podem ou não ser compostos.
    
- Pode aumentar a complexidade da modelagem quando o domínio não é naturalmente hierárquico.
    

---

## Exemplo Prático – Organização e Departamentos

### Cenário

Uma organização possui:

- Departamentos
    
- Funcionários
    

Cada funcionário registra horas trabalhadas.

Precisamos:

- Obter as horas de cada funcionário.
    
- Calcular o total de horas por departamento.
    
- Calcular o total geral da organização.
    

### Hierarquia

- Organização (Composite)
    
    - Departamentos (Composite)
        
        - Funcionários (Leaf)
            

### Modelagem Conceitual

**Component**  
Classe abstrata que declara a operação comum:

- Obter horas trabalhadas
    

**Leaf – Funcionário**

- Representa um nó terminal.
    
- Retorna suas próprias horas trabalhadas.
    

**Composite – Organização/Departamento**

- Contém uma coleção de Component.
    
- Percorre seus filhos.
    
- Soma as horas recursivamente.
    
- Calcula o total.
    

### Funcionamento

1. Funcionários retornam suas horas individuais.
    
2. Departamentos somam as horas dos seus funcionários.
    
3. A organização soma as horas de todos os departamentos.
    
4. O cliente invoca apenas a operação comum definida no Component.
    

O cálculo é feito de forma recursiva e transparente para o cliente.

---

## Ideia-Chave do Composite

O ponto mais importante do padrão é:

> Permitir que objetos individuais e composições de objetos sejam tratados da mesma maneira.

Isso elimina condicionais do tipo:

- Se for simples faz isso
    
- Se for composto faz aquilo
    

O polimorfismo resolve o problema.

---

## Resumo Final

O Composite é um padrão estrutural voltado para:

- Estruturas hierárquicas
    
- Relações parte-todo
    
- Execução recursiva de operações
    

Ele organiza objetos em forma de árvore e permite que o cliente interaja com todos eles através de uma interface comum, simplificando o código e promovendo uniformidade.

É um padrão extremamente útil quando o domínio do problema possui naturalmente uma estrutura hierárquica.


### Complementos externos
---------
