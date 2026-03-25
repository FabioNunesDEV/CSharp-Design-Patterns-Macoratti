// =============================================================================
// PADRÃO VISITOR - RelatorioVisitor (ConcreteVisitor B)
// =============================================================================
// Papel no padrão : ConcreteVisitor
// Correspondência : "ConcreteVisitorB" no diagrama UML do GoF
//
// Responsável por gerar um relatório de inventário dos veículos.
// Demonstra que múltiplos Visitors independentes podem ser criados,
// cada um com sua própria lógica, sem alterar os elementos (Carro, Moto).
//
// ✅ Cada nova operação exige apenas um novo ConcreteVisitor.
//    O ObjectStructure (Concessionaria) e os elementos permanecem intocados.
// =============================================================================

/// <summary>
/// ConcreteVisitor B: RelatorioVisitor.
/// Gera um relatório de inventário formatado dos veículos da concessionária.
/// Nova operação adicionada sem modificar Carro, Moto ou Concessionaria.
/// </summary>
public class RelatorioVisitor : IVisitor
{
    private int _contador = 0;

    /// <summary>
    /// Visita um Carro e registra suas informações no relatório.
    /// </summary>
    public void VisitarCarro(Carro carro)
    {
        _contador++;
        Console.WriteLine($"  [{_contador:D2}] CARRO | {carro.Nome,-10} | " +
                          $"Modelo: {carro.Modelo,-20} | " +
                          $"Preco de tabela: {carro.Preco:C}");
    }

    /// <summary>
    /// Visita uma Moto e registra suas informações no relatório.
    /// </summary>
    public void VisitarMoto(Moto moto)
    {
        _contador++;
        Console.WriteLine($"  [{_contador:D2}] MOTO  | {moto.Nome,-10} | " +
                          $"Modelo: {moto.Modelo,-20} | " +
                          $"Preco de tabela: {moto.Preco:C}");
    }
}
