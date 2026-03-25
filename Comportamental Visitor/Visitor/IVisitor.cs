// =============================================================================
// PADRÃO VISITOR - IVisitor (Interface Visitor / Visitante)
// =============================================================================
// Papel no padrão : Visitor
// Correspondência : Interface "Visitor" no diagrama UML do GoF
//
// Declara um método Visit para cada ConcreteElement presente na estrutura.
// Cada ConcreteVisitor implementará esses métodos com lógicas distintas.
//
// ⚙️  Double Dispatch:
//   O tipo correto do elemento só é conhecido em tempo de execução.
//   O visitor recebe o elemento já com seu tipo concreto como argumento
//   e executa a operação correta — sem if/switch baseado em tipo.
//
// ✅ Princípio Aberto/Fechado (OCP):
//   Para adicionar uma nova operação, basta criar um novo ConcreteVisitor
//   que implemente esta interface. Carro e Moto não precisam ser alterados.
// =============================================================================

/// <summary>
/// Interface Visitor: declara os métodos de visita para cada ConcreteElement.
/// Para adicionar uma nova operação à estrutura, crie um novo ConcreteVisitor
/// que implemente esta interface — sem modificar Carro ou Moto.
/// </summary>
public interface IVisitor
{
    // Um método Visit para cada tipo de ConcreteElement da estrutura.
    // Isso permite que o Visitor identifique o tipo exato do elemento
    // com o qual está trabalhando (sem casting ou verificação de tipo).

    /// <summary>Visita um elemento do tipo Carro (ConcreteElementA).</summary>
    void VisitarCarro(Carro carro);

    /// <summary>Visita um elemento do tipo Moto (ConcreteElementB).</summary>
    void VisitarMoto(Moto moto);
}
