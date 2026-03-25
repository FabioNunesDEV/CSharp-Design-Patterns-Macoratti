// =============================================================================
// PADRÃO VISITOR - Concessionaria (ObjectStructure)
// =============================================================================
// Papel no padrão : ObjectStructure
// Correspondência : "ObjectStructure" no diagrama UML do GoF
//
// Mantém a coleção de elementos (ILoja) e fornece uma interface para
// percorrê-los e aplicar Visitors. O cliente não precisa conhecer os
// tipos concretos dos elementos — interage com eles via ILoja.
//
// ⚙️  É aqui que o 1º Despacho acontece:
//   AplicarVisitor() itera sobre os elementos e chama elemento.Accept(visitor).
//   A partir daí o elemento assume o controle e executa o 2º Despacho.
// =============================================================================

/// <summary>
/// ObjectStructure: Concessionaria.
/// Contém e gerencia a coleção de veículos (ILoja).
/// Permite aplicar qualquer IVisitor sobre todos os elementos da coleção
/// sem que o cliente precise conhecer os tipos concretos dos elementos.
/// </summary>
public class Concessionaria
{
    // Coleção de elementos do tipo ILoja (Element interface)
    private readonly List<ILoja> _veiculos = new();

    /// <summary>Adiciona um veículo à estrutura de objetos.</summary>
    public void AdicionarVeiculo(ILoja veiculo) => _veiculos.Add(veiculo);

    /// <summary>
    /// Aplica um Visitor sobre todos os elementos da coleção.
    /// Para cada elemento, chama Accept(visitor) — iniciando o 1º Despacho.
    /// O elemento então decide qual método do visitor invocar (2º Despacho).
    /// </summary>
    public void AplicarVisitor(IVisitor visitor)
    {
        foreach (var veiculo in _veiculos)
            veiculo.Accept(visitor); // 1º Despacho: ObjectStructure -> elemento.Accept(visitor)
    }

    /// <summary>Expõe os veículos para leitura direta (sem Visitor).</summary>
    public IReadOnlyList<ILoja> Veiculos => _veiculos.AsReadOnly();
}
