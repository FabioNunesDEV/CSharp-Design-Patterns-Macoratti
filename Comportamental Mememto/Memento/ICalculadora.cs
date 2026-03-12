namespace Memento;

/// <summary>
/// Interface que define o contrato para a Calculadora (Originator).
/// Define os métodos para atribuir valores, obter resultado,
/// fazer backup (createMemento) e restaurar (setMemento) o estado.
/// </summary>
public interface ICalculadora
{
    void SetPrimeiroNumero(int numero);
    void SetSegundoNumero(int numero);
    int ObterResultado();
    ICaretaker BackupUltimoCalculo();
    void RestauraUltimoCalculo(ICaretaker caretaker);
}
