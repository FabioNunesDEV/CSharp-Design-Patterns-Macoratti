namespace Facade.Subsistemas;

/// <summary>
/// Subsistema: simula uma consulta ao Serasa (restrição de crédito).
/// 
/// A Facade centraliza o fluxo de concessão de crédito e chama este componente
/// para determinar se existe pendência.
/// </summary>
public class Serasa
{
    /// <summary>
    /// Verifica se o cliente possui pendências no Serasa.
    /// Retorna <c>false</c> no exemplo para simplificar o fluxo.
    /// </summary>
    public bool EstaNoSerasa(Cliente cliente)
    {
        Console.WriteLine("Verificando o Serasa para o cliente " + cliente.Nome);
        return false;
    }
}
