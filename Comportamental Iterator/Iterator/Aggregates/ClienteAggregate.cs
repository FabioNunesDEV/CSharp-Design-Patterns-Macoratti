using Iterator.Domain;
using Iterator.Interfaces;

namespace Iterator.Aggregates;

/// <summary>
/// ConcreteAggregate (GoF): armazena a coleção de clientes e fabrica o iterador correspondente
/// sem expor a estrutura interna.
/// </summary>
public class ClienteAggregate : IAggregate<Cliente>
{
    // Coleção interna encapsulada. Não é exposta ao cliente para preservar o encapsulamento do padrão.
    private readonly List<Cliente> _clientes = new();

    public int Count => _clientes.Count;

    public void Add(Cliente item) => _clientes.Add(item);

    public Cliente GetItem(int index)
    {
        if (index < 0 || index >= _clientes.Count)
        {
            throw new ArgumentOutOfRangeException(nameof(index), "Índice fora dos limites da coleção.");
        }

        return _clientes[index];
    }

    public IIterator<Cliente> CreateIterator() => new Iterators.ClienteIterator(this);
}
