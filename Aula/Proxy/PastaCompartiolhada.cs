namespace Proxy;

/// <summary>
/// Implementação concreta do serviço (o objeto real a ser protegido).
/// 
/// Papel no padrão Proxy:
/// - <b>RealSubject</b>: contém a lógica real do recurso que o cliente deseja acessar.
/// - É instanciado e acionado pelo <b>Proxy</b> quando o acesso é permitido.
/// 
/// Cenário do exemplo:
/// - Pasta compartilhada com informações confidenciais.
/// - Apenas perfis autorizados (ex.: "CEO") devem executar operações de leitura/gravação.
/// </summary>
public class PastaCompartiolhada : IPastaCompartilhada
{
    public void OperacaoDeLeituraGravacao()
    {
        // Define a operação a ser realizada no recurso real (pasta compartilhada).
        Console.WriteLine("### Operação de leitura e gravação realizada na pasta compartilhada ###");
    }
}
