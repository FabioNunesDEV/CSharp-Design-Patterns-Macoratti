namespace Facade.Subsistemas;

/// <summary>
/// Subsistema: simula uma consulta ao CADIN (restrição de crédito).
/// 
/// Em um sistema real, aqui haveria uma integração (API/DB/serviço externo).
/// No exemplo, a Facade orquestra esta verificação junto com outros componentes.
/// </summary>
public class Cadin
{
    /// <summary>
    /// Verifica se o cliente possui restrição no CADIN.
    /// Retorna <c>false</c> no exemplo para simplificar o fluxo.
    /// </summary>
    public bool EstaNoCadin(Cliente cliente)
    {
        Console.WriteLine("Verificando o CADIN para o cliente " + cliente.Nome);
        return false;

    }
}
