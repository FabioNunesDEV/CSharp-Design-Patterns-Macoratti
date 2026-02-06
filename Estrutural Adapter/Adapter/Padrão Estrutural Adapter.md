**Data:** 2026-02-05
**Link**: [C# - Padrão Estrutural - Adapter](https://www.youtube.com/watch?v=HElHbc0yvl8&list=PLJ4k1IC8GhW1L7fOWe238fetknEfBmG1I&index=8)
**Curso:** Padrões de Projeto
**Professor**: #Jose-Carlos-Macoratti
**Instituição:** #youtube 

**Tags:** #Padrões-Projetos #Programação #Código-Limpo #Boas-Praticas
### Conteúdo
----------------
# Padrão Estrutural – Adapter

## Introdução aos Padrões Estruturais
Os padrões estruturais tratam da **composição de classes e objetos**, explicando como montar estruturas maiores mantendo **flexibilidade e eficiência**.  
Eles focam em como classes e objetos se relacionam e são compostos entre si, tendo como característica principal a **composição de objetos**.

Os sete padrões estruturais do GoF são:
- Adapter  
- Bridge  
- Composite  
- Decorator  
- Facade  
- Flyweight  
- Proxy  

Um mnemônico comum para memorizá-los associa esses padrões a ideias do dia a dia, reforçando que todos lidam com **estrutura e organização** dos objetos.

---

## Definição do Padrão Adapter
O **padrão Adapter** atua como uma **ponte entre duas interfaces incompatíveis**.  
Ele envolve uma classe chamada **adaptador**, responsável por permitir a comunicação entre interfaces independentes ou incompatíveis.

Esse padrão é conhecido também como **Wrapper (invólucro)**, pois encapsula uma classe existente e expõe uma nova interface compatível com o que o cliente espera.

---

## Intenções do Padrão Adapter
As principais intenções do Adapter são:
- Converter a interface de uma classe em outra interface esperada pelo cliente  
- Envolver (wrap) uma classe existente com uma nova interface  
- Introduzir componentes legados em novos sistemas  
- Permitir a comunicação entre sistemas ou classes incompatíveis  

O objetivo central é **permitir colaboração entre objetos que não foram projetados para trabalhar juntos**.

---

## Exemplos Conceituais de Uso
Um cenário comum é quando:
- Um sistema fornece dados em **XML**
- Uma biblioteca de processamento espera dados em **JSON**

As interfaces são incompatíveis. O Adapter entra como intermediário, convertendo os dados de XML para JSON e permitindo que a biblioteca processe as informações corretamente.

Outro exemplo clássico é o de **tomadas e plugues de diferentes países**.  
O adaptador universal permite que dispositivos incompatíveis funcionem juntos, ilustrando perfeitamente o papel do padrão Adapter.

---

## Participantes do Padrão Adapter
Os principais participantes são:
- **Target**: define a interface esperada pelo cliente  
- **Adaptee (Adaptado)**: classe existente com a funcionalidade necessária, porém com interface incompatível  
- **Adapter**: implementa a interface Target e traduz as chamadas para o Adaptee  
- **Client**: utiliza apenas a interface Target, sem conhecer o Adaptee diretamente  

O cliente interage somente com o **Target**, mantendo o baixo acoplamento.

---

## Princípios de Orientação a Objetos Envolvidos
O padrão Adapter aplica diversos princípios importantes:
- Composição de objetos  
- Programar para interfaces, não para implementações  
- Delegação de responsabilidades  
- Separação entre cliente e implementação concreta  

Esses princípios ajudam a manter o código flexível e reutilizável.

---

## Tipos de Adapter
Existem duas formas principais de implementar o padrão Adapter:

### Adapter de Objeto
- Baseado em **composição**
- O Adapter mantém uma referência ao Adaptee  
- É a forma mais comum e amplamente utilizada  
- Compatível com a maioria das linguagens orientadas a objetos  

### Adapter de Classe
- Baseado em **herança**
- O Adapter herda de Target e Adaptee  
- Requer suporte a herança múltipla  
- Usado em linguagens que permitem esse recurso  

A principal diferença está no uso de **composição versus herança**.

---

## Quando Utilizar o Padrão Adapter
O Adapter é indicado quando:
- É necessário usar uma classe existente cuja interface é incompatível  
- Deseja-se reutilizar código legado em um novo contexto  
- Sistemas distintos precisam se comunicar sem alterações internas  

Ele é especialmente útil em integrações e evolução de sistemas.

---

## Vantagens do Padrão Adapter
- Aumenta a reutilização de código  
- Facilita a integração entre sistemas distintos  
- Permite a convivência entre código novo e legado  
- Reduz o impacto de mudanças em sistemas existentes  

---

## Desvantagens do Padrão Adapter
- Pode aumentar a complexidade do sistema  
- Introduz novas classes e interfaces  
- Em cenários muito complexos, pode dificultar a manutenção  

Mesmo assim, os benefícios geralmente superam os custos quando há incompatibilidade de interfaces.

---

## Considerações Finais
O padrão Adapter é uma solução elegante para **problemas de incompatibilidade entre interfaces**, muito comum em sistemas reais.  
Ele permite evolução, integração e reutilização sem a necessidade de alterar código existente, mantendo os princípios da orientação a objetos e promovendo um design mais flexível.



### Complementos externos
---------
