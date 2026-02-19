namespace Proxy;

/// <summary>
/// Define o contrato comum entre o <b>RealSubject</b> e o <b>Proxy</b>.
/// 
/// Papel no padrão Proxy:
/// - <b>Subject</b>: interface/abstração que permite que cliente use Proxy e RealSubject
///   de forma intercambiável.
/// 
/// Referências:
/// - A interface do serviço declara a interface do serviço; o proxy deve seguir essa interface
///   para se disfarçar como o objeto real (material complementar).
/// </summary>
public interface IPastaCompartilhada
{
    /// <summary>
    /// Operação sensível (leitura/gravação) no recurso protegido.
    /// No exemplo, representa o acesso à pasta compartilhada no computador.
    /// </summary>
    void OperacaoDeLeituraGravacao();
}
