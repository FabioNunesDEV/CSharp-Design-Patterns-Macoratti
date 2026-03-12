namespace Memento;

/// <summary>
/// Classe Calculadora que atua como o Originator do padrão Memento.
/// Ela é o objeto cujo estado (primeiro número e segundo número) precisa ser salvo e restaurado.
/// Cria o Memento (backup) e restaura seu estado a partir dele.
/// </summary>
public class Calculadora : ICalculadora
{
    private int _primeiro;
    private int _segundo;

    public void SetPrimeiroNumero(int numero)
    {
        _primeiro = numero;
    }

    public void SetSegundoNumero(int numero)
    {
        _segundo = numero;
    }

    public int ObterResultado()
    {
        return _primeiro + _segundo;
    }

    /// <summary>
    /// Cria um Memento contendo o estado atual (primeiro e segundo número).
    /// Retorna como ICaretaker para não expor o estado ao mundo exterior.
    /// </summary>
    public ICaretaker BackupUltimoCalculo()
    {
        return new Memento(_primeiro, _segundo);
    }

    /// <summary>
    /// Restaura o estado anterior a partir do Memento.
    /// Faz o cast para IOriginator para acessar os valores salvos.
    /// </summary>
    public void RestauraUltimoCalculo(ICaretaker caretaker)
    {
        var originator = (IOriginator)caretaker;
        _primeiro = originator.Primeiro;
        _segundo = originator.Segundo;
    }
}
