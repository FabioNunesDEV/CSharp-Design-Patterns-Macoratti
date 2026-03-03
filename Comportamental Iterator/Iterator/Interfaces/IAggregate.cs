using Iterator.Interfaces;

namespace Iterator.Interfaces;

/// <summary>
/// Aggregate (GoF): contrato que define a criação de um iterador e acesso controlado aos elementos.
/// </summary>
/// <typeparam name="T">Tipo de elemento armazenado.</typeparam>
public interface IAggregate<T>
{
    /// <summary>
    /// Cria um Iterator compatível com a coleção, permitindo percorrê-la sem expor sua estrutura interna.
    /// </summary>
    IIterator<T> CreateIterator();

    /// <summary>
    /// Quantidade de elementos armazenados. Usado pelo iterador para validar limites.
    /// </summary>
    int Count { get; }

    /// <summary>
    /// Adiciona um elemento à coleção encapsulada.
    /// </summary>
    void Add(T item);

    /// <summary>
    /// Retorna um elemento pelo índice sem revelar a coleção interna ao cliente.
    /// </summary>
    T GetItem(int index);
}
