// =============================================================================
// PADRÃO VISITOR - Moto (ConcreteElement B)
// =============================================================================
// Papel no padrão : ConcreteElement
// Correspondência : "ConcreteElementB" no diagrama UML do GoF
//
// Representa um veículo do tipo Moto na concessionária.
// Implementa ILoja (Element), funcionando da mesma forma que Carro,
// porém redirecionando para visitor.VisitarMoto(this) no Accept.
//
// ⚙️  Double Dispatch:
//   Ao chamar Accept(visitor), a Moto chama visitor.VisitarMoto(this),
//   garantindo que o visitor execute a operação correta para o tipo Moto.
//
// ✅ Esta classe NÃO é alterada para adicionar novas operações.
// =============================================================================

/// <summary>
/// ConcreteElement B: Moto.
/// Representa uma moto da concessionária. Implementa ILoja para aceitar visitors.
/// </summary>
public class Moto : ILoja
{
    public string Nome   { get; set; }
    public string Modelo { get; set; }
    public decimal Preco { get; set; }

    public Moto(string nome, string modelo, decimal preco)
    {
        Nome   = nome;
        Modelo = modelo;
        Preco  = preco;
    }

    /// <summary>
    /// Implementação do Accept: redireciona para o método VisitarMoto do visitor.
    /// O tipo concreto Moto é passado para o visitor sem necessidade de cast.
    /// </summary>
    public void Accept(IVisitor visitor)
    {
        visitor.VisitarMoto(this); // 2º Despacho: chama o método específico para Moto
    }
}
