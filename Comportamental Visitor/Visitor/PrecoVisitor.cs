// =============================================================================
// PADRÃO VISITOR - PrecoVisitor (ConcreteVisitor A)
// =============================================================================
// Papel no padrão : ConcreteVisitor
// Correspondência : "ConcreteVisitorA" no diagrama UML do GoF
//
// Responsável por calcular e exibir o preço com desconto dos veículos.
// Esta é uma NOVA OPERAÇÃO adicionada à estrutura sem modificar Carro ou Moto.
//
// ✅ Princípio Aberto/Fechado (OCP):
//   As classes Carro e Moto estão FECHADAS para modificação,
//   mas ABERTAS para extensão através de novos Visitors.
//
// ✅ Princípio da Responsabilidade Única (SRP):
//   Toda a lógica de desconto está centralizada aqui,
//   fora das classes de domínio (Carro, Moto).
// =============================================================================

/// <summary>
/// ConcreteVisitor A: PrecoVisitor.
/// Implementa a operação de cálculo de desconto no preço dos veículos.
/// Aplica percentuais de desconto distintos para Carros e Motos.
/// </summary>
public class PrecoVisitor : IVisitor
{
    private const decimal DescontoCarro = 0.10m; // 10% de desconto em carros
    private const decimal DescontoMoto  = 0.05m; //  5% de desconto em motos

    /// <summary>
    /// Visita um Carro e exibe o preço com desconto de 10%.
    /// Recebe o tipo concreto Carro — acessa as propriedades diretamente.
    /// </summary>
    public void VisitarCarro(Carro carro)
    {
        decimal precoComDesconto = carro.Preco * (1 - DescontoCarro);

        Console.WriteLine($"  Carro : {carro.Nome,-10} {carro.Modelo,-20} | " +
                          $"Preco: {carro.Preco,14:C} | " +
                          $"Desconto: {DescontoCarro:P0} | " +
                          $"Com desconto: {precoComDesconto,14:C}");
    }

    /// <summary>
    /// Visita uma Moto e exibe o preço com desconto de 5%.
    /// Recebe o tipo concreto Moto — acessa as propriedades diretamente.
    /// </summary>
    public void VisitarMoto(Moto moto)
    {
        decimal precoComDesconto = moto.Preco * (1 - DescontoMoto);

        Console.WriteLine($"  Moto  : {moto.Nome,-10} {moto.Modelo,-20} | " +
                          $"Preco: {moto.Preco,14:C} | " +
                          $"Desconto: {DescontoMoto:P0} | " +
                          $"Com desconto: {precoComDesconto,14:C}");
    }
}
