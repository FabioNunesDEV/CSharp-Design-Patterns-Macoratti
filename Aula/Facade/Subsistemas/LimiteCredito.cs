namespace Facade.Subsistemas;

/// <summary>
/// Subsistema: realiza o cálculo/validação de limite de crédito.
/// 
/// No exemplo, a regra é intencionalmente simplificada para fins didáticos.
/// </summary>
public class LimiteCredito
{
    /// <summary>
    /// Verifica se o cliente possui limite de crédito para o valor solicitado.
    /// </summary>
    /// <param name="cliente">Cliente solicitante.</param>
    /// <param name="valor">Valor do empréstimo solicitado.</param>
    /// <returns>
    /// <c>true</c> se o valor estiver dentro do limite; caso contrário, <c>false</c>.
    /// </returns>
    public bool PossuiLimiteCredito (Cliente cliente, double valor)
    {
        Console.WriteLine("Verificando o limite de crédito para o cliente " + cliente.Nome);

        // Regra fictícia: acima de 200.000 o subsistema reprova.
        if (valor > 200000.00)
        {
            return false;
        }
        else
        {
            return true;
        }
    }
}
