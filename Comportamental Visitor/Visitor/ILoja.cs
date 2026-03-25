// =============================================================================
// PADRÃO VISITOR - ILoja (Interface Element / Elemento)
// =============================================================================
// Papel no padrão : Element
// Correspondência : Interface "ILoja" no diagrama da aula /
//                   "Element" no diagrama UML do GoF
//
// Define o contrato Accept que cada ConcreteElement deve implementar.
// O método Accept recebe um IVisitor como argumento e delega a execução
// para o método Visit correspondente no visitor — iniciando o Double Dispatch.
//
// ⚙️  Por que Accept recebe IVisitor (e não o tipo concreto)?
//   Porque o elemento precisa trabalhar com QUALQUER visitor, não apenas
//   com um tipo específico. Isso garante o desacoplamento entre os elementos
//   e os visitors.
// =============================================================================

/// <summary>
/// Interface Element: define o método Accept que permite a qualquer IVisitor
/// visitar o elemento. É o ponto de entrada do Double Dispatch no padrão Visitor.
/// </summary>
public interface ILoja
{
    /// <summary>
    /// Aceita um visitante e delega a ele a operação a ser realizada.
    /// O elemento implementa este método chamando o método visitor correto
    /// e passando 'this' como argumento (Double Dispatch).
    /// </summary>
    void Accept(IVisitor visitor);
}
