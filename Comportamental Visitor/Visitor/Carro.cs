// =============================================================================
// PADRÃO VISITOR - Carro (ConcreteElement A)
// =============================================================================
// Papel no padrão : ConcreteElement
// Correspondência : "ConcreteElementA" no diagrama UML do GoF
//
// Representa um veículo do tipo Carro na concessionária.
// Implementa ILoja (Element), podendo ser visitado por qualquer IVisitor.
//
// ⚙️  Double Dispatch em ação:
//   1º Despacho : cliente chama concessionaria.AplicarVisitor(visitor)
//                 → que chama carro.Accept(visitor)
//   2º Despacho : dentro do Accept, o Carro chama visitor.VisitarCarro(this)
//                 O visitor recebe o tipo concreto Carro — sem cast necessário.
//
// ✅ Esta classe NÃO é alterada para adicionar novas operações.
//    Novas funcionalidades são adicionadas criando novos ConcreteVisitors.
// =============================================================================

/// <summary>
/// ConcreteElement A: Carro.
/// Representa um carro da concessionária. Implementa ILoja para aceitar visitors.
/// As propriedades são públicas para que os visitors possam acessar os dados
/// sem violar o encapsulamento da lógica de negócio.
/// </summary>
public class Carro : ILoja
{
    public string Nome   { get; set; }
    public string Modelo { get; set; }
    public decimal Preco { get; set; }

    public Carro(string nome, string modelo, decimal preco)
    {
        Nome   = nome;
        Modelo = modelo;
        Preco  = preco;
    }

    /// <summary>
    /// Implementação do Accept: redireciona para o método VisitarCarro do visitor.
    /// Esta é a chave do Double Dispatch — o Carro sabe seu próprio tipo e
    /// chama o método visitor correspondente, evitando verificações de tipo externas.
    /// </summary>
    public void Accept(IVisitor visitor)
    {
        visitor.VisitarCarro(this); // 2º Despacho: chama o método específico para Carro
    }
}
