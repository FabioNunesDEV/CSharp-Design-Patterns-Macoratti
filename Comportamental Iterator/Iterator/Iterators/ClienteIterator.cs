using Iterator.Domain;
using Iterator.Interfaces;

namespace Iterator.Iterators;

/// <summary>
/// ConcreteIterator (GoF): mantém o estado de travessia (posição atual e passo) sobre a coleção de clientes.
/// </summary>
public class ClienteIterator : IIterator<Cliente>
{
    private readonly IAggregate<Cliente> _aggregate;
    private int _currentIndex;
    private readonly int _step = 1;

    public ClienteIterator(IAggregate<Cliente> aggregate)
    {
        _aggregate = aggregate;
        _currentIndex = 0;
    }

    public Cliente? First()
    {
        _currentIndex = 0;
        return _aggregate.Count > 0 ? _aggregate.GetItem(_currentIndex) : null;
    }

    public Cliente? Next()
    {
        _currentIndex += _step;
        return !IsDone ? _aggregate.GetItem(_currentIndex) : null;
    }

    public bool IsDone => _currentIndex >= _aggregate.Count;

    public Cliente? CurrentItem => !IsDone ? _aggregate.GetItem(_currentIndex) : null;
}
