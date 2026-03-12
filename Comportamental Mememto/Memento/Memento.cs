namespace Memento;

/// <summary>
/// Classe Memento que armazena o estado interno do Originator (Calculadora).
/// Implementa ICaretaker (para ser armazenado pelo zelador sem expor o estado)
/// e IOriginator (para permitir ao Originator recuperar os valores salvos).
/// Possui apenas getters — não permite alteração externa do estado armazenado.
/// </summary>
public class Memento : ICaretaker, IOriginator
{
    public int Primeiro { get; }
    public int Segundo { get; }

    public Memento(int primeiro, int segundo)
    {
        Primeiro = primeiro;
        Segundo = segundo;
    }
}
