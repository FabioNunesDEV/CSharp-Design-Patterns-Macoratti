namespace Memento;

/// <summary>
/// Interface que define os métodos para recuperar o estado armazenado no Memento.
/// Permite ao Originator acessar os valores salvos para restauração.
/// </summary>
public interface IOriginator
{
    int Primeiro { get; }
    int Segundo { get; }
}
